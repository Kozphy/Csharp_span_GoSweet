﻿using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks.Dataflow;
using GoSweet.Controllers.feature;
using GoSweet.Models.ViewModels;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Agreement;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopwebContext _context;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHost;
        private HomeIndexVm _indexViewModelData = new HomeIndexVm();

        public HomeController(ILogger<HomeController> logger, ShopwebContext context, IConfiguration config, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _context = context;
            _config = config;
            _webHost = webHost;
        }

        public IActionResult Index()
        {

            List<CategoryViewModel> categoriesDatas = (from product in _context.ProductDatatables
                                                       select new CategoryViewModel
                                                       {
                                                           Category = product.PCategory
                                                       }).Distinct().ToList();


            List<ProductRankDataViewModel> productRankData = (from product in _context.ProductDatatables
                                                              join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                              join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                                                              where product_pic.PPicnumber == 1
                                                              group order by
                                                              new
                                                              {
                                                                  product.PName,
                                                                  product.PCategory,
                                                                  product_pic.PUrl,
                                                                  product.PPrice,
                                                                  product.PDescribe,
                                                                  order.OBuynumber
                                                              }
                                  into grouped
                                                              orderby grouped.Sum((g) => g.OBuynumber) descending
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductName = grouped.Key.PName,
                                                                  ProductCategory = grouped.Key.PCategory,
                                                                  ProductPicture = grouped.Key.PUrl,
                                                                  ProductPrice = grouped.Key.PPrice,
                                                                  ProductDescription = grouped.Key.PDescribe,
                                                                  ProductTotalBuyNumber = grouped.Sum(o => o.OBuynumber)
                                                              }).ToList();

            //foreach (var group in productRankData)
            //{
            //    foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group))
            //    {
            //        Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
            //    }
            //}

            List<ProductGroupBuyData> productGroupBuyData = (from product in _context.ProductDatatables
                                                             join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                             join groupbuy in _context.GroupDatatables on product.PNumber equals groupbuy.PNumber
                                                             join member in _context.MemberMembertables on groupbuy.GNumber equals member.GNumber
                                                             orderby member.MNowpeople descending
                                                             select new ProductGroupBuyData
                                                             {
                                                                 ProductName = product.PName,
                                                                 ProductPicture = product_pic.PUrl,
                                                                 ProductDescription = product.PDescribe,
                                                                 GroupMaxPeople = groupbuy.GMaxpeople,
                                                                 GroupNowPeople = member.MNowpeople,
                                                                 GroupEndDate = groupbuy.GEnd,
                                                                 GroupPeoplePercent = Math.Floor((double)member.MNowpeople / groupbuy.GMaxpeople * 100.0),
                                                                 GroupRemainDate = groupbuy.GEnd.Day - new DateTime().Day,
                                                             }).Take(4).ToList();
            // belldropdown message
            IEnumerable<BellDropDownVm>?  bellDropDownDatas = GetBellDropdownMessage();

            //Console.WriteLine(productGroupBuyData);
            _indexViewModelData.categoryViewModel = categoriesDatas;
            _indexViewModelData.productRankDatas = productRankData;
            _indexViewModelData.productGroupBuyDatas = productGroupBuyData;
            _indexViewModelData.bellDropDownVm = bellDropDownDatas;
            //_indexViewModelData.bellContentDatas = bellContentsDatas;
            HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));


            //Console.WriteLine(HttpContext.Session.GetString("customerAccountName"));
            //Console.WriteLine(HttpContext.Session.GetString("c_number"));
            //foreach (var group in productGroupBuyData)
            //{
            //    foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group))
            //    {
            //        Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
            //    }
            //}
            return View(_indexViewModelData);
        }

        private IEnumerable<BellDropDownVm>? GetBellDropdownMessage() {

            string customerAccount = HttpContext.Session.GetString("customerAccount")!;
            if (customerAccount == null) {
                return null;
            }

            IEnumerable<BellDropDownVm> notifyMessageAlreadyGroup =  
                                           (from notify in _context.NotifyDatatables
                                           join order in _context.OrderDatatables
                                               on notify.ONumber equals order.ONumber
                                           join customer in _context.CustomerAccounttables
                                               on notify.CNumber equals customer.CNumber
                                           join product in _context.ProductDatatables
                                               on order.PNumber equals product.PNumber
                                           join groups in _context.GroupDatatables 
                                               on  product.PNumber equals groups.PNumber
                                            where (notify.OStatus == "已成團") && customer.CAccount == customerAccount && notify.NRead == false
                                            select new BellDropDownVm 
                                            {
                                                //OrderNumber = notify.ONumber,
                                                GroupNumber = groups.PNumber,
                                                //Account = customer.CAccount,
                                                ProductName = product.PName,
                                                OrderStatus = notify.OStatus,
                                            }).ToList();

            //IEnumerable<BellContentVm> notifyMessage

            IEnumerable<BellDropDownVm> notifyMessageAlreadySend =
            (from notify in _context.NotifyDatatables
             join order in _context.OrderDatatables
                 on notify.ONumber equals order.ONumber
             join customer in _context.CustomerAccounttables
                 on notify.CNumber equals customer.CNumber
             join product in _context.ProductDatatables
                 on order.PNumber equals product.PNumber
             where (notify.OStatus == "已寄出") && customer.CAccount == customerAccount && notify.NRead == false
             select new BellDropDownVm 
             {
                 OrderNumber = notify.ONumber,
                 //Account = customer.CAccount,
                 ProductName = product.PName,
                 OrderStatus = notify.OStatus,
             }).ToList();

            //BellDropDownVm bellDropDownVm = new BellDropDownVm();
            IEnumerable<BellDropDownVm> bellDropDownsDatas = notifyMessageAlreadyGroup.Concat(notifyMessageAlreadySend).ToList();


            return bellDropDownsDatas;
        }

        [HttpGet]
        public JsonResult HandleProductCategory([FromQuery] string Category)
        {
            List<ProductRankDataViewModel> productRankData = (from product in _context.ProductDatatables
                                                              join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                              join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                                                              where product_pic.PPicnumber == 1 && product.PCategory == Category
                                                              group order by
                                                              new
                                                              {
                                                                  product.PName,
                                                                  product.PCategory,
                                                                  product_pic.PUrl,
                                                                  product.PPrice,
                                                                  product.PDescribe,
                                                                  order.OBuynumber
                                                              }
                              into grouped
                                                              orderby grouped.Sum((g) => g.OBuynumber) descending
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductName = grouped.Key.PName,
                                                                  ProductCategory = grouped.Key.PCategory,
                                                                  ProductPicture = grouped.Key.PUrl,
                                                                  ProductPrice = grouped.Key.PPrice,
                                                                  ProductDescription = grouped.Key.PDescribe,
                                                                  ProductTotalBuyNumber = grouped.Sum(o => o.OBuynumber)
                                                              }).ToList();


            //TODO: fix value can't be null
            //IEnumerable<CategoryViewModel>? categoriesDatas = JsonConvert.DeserializeObject<IEnumerable<CategoryViewModel>>(HttpContext.Session.GetString("categoriesDatas")!);
            //foreach (var item in categoriesDatas!)
            //{
            //    Console.WriteLine(item.Category);
            //}
            //IEnumerable<ProductGroupBuyData>? productGroupBuyDatas = JsonConvert.DeserializeObject<IEnumerable<ProductGroupBuyData>>(HttpContext.Session.GetString("productGroupBuyDatas")!);
            //_indexViewModelData.categoryViewModel = categoriesDatas;
            //_indexViewModelData.productGroupBuyDatas = productGroupBuyDatas;
            //_indexViewModelData.productRankDatas = productRankData;
            
            //RedirectToAction("Index", _indexViewModelData);
            return new JsonResult(JsonConvert.SerializeObject(productRankData)); 
            //return View("Index", _indexViewModelData);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(CustomerAccountVm customerLoginData)
        {
            if (ModelState.IsValid == false) return View();

            var userAccountQuery = _context.CustomerAccounttables.Where((c) =>
                c.CAccount.Equals(customerLoginData.CAccount) &&
                c.CPassword.Equals(customerLoginData.CPassword)
            ).Select((c) =>
            new
            {
                AccountName = c.CNickname,
                CustomerAccount = c.CAccount,
                c_number = c.CNumber,
            });

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
            HttpContext.Session.SetString("c_number", Convert.ToString(userAccount.c_number));
            TempData["customerAccountLoginSuccessMessage"] = "帳號登入成功";
            return RedirectToAction("Index");
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CustomerAccountVm customerAccountData)
        {
            // encoding
            if (ModelState.IsValid == false) return View();
            //SHA512 sha512 = new SHA512CryptoServiceProvider();
            //byte[] source = Encoding.Default.GetBytes(customerAccountData.CPassword);
            //byte[] crypto = sha512.ComputeHash(source);
            //string hashResult = Convert.ToBase64String(crypto);
            //customerAccountData.CPassword = hashResult;

            // check account whether exist
            bool accountNotExist = _context.CustomerAccounttables.Where((c) =>
                c.CNickname.Equals(customerAccountData.CNickname) &&
                c.CAccount.Equals(customerAccountData.CAccount) &&
                c.CPassword.Equals(customerAccountData.CPassword)
            ).IsNullOrEmpty();



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
                Console.WriteLine(e.Message);
            }
            //HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            //HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));
            return RedirectToAction("SignUp");
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

        [HttpPost]
        public IActionResult SendMail(string EmailAddress)
        {

            if (EmailAddress.IsNullOrEmpty())
            {
                return RedirectToAction("Login");
            }

            // 寄送 email 之前先檢查 email 是否存在
            bool customerAccountNotExist = _context.CustomerAccounttables.Where(c => c.CAccount.Equals(EmailAddress)).IsNullOrEmpty();

            if (customerAccountNotExist.Equals(true))
            {
                TempData["customerAccountNotExistMessage"] = "帳號不存在";
                return RedirectToAction("Login");
            }

            // send email
            Mail mailHandler = new Mail(EmailAddress, "Home");
            string sendEmailResult = mailHandler.SendMail();
            TempData["sendEmailResultMessage"] = sendEmailResult;
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string EmailAddress)
        {
            ViewBag.EmailAddress = EmailAddress;
            return View();
        }


        [HttpPost]
        public IActionResult ResetPassword(string EmailAddress, string oldPassword, string newPassword)
        {

            var account = _context.CustomerAccounttables.Where((c) => c.CAccount.Equals(EmailAddress)).First();

            try
            {
                account.CPassword = newPassword;
                _context.SaveChanges();
                TempData["resetPasswordSuccessMessage"] = "密碼重置成功";
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult LogOut() {
            HttpContext.Session.Remove("customerAccountName");
            HttpContext.Session.Remove("customerAccount");
            //HttpContext.Session.SetString("AccountName", String.Empty);
            return RedirectToAction("Index", "Home");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}