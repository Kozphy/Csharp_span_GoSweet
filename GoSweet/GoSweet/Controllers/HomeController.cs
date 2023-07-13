using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoSweet.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly shopwebContext _shopwebContext;

        public HomeController(ILogger<HomeController> logger, shopwebContext shopwebContext)
        {
            _logger = logger;
            _shopwebContext = shopwebContext;
        }

        public IActionResult Index()
        {
            // Order_datatable, o_buynumber
            // Member_membertable, m_nowpeople, g_maxpeople, Group_datatable g_end
            // 
            var productRankData = (from product in _shopwebContext.Product_datatables
                                   join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                   join order in _shopwebContext.Order_datatables on product.p_number equals order.p_number 
                                   select new
                                   {
                                       ProductName = product.p_number,
                                       ProductCategory = product.p_category,
                                       ProductPrice = product.p_price,
                                       ProductDescription = product.p_describe,
                                       ProductPicture = product_pic.p_url,
                                       ProductBuyNumber = order.o_buynumber,
                                   }).OrderByDescending(p => p.ProductBuyNumber).ToList();
            ViewData["productRankData"] = productRankData;
            foreach (var p in productRankData) {
                Console.WriteLine(p);
            }

            var productGroupBuyData = from product in _shopwebContext.Product_datatables
                                  join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                  join groupbuy in _shopwebContext.Group_datatables on product.p_number equals groupbuy.p_number
                                  join groupbuyMember in _shopwebContext.Member_membertables on groupbuy.g_number equals groupbuyMember.g_number
                                  select new
                                  {
                                        ProductName = product.p_name,
                                        groupMaxPeople = groupbuyMember.g_maxpeople,
                                        groupNowPeople = groupbuyMember.m_nowpeople,
                                  };

            ViewData["productGroupBuyData"] = productGroupBuyData.ToList();

            //var order_data = from order in _shopwebContext.Order_datatables
            //                 join product in _shopwebContext.Product_datatables on order.p_number equals product.p_number
            //                 select new
            //                 {
            //                     ProductBuyNumber = order.o_buynumber,
            //                 };

            Console.WriteLine("HomePage");
            Console.WriteLine(HttpContext.Session.GetString("UserEmail"));
            Console.WriteLine(HttpContext.Session.GetString("UserPassword"));
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(Customer_accounttable data) {
            if (ModelState.IsValid) { 
                Console.WriteLine(data.c_account);
                Console.WriteLine(data.c_password);
                HttpContext.Session.SetString("UserEmail",data.c_account);
                HttpContext.Session.SetString("UserPassword", data.c_password);
            }
            return View();
        }

        public IActionResult SignUp() {
            return View();
        }


        // [Bind("AccountName", "UserEmail", "UserPassword")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SignUp(Customer_accounttable data) 
        {
            if (ModelState.IsValid) {
                Console.WriteLine(data.c_nickname);
                //_shopwebContext.Customer_accounttables.Add(userData);
                //Console.WriteLine(AccountName);
                //Console.WriteLine(UserEmail);
                //Console.WriteLine(UserPassword);
                //Console.WriteLine(UserPasswordCheck);
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