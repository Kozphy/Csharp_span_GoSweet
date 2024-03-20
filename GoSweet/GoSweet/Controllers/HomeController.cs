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
using Microsoft.Reporting.NETCore;
using Microsoft.Extensions.Primitives;
using Paillave.Etl.Core;
using IronPython.Compiler.Ast;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {

        // power bi
        private string m_errorMessage;

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

        /// <summary>
        /// 取得產品熱銷排行的種類標籤
        /// </summary>
        /// <returns>
        /// List<CategoryViewModel>
        /// </returns>
        private void GetCategoriesDatasLabels()
        {
            // 取得種類標籤資料
            List<CategoryViewModel> categoriesDatasLabels = (
                from product in _context.ProductDatatables
                select new CategoryViewModel { Category = product.PCategory }
            )
                .Distinct()
                .ToList();

            _indexViewModelData.CategoryDatas = categoriesDatasLabels;

            // setting data 到 session
            HttpContext
                .Session
                .SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatasLabels));
        }

        private void GetProductSellWellData()
        {

            // TODO: fix group
            #region getProductSellWellData
            List<ProductRankDataViewModel> productSellWellData = (
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

            _indexViewModelData.ProductRankDatas = productSellWellData;

            HttpContext
                 .Session
                 .SetString(
                     "productGroupBuyDatas",
                     JsonConvert.SerializeObject(productSellWellData)
                 );

        }

        private void GetProductGroupBuying()
        {
            #region getProductGroupBuyData
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
            _indexViewModelData.ProductGroupBuyDatas = productGroupBuyData;

        }

        /// <summary>
        /// 取得首頁資料
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _logger.LogInformation("HomeIndexStart");

            // 取得商品種類標籤
            GetCategoriesDatasLabels();

            //　取得產品銷售資料
            GetProductSellWellData();

            // 取得熱銷團購資料
            GetProductGroupBuying();

            // 通知訊息
            GetBellDropdownMessage();
            //_indexViewModelData.bellContentDatas = bellContentsDatas;

            return View(_indexViewModelData);
        }
        /// <summary>
        /// 取得商品已團購的資料
        /// </summary>
        /// <param name="customerAccount"></param>
        /// <returns></returns>
        private IEnumerable<CustomerBellDropDownVm> GetNotifyMessageAlreadyGroup(string customerAccount)
        {

            #region notifyMessageAlreadyGroup
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
                    //OrderNumber = notify.ONumber,
                    GroupNumber = groups.PNumber,
                    //Account = customer.CAccount,
                    ProductName = product.PName,
                    OrderStatus = notify.OStatus,
                }
            ).ToList();
            #endregion
            return notifyMessageAlreadyGroup;
        }

        /// <summary>
        /// 取得商品已寄出的資料
        /// </summary>
        /// <param name="customerAccount"></param>
        /// <returns></returns>
        private IEnumerable<CustomerBellDropDownVm> GetNotifyMessageAlreadySend(string customerAccount)
        {
            #region NotfiyMessageAlreadySend
            return
                (
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
        }

        /// <summary>
        /// 取得通知訊息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerBellDropDownVm>? GetBellDropdownMessage()
        {
            string customerAccount = HttpContext.Session.GetString("customerAccount")!;
            if (customerAccount == null)
            {
                return null;
            }

            IEnumerable<CustomerBellDropDownVm> notifyMessageAlreadyGroupData = GetNotifyMessageAlreadyGroup(customerAccount);

            IEnumerable<CustomerBellDropDownVm> notifyMessageAlreadySendData = GetNotifyMessageAlreadySend(customerAccount);

            IEnumerable<CustomerBellDropDownVm> bellDropDownsDatas = notifyMessageAlreadyGroupData
                .Concat(notifyMessageAlreadySendData)
                .ToList();

            // storage to httpContext
            HttpContext
                .Session
                .SetString("NotfiyMessages", JsonConvert.SerializeObject(bellDropDownsDatas));

            ViewData["bellDropDownMessage"] = bellDropDownsDatas;

            // bellDropDownsDatas Count
            HttpContext.Session.SetInt32("NotfiyMessagesCount", bellDropDownsDatas.Count());

            return bellDropDownsDatas;
        }

        /// <summary>
        /// 點擊鈴鐺訊息已讀按鈕
        /// 將訊息改成已成團，已寄出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BellMessageHaveRead()
        {
            string customerAccount = HttpContext.Session.GetString("customerAccount")!;

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

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return RedirectToAction(nameof(GetBellDropdownMessage));
        }

        /// <summary>
        /// 首頁熱門商品點擊後切換不同的種類
        /// </summary>
        /// <param name="Category"></param>
        /// <returns>json data</returns>
        [HttpGet]
        public JsonResult HandleProductCategory([FromQuery] string Category)
        {
            List<ProductRankDataViewModel> productRankData = (
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

            return new JsonResult(JsonConvert.SerializeObject(productRankData));
        }

        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="customerLoginData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(CustomerLoginVm customerLoginData)
        {
            if (ModelState.IsValid == false)
                return View();

            // create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                customerLoginData.CPassword!
            );
            customerLoginData.CPassword = hashPassword;

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

            // TODO: check account permission
            //var userAccountPermission = userAccount.
            bool accountNotExist = userAccountQuery.IsNullOrEmpty();

            if (accountNotExist.Equals(true))
            {
                TempData["customerAccountNotExistMessage"] = "帳號不存在或密碼錯誤";
                return RedirectToAction("Login");
            }
            var userAccount = userAccountQuery.First();
            HttpContext.Session.SetString("customerAccountName", userAccount.AccountName);
            HttpContext.Session.SetString("customerAccount", userAccount.CustomerAccount);
            HttpContext.Session.SetInt32("cnumber", userAccount.c_number);
            HttpContext.Session.SetInt32("mycnumber", userAccount.c_number);
            _logger.LogInformation("userAccount c_number: {0}", userAccount.c_number.ToString());
            TempData["customerAccountLoginSuccessMessage"] = "帳號登入成功";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 註冊頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// 新增帳號密碼到資料庫
        /// </summary>
        /// <param name="customerAccountData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SignUp(CustomerAccountVm customerAccountData)
        {
            if (ModelState.IsValid == false)
                return View();

            // encoding create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                customerAccountData.CPassword!
            );
            customerAccountData.CPassword = hashPassword;

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

            try
            {
                CreateCustomerAccount(customerAccountData);
                TempData["customerSignUpSuccessMessage"] = "帳號註冊成功";
            }
            catch (Exception e)
            {
                return StatusCode(500, $"add account error: {e.Message}");
            }
            //HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            //HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));
            return RedirectToAction("Login");
        }

        private void CreateCustomerAccount(CustomerAccountVm customerAccountData)
        {
            CustomerAccounttable data = new CustomerAccounttable()
            {
                CAccount = customerAccountData.CAccount,
                CNickname = customerAccountData.CNickname,
                CPassword = customerAccountData.CPassword,
                CMailpass = customerAccountData.CMailpass
            };

            _context.CustomerAccounttables.Add(data);
            _context.SaveChanges();
        }

        /// <summary>
        /// 寄出 Email
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendMail(string EmailAddress)
        {
            if (EmailAddress.IsNullOrEmpty())
            {
                return RedirectToAction("Login");
            }

            // 寄送 email 之前先檢查 email 是否存在
            bool customerAccountNotExist = _context
                .CustomerAccounttables
                .Where(c => c.CAccount.Equals(EmailAddress))
                .IsNullOrEmpty();

            if (customerAccountNotExist.Equals(true))
            {
                TempData["customerAccountNotExistMessage"] = "帳號不存在";
                return RedirectToAction("Login");
            }

            _logger.LogDebug(ControllerContext.ActionDescriptor.ControllerName);

            // send email
            Mail mailHandler = new Mail(
                EmailAddress,
                ControllerContext.ActionDescriptor.ControllerName
            );
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

            return RedirectToAction("Login");
        }

        /// <summary>
        /// 密碼重置頁面
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns></returns>
        public IActionResult ResetPassword(string EmailAddress)
        {
            ResetPasswordVm resetPasswordVm = new ResetPasswordVm() { EmailAddress = EmailAddress };
            //ViewBag.EmailAddress = EmailAddress;
            return View(nameof(ResetPassword), resetPasswordVm);
        }

        /// <summary>
        /// 密碼重置資料到資料庫
        /// </summary>
        /// <param name="resetPasswordData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVm resetPasswordData)
        {
            if (ModelState.IsValid == false)
            {
                return View(resetPasswordData);
            }

            if (resetPasswordData.NewPassword != resetPasswordData.CheckNewPassword)
            {
                TempData["CheckPasswordNotEqualMessage"] = "輸入的密碼不相符";
                return View(resetPasswordData);
            }

            var accountQuery = _context
                .CustomerAccounttables
                .Where((c) => c.CAccount.Equals(resetPasswordData.EmailAddress));
            var account = accountQuery.First();

            // create hashPassword with salt
            string hashPassword = _hashPasswordBuilder.CreateSha256Password(
                resetPasswordData.NewPassword
            );
            account.CPassword = hashPassword;

            try
            {
                _context.SaveChanges();
                TempData["resetPasswordSuccessMessage"] = "密碼重置成功";
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"update password error: {ex.Message}");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 合作廠商頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult CooperateFirm()
        {
            return View();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("customerAccountName");
            HttpContext.Session.Remove("customerAccount");
            HttpContext.Session.Remove("cnumber");
            HttpContext.Session.Remove("mycnumber");
            HttpContext.Session.SetInt32("NotfiyMessagesCount", 0);
            TempData["logOutMessage"] = "登出成功";

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

        public class EnumModels
        {
            public enum SeasonReportType
            {
                綜合損益表 = 1,
                資產負債表 = 2
            }
        }

        public string GetSeasonReportUrl(EnumModels.SeasonReportType seasonReportType)
        {
            string url = "https://mops.twse.com.tw/mops/web/";
            string ajaxUrl = "";
            switch (seasonReportType)
            {
                case EnumModels.SeasonReportType.綜合損益表:
                    ajaxUrl = "ajax_t163sb04";
                    url = url + ajaxUrl;
                    break;
                case EnumModels.SeasonReportType.資產負債表:
                    ajaxUrl = "ajax_t163sb05";
                    url = url + ajaxUrl;
                    break;
                default:
                    break;
            }
            return url;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        /// <summary>
        /// GetBarChartData
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetBarChartData()
        {
            //var query = 
            return Json("GetBarChartData");
        }


        /// <summary>
        /// store files to database
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles(
            IFormFile fileUpload,
            List<IFormFile> filesUpload)
        {
            _logger.LogWarning(
                $"file: {fileUpload.FileName}\r\n" +
                $"files.Count: {filesUpload.Count()}"
              );

            // model validation
            if (!ModelState.IsValid) return Content("Model is not valid");

            // BadRequest
            if (filesUpload.Count() == 0
                && fileUpload.Length == 0) return BadRequest("No file uploaded");

            long size = filesUpload.Sum(f => f.Length);

            try
            {
                await UploadFile(fileUpload);
                await UploadMultipleFiles(filesUpload);
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

            return Ok(new { count = filesUpload.Count, size });
            //return RedirectToAction("index","Home");
        }

        async private Task UploadFile(IFormFile file)
        {
            if (file.Length == 0 || file == null) return;


            var fileName = Path.GetFileName(file.FileName);
            string wwwRootPath = _webHost.WebRootPath;
            string filePath = Path.Combine(wwwRootPath, "uploadFileStorage", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

        }

        async private Task UploadMultipleFiles(List<IFormFile> files)
        {
            if (files.Count == 0 || files == null) return;

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string wwwRootPath = _webHost.WebRootPath;
                    await Console.Out.WriteLineAsync($"wwwRootPath: {_webHost.WebRootPath}");
                    string filePath = Path.Combine(wwwRootPath, "uploadFileStorage", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

        }
        private void StorageFileToDb()
        {
        }
        public IActionResult ExportPDF()
        {
            //Stream reportDefinition = MyReports.;
            var query = from pd in _context.ProductDatatables
                        select pd;

            var report = new LocalReport();
            //report.LoadReportDefinition(reportDefinition);


            return View();
        }

        public IActionResult ExportExcel()
        {

            return View();
        }
        //    public IActionResult Export()
        //    {
        //        var report = new LocalReport();
        //        var items = new[] {
        //    new ClassLibrary2.ReportItem { Description = "Widget 6000", Price = 108, Qty = 1 },
        //    new ClassLibrary2.ReportItem { Description = "Gizmo MAX", Price = 108, Qty = 25 }
        //};
        //        var parameters = new[] { new ReportParameter("Title", "Hello ReportViewCore") };

        //        var assembly = typeof(MyReports.Const).Assembly;
        //        using var rs = assembly.GetManifestResourceStream("MyReports.RDLCs.Report1.rdlc");
        //        report.LoadReportDefinition(rs);
        //        report.DataSources.Add(new ReportDataSource("ReportItem", items));
        //        report.SetParameters(parameters);
        //        var result = report.Render("EXCEL");
        //        return File(result, "application/msexcel", "Export.xls");
        //    }

        //    public IActionResult Print()
        //    {
        //        var report = new LocalReport();
        //        var items = new[] {
        //    new ClassLibrary2.ReportItem { Description = "Widget 6000", Price = 108, Qty = 1 },
        //    new ClassLibrary2.ReportItem { Description = "Gizmo MAX", Price = 108, Qty = 25 }
        //};
        //        var parameters = new[] { new ReportParameter("Title", "Hello ReportViewCore") };

        //        var assembly = typeof(MyReports.Const).Assembly;
        //        using var rs = assembly.GetManifestResourceStream("MyReports.RDLCs.Report1.rdlc");
        //        report.LoadReportDefinition(rs);
        //        report.DataSources.Add(new ReportDataSource("ReportItem", items));
        //        report.SetParameters(parameters);
        //        var result = report.Render("PDF");
        //        return File(result, "application/pdf");
        //    }
    }
}
