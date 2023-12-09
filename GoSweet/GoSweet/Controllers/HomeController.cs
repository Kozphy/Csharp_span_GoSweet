using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using GoSweet.Controllers.feature;
using GoSweet.Models;
using GoSweet.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopwebContext _context;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHost;
        private readonly HomeIndexVm _indexViewModelData = new HomeIndexVm();
        private readonly HashPassword _hashPasswordBuilder = new HashPassword();

        public HomeController(
            ILogger<HomeController> logger,
            ShopwebContext context,
            IConfiguration config,
            IWebHostEnvironment webHost
        )
        {
            _logger = logger;
            _context = context;
            _config = config;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("HomeIndexStart");

            #region 取得商品種類資料
            List<CategoryViewModel> categoriesDatas = (
                from product in _context.ProductDatatables
                select new CategoryViewModel { Category = product.PCategory }
            )
                .Distinct()
                .ToList();

            #endregion

            #region 取得熱銷排行資料
            List<ProductRankDataViewModel> productRankData = (
                from product in _context.ProductDatatables
                join product_pic in _context.ProductPicturetables
                    on product.PNumber equals product_pic.PNumber
                join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                where product_pic.PPicnumber == 1
                group new { product, order } by new
                {
                    product.PNumber,
                    product.PName,
                    product.PCategory,
                    product_pic.PUrl,
                    product.PDescribe,
                } into groupedData
                select new ProductRankDataViewModel
                {
                    ProductId = groupedData.Key.PNumber,
                    ProductName = groupedData.Key.PName,
                    ProductCategory = groupedData.Key.PCategory,
                    ProductPicture = groupedData.Key.PUrl,
                    ProductPrice = Convert.ToInt32(groupedData.Average(x => x.product.PPrice)),
                    ProductDescription = groupedData.Key.PDescribe,
                    ProductTotalBuyNumber = groupedData.Sum(x => x.order.OBuynumber)
                }
            ).OrderByDescending(x => x.ProductTotalBuyNumber).ToList();

            #endregion

            #region 取得團購商品資料
            List<ProductGroupBuyData> productGroupBuyData = (
                from product in _context.ProductDatatables
                join product_pic in _context.ProductPicturetables
                    on product.PNumber equals product_pic.PNumber
                join groupbuy in _context.GroupDatatables on product.PNumber equals groupbuy.PNumber
                join member in _context.MemberMembertables on groupbuy.GNumber equals member.GNumber
                let percent = Math.Floor(
                    (double)member.MNowpeople / (double)groupbuy.GMaxpeople * 100.0
                )
                let remainDays = EF.Functions.DateDiffDay(DateTime.Now, groupbuy.GEnd)
                where product_pic.PPicnumber == 1 && remainDays > 0
                select new ProductGroupBuyData
                {
                    GroupNumber = groupbuy.GNumber,
                    ProductName = product.PName,
                    ProductPicture = product_pic.PUrl,
                    ProductDescription = product.PDescribe,
                    GroupMaxPeople = groupbuy.GMaxpeople,
                    GroupNowPeople = member.MNowpeople,
                    GroupEndDate = groupbuy.GEnd,
                    GroupPeoplePercent = percent,
                    GroupRemainDate = remainDays < 0 ? 0 : remainDays,
                }
            ).OrderBy(x => x.GroupRemainDate).ThenByDescending(x => (int)x.GroupPeoplePercent).Take(4).ToList();

            #endregion

            #region 資料到ViewModel
            _indexViewModelData.CategoryDatas = categoriesDatas;
            _indexViewModelData.ProductRankDatas = productRankData;
            _indexViewModelData.ProductGroupBuyDatas = productGroupBuyData;
            GetBellDropdownMessage();
            #endregion

            #region 儲存資料到 Session
            //_indexViewModelData.bellContentDatas = bellContentsDatas;
            HttpContext
                .Session
                .SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            HttpContext
                .Session
                .SetString(
                    "productGroupBuyDatas",
                    JsonConvert.SerializeObject(productGroupBuyData)
                );
            #endregion


            return View(_indexViewModelData);
        }

        // 取得通知訊息
        public IEnumerable<CustomerBellDropDownVm>? GetBellDropdownMessage()
        {
            string customerAccount = HttpContext.Session.GetString("customerAccount")!;
            if (customerAccount == null)
            {
                return null;
            }

            #region 團購已成團通知
            IEnumerable<CustomerBellDropDownVm> notifyMessageAlreadyGroup = (
                from notify in _context.NotifyDatatables
                join order in _context.OrderDatatables on notify.ONumber equals order.ONumber
                join customer in _context.CustomerAccounttables
                    on notify.CNumber equals customer.CNumber
                join product in _context.ProductDatatables on order.PNumber equals product.PNumber
                join groups in _context.GroupDatatables on product.PNumber equals groups.PNumber
                where
                    (notify.OStatus == "已成團")
                    && customer.CAccount == customerAccount
                    && notify.NRead == false
                select new CustomerBellDropDownVm
                {
                    OrderEnd = order.OEnd,
                    //OrderNumber = notify.ONumber,
                    //GroupNumber = groups.PNumber,
                    //Account = customer.CAccount,
                    ProductName = product.PName,
                    OrderStatus = notify.OStatus,
                }
            ).ToList();
            #endregion

            #region 商品已寄出通知
            IEnumerable<CustomerBellDropDownVm> notifyMessageAlreadySend = (
                from notify in _context.NotifyDatatables
                join order in _context.OrderDatatables on notify.ONumber equals order.ONumber
                join customer in _context.CustomerAccounttables
                    on notify.CNumber equals customer.CNumber
                join product in _context.ProductDatatables on order.PNumber equals product.PNumber
                where
                    (notify.OStatus == "已寄出")
                    && customer.CAccount == customerAccount
                    && notify.NRead == false
                select new CustomerBellDropDownVm
                {
                    OrderEnd = order.OEnd,
                    //Account = customer.CAccount,
                    ProductName = product.PName,
                    OrderStatus = notify.OStatus,
                }
            ).ToList();
            #endregion

            #region 儲存資料到 Session
            //BellDropDownVm bellDropDownVm = new BellDropDownVm();
            IEnumerable<CustomerBellDropDownVm> bellDropDownsDatas = notifyMessageAlreadyGroup
                .Concat(notifyMessageAlreadySend)
                .ToList();
            //ViewData["bellDropDownMessage"] = bellDropDownsDatas;
            HttpContext
                .Session
                .SetString("NotfiyMessages", JsonConvert.SerializeObject(bellDropDownsDatas));
            HttpContext.Session.SetInt32("NotfiyMessagesCount", bellDropDownsDatas.Count());
            #endregion

            return bellDropDownsDatas;
        }

        // 點擊後訊息已讀
        [HttpPost]
        public IActionResult BellMessageHaveRead()
        {
            string customerAccount = HttpContext.Session.GetString("customerAccount")!;

            #region 已成團訊息設定為 true
            var notifyMessageAlreadyGroupQuery =
                from notify in _context.NotifyDatatables
                join order in _context.OrderDatatables on notify.ONumber equals order.ONumber
                join customer in _context.CustomerAccounttables
                    on notify.CNumber equals customer.CNumber
                join product in _context.ProductDatatables on order.PNumber equals product.PNumber
                join groups in _context.GroupDatatables on product.PNumber equals groups.PNumber
                where
                    (notify.OStatus == "已成團")
                    && customer.CAccount == customerAccount
                    && notify.NRead == false
                select notify;

            foreach (var item in notifyMessageAlreadyGroupQuery)
            {
                item.NRead = true;
            }
            #endregion

            #region 已寄出訊息設定為 true
            var notifyMessageAlreadySendQuery =
                from notify in _context.NotifyDatatables
                join order in _context.OrderDatatables on notify.ONumber equals order.ONumber
                join customer in _context.CustomerAccounttables
                    on notify.CNumber equals customer.CNumber
                join product in _context.ProductDatatables on order.PNumber equals product.PNumber
                where
                    (notify.OStatus == "已寄出")
                    && customer.CAccount == customerAccount
                    && notify.NRead == false
                select notify;

            foreach (var item in notifyMessageAlreadySendQuery)
            {
                item.NRead = true;
            }
            #endregion

            #region 資料庫 update
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            #endregion

            return RedirectToAction(nameof(GetBellDropdownMessage));
        }

        // 首頁熱門產品切換種類
        [HttpGet]
        public JsonResult HandleProductCategory([FromQuery] string Category)
        {
            #region 取得產品種類排行資料
            List<ProductRankDataViewModel> specificCategoryProductRankData = (
                from product in _context.ProductDatatables
                join product_pic in _context.ProductPicturetables
                    on product.PNumber equals product_pic.PNumber
                join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                where product_pic.PPicnumber == 1 && product.PCategory == Category
                group new
                {
                    product,
                    product_pic,
                    order
                } by new
                {
                    product.PNumber,
                    product.PName,
                    product.PCategory,
                    product_pic.PUrl,
                    product.PDescribe,
                } into groupedData
                select new ProductRankDataViewModel
                {
                    ProductId = groupedData.Key.PNumber,
                    ProductName = groupedData.Key.PName,
                    ProductCategory = groupedData.Key.PCategory,
                    ProductPicture = groupedData.Key.PUrl,
                    ProductPrice = Convert.ToInt32(groupedData.Average(x => x.product.PPrice)),
                    ProductDescription = groupedData.Key.PDescribe,
                    ProductTotalBuyNumber = groupedData.Sum(x => x.order.OBuynumber)
                }
            ).OrderByDescending(x => x.ProductTotalBuyNumber).ToList();
            #endregion

            return new JsonResult(JsonConvert.SerializeObject(specificCategoryProductRankData));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(CustomerLoginVm customerLoginData)
        {
            if (ModelState.IsValid == false)
                return View();

            #region createHashPassword
            // create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                customerLoginData.CPassword!
            );
            customerLoginData.CPassword = hashPassword;
            #endregion

            #region UserAccountQuery
            var userAccountQuery = _context
                .CustomerAccounttables
                .Where(
                    (c) =>
                        c.CAccount.Equals(customerLoginData.CAccount)
                        && c.CPassword.Equals(customerLoginData.CPassword)
                )
                .Select(
                    (c) =>
                        new
                        {
                            AccountName = c.CNickname,
                            CustomerAccount = c.CAccount,
                            c_number = c.CNumber,
                        }
                );
            #endregion

            #region check UserAccount whether exist
            bool accountNotExist = userAccountQuery.IsNullOrEmpty();

            if (accountNotExist.Equals(true))
            {
                TempData["customerAccountNotExistMessage"] = "帳號不存在或密碼錯誤";
                return RedirectToAction("Login");
            }
            #endregion

            #region get userAccount
            var userAccount = userAccountQuery.First();
            #endregion

            #region set session
            HttpContext.Session.SetString("customerAccountName", userAccount.AccountName);
            HttpContext.Session.SetString("customerAccount", userAccount.CustomerAccount);
            HttpContext.Session.SetInt32("cnumber", userAccount.c_number);
            HttpContext.Session.SetInt32("mycnumber", userAccount.c_number);
            #endregion

            _logger.LogInformation("userAccount c_number: {0}", userAccount.c_number.ToString());

            #region show sweet alert message
            TempData["customerAccountLoginSuccessMessage"] = "帳號登入成功";
            #endregion

            return RedirectToAction("Index");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CustomerAccountVm customerAccountData)
        {
            if (ModelState.IsValid == false)
                return View();

            #region 密碼編碼
            // encoding create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                customerAccountData.CPassword!
            );
            customerAccountData.CPassword = hashPassword;
            #endregion

            #region 檢測帳號是否存在
            // check account whether exist
            bool accountNotExist = _context
                .CustomerAccounttables
                .Where((c) => c.CAccount.Equals(customerAccountData.CAccount))
                .IsNullOrEmpty();

            if (accountNotExist.Equals(false))
            {
                TempData["customerAccountExistMessage"] = "此帳號已被註冊";
                return RedirectToAction("SignUp");
            }
            #endregion

            #region 儲存資料到資料庫
            try
            {
                CreateCustomerAccount(customerAccountData);
                TempData["customerSignUpSuccessMessage"] = "帳號註冊成功";
            }
            catch (Exception e)
            {
                return StatusCode(500, $"add account error: {e.Message}");
            }
            #endregion
            //HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            //HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));
            return RedirectToAction("Login");
        }

        //TODO: move to dto
        private void CreateCustomerAccount(CustomerAccountVm customerAccountData)
        {
            #region convert vm to fit CustomerAccounttable type
            CustomerAccounttable data = new CustomerAccounttable()
            {
                CAccount = customerAccountData.CAccount,
                CNickname = customerAccountData.CNickname,
                CPassword = customerAccountData.CPassword,
                CMailpass = customerAccountData.CMailpass
            };
            #endregion

            #region save to database
            _context.CustomerAccounttables.Add(data);
            _context.SaveChanges();
            #endregion
        }

        [HttpPost]
        public IActionResult SendMail(string EmailAddress)
        {
            #region 如果沒有輸入 Email Address  跳到 Login action
            if (EmailAddress.IsNullOrEmpty())
            {
                return RedirectToAction("Login");
            }
            #endregion

            #region 寄送 email 之前先檢查 email 是否存在
            bool customerAccountNotExist = _context
                .CustomerAccounttables
                .Where(c => c.CAccount.Equals(EmailAddress))
                .IsNullOrEmpty();

            if (customerAccountNotExist.Equals(true))
            {
                TempData["customerAccountNotExistMessage"] = "帳號不存在";
                return RedirectToAction("Login");
            }
            #endregion

            _logger.LogDebug(ControllerContext.ActionDescriptor.ControllerName);

            // send email
            #region 初始化 Email Handler
            Mail mailHandler = new Mail(
                EmailAddress,
                ControllerContext.ActionDescriptor.ControllerName
            );
            #endregion

            #region 寄送 Eamil
            try
            {
                mailHandler.SendMail();
                TempData["sendEmailSuccessMessage"] = $"Send Email to {EmailAddress} Success";
            }
            catch (Exception ex)
            {
                TempData["sendEmailFailMessage"] = $"Send Email to {EmailAddress} fail";
                return BadRequest($"Bad Request: {ex.Message}");
            }
            #endregion

            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string EmailAddress)
        {
            ResetPasswordVm resetPasswordVm = new ResetPasswordVm() { EmailAddress = EmailAddress };
            //ViewBag.EmailAddress = EmailAddress;
            return View(nameof(ResetPassword), resetPasswordVm);
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVm resetPasswordData)
        {
            if (ModelState.IsValid == false)
            {
                return View(resetPasswordData);
            }

            #region 表單密碼不相符
            if (resetPasswordData.NewPassword != resetPasswordData.CheckNewPassword)
            {
                TempData["CheckPasswordNotEqualMessage"] = "輸入的密碼不相符";
                return View(resetPasswordData);
            }
            #endregion

            #region 判斷帳戶是否存在
            var accountQuery = _context
                .CustomerAccounttables
                .Where((c) => c.CAccount.Equals(resetPasswordData.EmailAddress));
            var account = accountQuery.First();

            #endregion

            #region 密碼雜湊
            // create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                resetPasswordData.NewPassword
            );
            account.CPassword = hashPassword;
            #endregion

            #region 儲存密碼到資料庫
            try
            {
                _context.SaveChanges();
                TempData["resetPasswordSuccessMessage"] = "密碼重置成功";
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"update password error: {ex.Message}");
            }
            #endregion

            return RedirectToAction("Index");
        }

        public IActionResult CooperateFirm()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            #region 清除 Session
            HttpContext.Session.Remove("customerAccountName");
            HttpContext.Session.Remove("customerAccount");
            HttpContext.Session.Remove("cnumber");
            HttpContext.Session.Remove("mycnumber");
            #endregion

            #region 設定通知鈴鐺 = 0
            HttpContext.Session.SetInt32("NotfiyMessagesCount", 0);
            #endregion

            #region Sweet alert 顯示登出成功
            TempData["logOutMessage"] = "登出成功";
            #endregion

            //HttpContext.Session.SetString("AccountName", String.Empty);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
