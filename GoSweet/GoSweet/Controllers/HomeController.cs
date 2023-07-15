using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Order_datatable, o_buynumber
            // Member_membertable, m_nowpeople, g_maxpeople, Group_datatable g_end
            // 
            
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