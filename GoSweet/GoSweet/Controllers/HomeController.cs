using GoSweet.Models;
using GoSweet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly shopwebContext _shopwebContext;
        private HomeIndexViewModel indexViewModelData = new HomeIndexViewModel();

        public HomeController(ILogger<HomeController> logger, shopwebContext shopwebContext)
        {
            _logger = logger;
            _shopwebContext = shopwebContext;
        }

        public IActionResult Index()
        {

            // Order_datatable, o_buynumber
            // Member_membertable, m_nowpeople, g_maxpeople, Group_datatable g_end
            List<ProductRankDataViewModel> productRankData = (from product in _shopwebContext.Product_datatables
                                                              join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                                              join order in _shopwebContext.Order_datatables on product.p_number equals order.p_number
                                                              where product_pic.p_picnumber == 1
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.p_number,
                                                                  ProductName = product.p_name,
                                                                  ProductCategory = product.p_category,
                                                                  ProductPicture = product_pic.p_url,
                                                                  ProductPrice = product.p_price,
                                                                  ProductDescription = product.p_describe,
                                                                  ProductTotalBuyNumber = order.o_buynumber,
                                                              }).OrderByDescending((p => p.ProductTotalBuyNumber)).ToList();
            Console.WriteLine("productRankData");
            foreach (var group in productRankData) {
                foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group)) { 
                    Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
                }
            }

            Console.WriteLine();

            Console.WriteLine("productGroupBuyData");
            List<ProductGroupBuyData> productGroupBuyData = (from product in _shopwebContext.Product_datatables
                                                             join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                                             join groupbuy in _shopwebContext.Group_datatables on product.p_number equals groupbuy.p_number
                                                             join member in _shopwebContext.Member_membertables on groupbuy.g_number equals member.g_number
                                                             select new ProductGroupBuyData
                                                             {
                                                                 ProductName = product.p_name,
                                                                 ProductPicture = product_pic.p_url,
                                                                 GroupMaxPeople = groupbuy.g_maxpeople, 
                                                                 GroupNowPeople = member.m_nowpeople, 
                                                                 GroupEndDate = groupbuy.g_end,
                                                             }).ToList();
            Console.WriteLine(productGroupBuyData);
            indexViewModelData.productRankDatas = productRankData;
            indexViewModelData.productGroupBuyDatas = productGroupBuyData;

            foreach (var group in productGroupBuyData) {
                foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group)) { 
                    Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
                }
            }
            return View(indexViewModelData);
        }

        [HttpPost]
        public IActionResult HandleProductCategory(string Category) 
        {

            Console.WriteLine(Category);
            List<ProductRankDataViewModel> productRankData = (from product in _shopwebContext.Product_datatables
                                                              join product_pic in _shopwebContext.Product_picturetables on product.p_number equals product_pic.p_number
                                                              join order in _shopwebContext.Order_datatables on product.p_number equals order.p_number
                                                              where product_pic.p_picnumber == 1 && product.p_category.ToString() == Category
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.p_number,
                                                                  ProductName = product.p_name,
                                                                  ProductCategory = product.p_category,
                                                                  ProductPicture = product_pic.p_url,
                                                                  ProductPrice = product.p_price,
                                                                  ProductDescription = product.p_describe,
                                                                  ProductTotalBuyNumber = order.o_buynumber,
                                                              }).OrderByDescending((p => p.ProductTotalBuyNumber)).ToList();
            Console.WriteLine("productRankData");
            foreach (var group in productRankData) {
                foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(group)) { 
                    Console.WriteLine("{0}={1}", desc.Name, desc.GetValue(group));
                }
            }

            indexViewModelData.productRankDatas = productRankData;


            return View(indexViewModelData);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
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