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

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopwebContext _context;
        private HomeIndexViewModel _indexViewModelData = new HomeIndexViewModel();

        public HomeController(ILogger<HomeController> logger, ShopwebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Order_datatable, o_buynumber
            // Member_membertable, m_nowpeople, g_maxpeople, Group_datatable g_end
            List<CategoryViewModel> categoriesDatas = (from product in _context.Product_datatables
                                                       select new CategoryViewModel
                                                       {
                                                           Category = product.p_category
                                                       }).Distinct().ToList();


            // TODO: fix groupby
            List<ProductRankDataViewModel> productRankData = (from product in _context.Product_datatables
                                                              join product_pic in _context.Product_picturetables on product.p_number equals product_pic.p_number
                                                              join order in _context.Order_datatables on product.p_number equals order.p_number
                                                              where product_pic.p_picnumber == 1
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.p_number,
                                                                  ProductName = product.p_name,
                                                                  ProductPicture = product_pic.p_url,
                                                                  ProductPrice = product.p_price,
                                                                  ProductDescription = product.p_describe,
                                                                  ProductTotalBuyNumber = order.o_buynumber,
                                                              }).OrderByDescending((p => p.ProductTotalBuyNumber)).ToList();


            //Console.WriteLine("productGroupBuyData");
            List<ProductGroupBuyData> productGroupBuyData = (from product in _context.Product_datatables
                                                             join product_pic in _context.Product_picturetables on product.p_number equals product_pic.p_number
                                                             join groupbuy in _context.Group_datatables on product.p_number equals groupbuy.p_number
                                                             join member in _context.Member_membertables on groupbuy.g_number equals member.g_number
                                                             select new ProductGroupBuyData
                                                             {
                                                                 ProductName = product.p_name,
                                                                 ProductPicture = product_pic.p_url,
                                                                 ProductDescription = product.p_describe,
                                                                 GroupMaxPeople = groupbuy.g_maxpeople,
                                                                 GroupNowPeople = member.m_nowpeople,
                                                                 GroupEndDate = groupbuy.g_end,
                                                                 GroupPeoplePercent = Math.Floor((double)member.m_nowpeople / groupbuy.g_maxpeople * 100.0),
                                                                 GroupRemainDate =   groupbuy.g_end.Day - new DateTime().Day,
                                                             }).ToList();
            //Console.WriteLine(productGroupBuyData);
            _indexViewModelData.categoryViewModel = categoriesDatas;
            _indexViewModelData.productRankDatas = productRankData;
            _indexViewModelData.productGroupBuyDatas = productGroupBuyData;
            HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
            HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));


            Console.WriteLine(HttpContext.Session.GetString("AccountName"));
            Console.WriteLine(HttpContext.Session.GetString("c_number"));
            foreach (var group in productGroupBuyData) {
                foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group)) { 
                    Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
                }
            }
            return View(_indexViewModelData);
        }

        [HttpPost]
        public IActionResult HandleProductCategory(string Category)
        {

            List<ProductRankDataViewModel> productRankData = (from product in _context.Product_datatables
                                                              join product_pic in _context.Product_picturetables on product.p_number equals product_pic.p_number
                                                              join order in _context.Order_datatables on product.p_number equals order.p_number
                                                              where product_pic.p_picnumber == 1 && product.p_category == Category
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.p_number,
                                                                  ProductName = product.p_name,
                                                                  ProductPicture = product_pic.p_url,
                                                                  ProductPrice = product.p_price,
                                                                  ProductDescription = product.p_describe,
                                                                  ProductTotalBuyNumber = order.o_buynumber,
                                                              }).OrderByDescending((p => p.ProductTotalBuyNumber)).ToList();
            //Console.WriteLine("productRankData");
            //foreach (var group in productRankData)
            //{
            //    foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group))
            //    {
            //        Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
            //    }
            //}

            //TODO: fix value can't be null
            IEnumerable<CategoryViewModel>? categoriesDatas = JsonConvert.DeserializeObject<IEnumerable<CategoryViewModel>>(HttpContext.Session.GetString("categoriesDatas")!);
            foreach (var item in categoriesDatas!)
            {
                Console.WriteLine(item.Category);
            }
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
        public IActionResult Login(Customer_accounttable customerLoginData) 
        {
            if (ModelState.IsValid) 
            {
                var userAccount = _context.Customer_accounttables.Where((c) =>
                    c.c_account.Equals(customerLoginData.c_account) &&
                    c.c_password.Equals(customerLoginData.c_password)
                ).Select((c) =>
                new {
                    AccountName = c.c_nickname,
                    c_number = c.c_number,
                });

                bool accountNotExist = userAccount.IsNullOrEmpty();

                if (accountNotExist.Equals(true)) {
                    TempData["accountNotExistMessage"] = "帳號不存在";
                    return View();
                }
                HttpContext.Session.SetString("AccountName", userAccount.First().AccountName);
                HttpContext.Session.SetString("c_number", Convert.ToString(userAccount.First().c_number));
                TempData["accountLoginSuccessMessage"] = "帳號登入成功";
            }
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Customer_accounttable customerAccountData)
        {
            if (ModelState.IsValid)
            {
                // check account whether exist
                bool accountNotExist = _context.Customer_accounttables.Where((c) =>
                    c.c_nickname.Equals(customerAccountData.c_nickname) &&
                    c.c_account.Equals(customerAccountData.c_account) &&
                    c.c_password.Equals(customerAccountData.c_password)
                ).IsNullOrEmpty();

                if (accountNotExist.Equals(false))
                {
                    TempData["customerAccountExistMessage"] = "此帳號已被註冊";
                    return View();
                }

                try
                {
                    _context.Customer_accounttables.Add(customerAccountData);
                    _context.SaveChanges();
                    TempData["customerSignUpSuccessMessage"] = "帳號註冊成功";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //HttpContext.Session.SetString("categoriesDatas", JsonConvert.SerializeObject(categoriesDatas));
                //HttpContext.Session.SetString("productGroupBuyDatas", JsonConvert.SerializeObject(productGroupBuyData));
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}