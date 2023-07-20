﻿using GoSweet.Models;
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
            List<CategoryViewModel> categoriesDatas = (from product in _context.ProductDatatables
                                                       select new CategoryViewModel
                                                       {
                                                           Category = product.PCategory
                                                       }).Distinct().ToList();


            // TODO: fix groupby
            List<ProductRankDataViewModel> productRankData = (from product in _context.ProductDatatables
                                                              join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                              join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                                                              where product_pic.PPicnumber == 1
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.PNumber,
                                                                  ProductName = product.PName,
                                                                  ProductPicture = product_pic.PUrl,
                                                                  ProductPrice = product.PPrice,
                                                                  ProductDescription = product.PDescribe,
                                                                  ProductTotalBuyNumber = order.OBuynumber
                                                                  ,
                                                              }).OrderByDescending((p => p.ProductTotalBuyNumber)).ToList();


            //Console.WriteLine("productGroupBuyData");
            List<ProductGroupBuyData> productGroupBuyData = (from product in _context.ProductDatatables
                                                             join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                             join groupbuy in _context.GroupDatatables on product.PNumber equals groupbuy.PNumber
                                                             join member in _context.MemberMembertables on groupbuy.GNumber equals member.GNumber
                                                             select new ProductGroupBuyData
                                                             {
                                                                 ProductName = product.PName,
                                                                 ProductPicture = product_pic.PUrl,
                                                                 ProductDescription = product.PDescribe,
                                                                 GroupMaxPeople = groupbuy.GMaxpeople,
                                                                 GroupNowPeople = member.MNowpeople,
                                                                 GroupEndDate = groupbuy.GEnd,
                                                                 GroupPeoplePercent = Math.Floor((double)member.MNowpeople / groupbuy.GMaxpeople * 100.0),
                                                                 GroupRemainDate =   groupbuy.GEnd.Day - new DateTime().Day,
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

            List<ProductRankDataViewModel> productRankData = (from product in _context.ProductDatatables
                                                              join product_pic in _context.ProductPicturetables on product.PNumber equals product_pic.PNumber
                                                              join order in _context.OrderDatatables on product.PNumber equals order.PNumber
                                                              where product_pic.PPicnumber == 1 && product.PCategory == Category
                                                              select new ProductRankDataViewModel
                                                              {
                                                                  ProductNumber = product.PNumber,
                                                                  ProductName = product.PName,
                                                                  ProductPicture = product_pic.PUrl,
                                                                  ProductPrice = product.PPrice,
                                                                  ProductDescription = product.PDescribe,
                                                                  ProductTotalBuyNumber = order.OBuynumber,
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
        public IActionResult Login(CustomerAccounttable customerLoginData) 
        {
            if (ModelState.IsValid) 
            {
                var userAccount = _context.CustomerAccounttables.Where((c) =>
                    c.CAccount.Equals(customerLoginData.CAccount) &&
                    c.CPassword.Equals(customerLoginData.CPassword)
                ).Select((c) =>
                new {
                    AccountName = c.CNickname,
                    c_number = c.CNumber,
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
        public IActionResult SignUp(CustomerAccounttable customerAccountData)
        {
            if (ModelState.IsValid)
            {
                // check account whether exist
                bool accountNotExist = _context.CustomerAccounttables.Where((c) =>
                    c.CNickname.Equals(customerAccountData.CNickname) &&
                    c.CAccount.Equals(customerAccountData.CAccount) &&
                    c.CPassword.Equals(customerAccountData.CPassword)
                ).IsNullOrEmpty();

                if (accountNotExist.Equals(false))
                {
                    TempData["customerAccountExistMessage"] = "此帳號已被註冊";
                    return View();
                }

                try
                {
                    _context.CustomerAccounttables.Add(customerAccountData);
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