using GoSweet.Models;
using GoSweet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel;
using Azure.Identity;
using System.Xml;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks.Dataflow;
using AngleSharp.Common;
using GoSweet.Controllers.feature;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopwebContext _context;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHost;
        private HomeIndexViewModel _indexViewModelData = new HomeIndexViewModel();

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
                                                             }).ToList();
            //Console.WriteLine(productGroupBuyData);
            _indexViewModelData.categoryViewModel = categoriesDatas;
            _indexViewModelData.productRankDatas = productRankData;
            _indexViewModelData.productGroupBuyDatas = productGroupBuyData;
            HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));


            Console.WriteLine(HttpContext.Session.GetString("AccountName"));
            Console.WriteLine(HttpContext.Session.GetString("c_number"));
            //foreach (var group in productGroupBuyData)
            //{
            //    foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group))
            //    {
            //        Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
            //    }
            //}
            return View(_indexViewModelData);
        }

        [HttpPost]
        public IActionResult HandleProductCategory(string Category)
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
            IEnumerable<CategoryViewModel>? categoriesDatas = JsonConvert.DeserializeObject<IEnumerable<CategoryViewModel>>(HttpContext.Session.GetString("categoriesDatas")!);
            //foreach (var item in categoriesDatas!)
            //{
            //    Console.WriteLine(item.Category);
            //}
            IEnumerable<ProductGroupBuyData>? productGroupBuyDatas = JsonConvert.DeserializeObject<IEnumerable<ProductGroupBuyData>>(HttpContext.Session.GetString("productGroupBuyDatas")!);
            _indexViewModelData.categoryViewModel = categoriesDatas;
            _indexViewModelData.productGroupBuyDatas = productGroupBuyDatas;
            _indexViewModelData.productRankDatas = productRankData;




            return View("Index", _indexViewModelData);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(CustomerAccounttable customerLoginData)
        {
            if (ModelState.IsValid)
            {
                var userAccount = _context.CustomerAccounttables.Where((c) =>
                    c.CAccount.Equals(customerLoginData.CAccount) &&
                    c.CPassword.Equals(customerLoginData.CPassword)
                ).Select((c) =>
                new
                {
                    AccountName = c.CNickname,
                    c_number = c.CNumber,
                });

                bool accountNotExist = userAccount.IsNullOrEmpty();

                if (accountNotExist.Equals(true))
                {
                    TempData["customerAccountNotExistMessage"] = "帳號不存在";
                    return RedirectToAction("Login");
                }
                HttpContext.Session.SetString("AccountName", userAccount.First().AccountName);
                HttpContext.Session.SetString("c_number", Convert.ToString(userAccount.First().c_number));
                TempData["customerAccountLoginSuccessMessage"] = "帳號登入成功";
            }
            return RedirectToAction("Login");
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CustomerAccounttable customerAccountData)
        {
            // encoding
            if (ModelState.IsValid)
            {
                SHA512 sha512 = new SHA512CryptoServiceProvider();
                byte[] source = Encoding.Default.GetBytes(customerAccountData.CPassword);
                byte[] crypto = sha512.ComputeHash(source);
                string hashResult = Convert.ToBase64String(crypto);
                customerAccountData.CPassword = hashResult;

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
                    _context.CustomerAccounttables.Add(customerAccountData);
                    _context.SaveChanges();
                    TempData["customerSignUpSuccessMessage"] = "帳號註冊成功";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
                //HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));
            }
            return RedirectToAction("SignUp");
        }

        [HttpPost]
        public IActionResult SendMail(string emailAddress) {

            if (ModelState.IsValid) {
                if (emailAddress.IsNullOrEmpty()) {
                    return RedirectToAction("Login");
                }

                Mail mailHandler = new Mail(emailAddress, "Home");
                string sendEmailResult = mailHandler.SendMail();
                TempData["sendEmailResultMessage"] = sendEmailResult;
            }
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword() {
            return View();
        }

   
        [HttpPost]
        public IActionResult ResetPassword(string oldPassword, string newPassword) {
            
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}