using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.NetworkInformation;
using System.Numerics;

namespace GoSweet.Controllers {
    public class BuyListController : Controller {

        private readonly ShopwebContext _shopwebContext;
        public BuyListController(ShopwebContext shopwebContext) {
            _shopwebContext = shopwebContext;
        }
		[HttpGet]
        public IActionResult BuyList() {
			string? x = HttpContext.Request.Query["pid"];
			string? y = HttpContext.Request.Query["num"];
			if (y != null) {
                int num = int.Parse(y);
            }
			var xx = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
						pdt => pdt.PNumber,
						ppt => ppt.PNumber,
						(pdt, ppt) => new {
							ProductData = pdt,
							ProductPic = ppt
						}).ToList();
			if (x != null) {
				int pid = int.Parse(x);
				xx = xx.Where(x => x.ProductData.PNumber == pid).ToList();
			}
			ViewBag.ProductData = xx;
			ViewBag.buyNum = y;
			return View();
        }

		[HttpPost]
		public ActionResult BuyList(IFormCollection form) {
			if (form != null) {
				var result2 = new OrderDatatable();
				result2.OStart = DateTime.Now;
				result2.CNumber = Convert.ToInt32(form["CNumber"]);
				result2.FNumber = Convert.ToInt32(form["FNumber"]);
				result2.PNumber = Convert.ToInt32(form["PNumber"]);
				result2.OBuynumber = Convert.ToInt32(form["OBuynumber"]);
				result2.OType = false;
				result2.OPrice = Convert.ToInt32(form["OPrice"]);
				result2.OStatus = "已下單";
				result2.OShip = Convert.ToInt32(form["Delivery"]);
				result2.OPayment = Convert.ToInt32(form["Payment"]);
				result2.OPlace = form["OPlace"];
				result2.OShipstatus = "未出貨";
				_shopwebContext.Add(result2);
				_shopwebContext.SaveChanges();

				return Redirect("/home/index");
			}
			return View();
		}


        public IActionResult BuyListGroup() {

			int? pid = Convert.ToInt32(HttpContext.Request.Query["pid"]);
			int num = Convert.ToInt32(HttpContext.Request.Query["num"]);
			int mmt = Convert.ToInt32(HttpContext.Request.Query["mmt"]);
			var xx = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
						pdt => pdt.PNumber,
						ppt => ppt.PNumber,
						(pdt, ppt) => new {
							ProductData = pdt,
							ProductPic = ppt
						}).ToList();
			xx = xx.Where(x=>x.ProductData.PNumber==pid).ToList();
			var mm = _shopwebContext.GroupDatatables.GroupJoin(_shopwebContext.MemberMembertables,
				gdt => gdt.GNumber,
				mmt => mmt.GNumber, (gdt, mmt) => new {
					GroupDatatable = gdt,
					MemberMembertable = mmt.Select(x => x.MNumber).Single()
				}).ToList();

			mm = mm.Where(x => x.GroupDatatable.PNumber == pid).ToList();


			var result2 = new OrderDatatable();
			result2.OStart = DateTime.Now;
			result2.CNumber = 10000;
			result2.FNumber = xx[0].ProductData.FNumber;
			result2.PNumber = xx[0].ProductData.PNumber;
			result2.OBuynumber = num;
			result2.OType = true;
			result2.MNumber = Convert.ToInt32(mm[0].MemberMembertable);
			result2.OPrice = xx[0].ProductData.PNumber;
			result2.OStatus = "待成團";
			result2.OShipstatus = "未出貨";
			_shopwebContext.Add(result2);
			_shopwebContext.SaveChanges();

			ViewBag.ProductData = xx;
			ViewBag.num = num;
			ViewBag.total = xx[0].ProductData.PPrice * num;

            return View();
        }

        [HttpGet]
        public IActionResult BuyListGp() {
            string? x = HttpContext.Request.Query["pid"];
            string? y = HttpContext.Request.Query["num"];
            if (y != null) {
                int num = int.Parse(y);
            }
            var xx = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData = pdt,
                            ProductPic = ppt
                        }).ToList();
            if (x != null) {
                int pid = int.Parse(x);
                xx = xx.Where(x => x.ProductData.PNumber == pid).ToList();
            }
            ViewBag.ProductData = xx;
            ViewBag.buyNum = y;
            return View();
        }
    }
}
