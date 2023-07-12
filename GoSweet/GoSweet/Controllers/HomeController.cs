using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoSweet.ViewModels;

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
            var productRankData = from product in _shopwebContext.Product_datatables
                               join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                               join order in _shopwebContext.Order_datatables on product.p_number equals order.p_number 
                               select new
                               {
                                   ProductName = product.p_number,
                                   ProductCategory = product.p_category,
                                   ProductPrice = product.p_price,
                                   ProductDescription = product.p_describe,
                                   ProductBuyNumber = order.o_buynumber,
                               };
            ViewData["productRankData"] = productRankData.OrderByDescending((p) => p.ProductBuyNumber).ToList();

            var productGroupBuyData = from product in _shopwebContext.Product_datatables
                                  join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                  join groupbuy in _shopwebContext.Group_datatables on product.p_number equals groupbuy.p_number
                                  select new
                                  {
                                        ProductName = product.p_name,
                                        //GroupBuyName = 
                                  };

            ViewData["productGroupBuyData"] = productGroupBuyData;

            //var order_data = from order in _shopwebContext.Order_datatables
            //                 join product in _shopwebContext.Product_datatables on order.p_number equals product.p_number
            //                 select new
            //                 {
            //                     ProductBuyNumber = order.o_buynumber,
            //                 };
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        public IActionResult SignUp() {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}