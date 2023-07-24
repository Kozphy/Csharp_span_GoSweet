using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoSweet.Controllers {
	public class SearchController : Controller {
		private readonly ShopwebContext _context;
		public SearchController(ShopwebContext context) {
			_context = context;
		}
		public IActionResult SearchResult() {
			//string? keyWord = HttpContext.Request.Query["keyWord"];
		//	var xx = _context.ProductDatatables.GroupJoin(_context.ProductPicturetables,
		//				pdt => pdt.PNumber,
		//				ppt => ppt.PNumber,
		//				(pdt, ppt) => new {
		//					ProductData2 = pdt,
		//					ProductPic2 = ppt
		//				}).ToList().GroupJoin(_context.OrderDatatables,
		//				XXX => XXX.ProductData2.PNumber,
		//				odt => odt.PNumber, (pdtPpt, odt) =>
		//				new {
		//					pdtPpt.ProductData2,
		//					pdtPpt.ProductPic2,
		//					odt
		//				}).ToList().GroupJoin(_context.OrderAssesstables,
		//				zzz => zzz.ProductData2.PNumber,
		//				oat => oat.PNumber, (zzz, oat) => new {
		//					ProductData = zzz.ProductData2,
		//					ProductPic = zzz.ProductPic2,
		//					ProductOdt = zzz.odt,
		//					ProductOat = oat.Select(x=>x.OCscore).Average()
		//				}).ToList();
				
		//	if (keyWord != null) {
		//		xx = xx.Where(x => x.ProductData.PName.Contains(keyWord)).ToList();
		//	}
			
		//	var z = xx.OrderBy(p => p.ProductData?.PPrice).ToList();
		//	var zz = xx.OrderByDescending(p => p.ProductData?.PPrice).ToList();
		//	var zzz = xx.OrderByDescending(p => p.ProductOat).ToList();
		//	ViewBag.ProductDatatablesJoin = xx;
		//	ViewBag.ProductDatatablesLow = z;
		//	ViewBag.ProductDatatablesHigh = zz;
		//	ViewBag.ProductDatatablesPT = zzz;
		//	return View();
		//}


		//	var xx = _shopwebContext.ProductGroupViews.ToList();
		//	xx = xx.Where(x => x.PPicnumber == 1).ToList();
		//	if (keyWord != null) {
		//		xx = xx.Where(x => x.PName.Contains(keyWord) && x.PPicnumber == 1).ToList();
		//	}
		//	var z = xx.OrderBy(p => p?.PPrice).ToList();
		//	var zz = xx.OrderByDescending(p => p?.PPrice).ToList();
		//	var zzz = xx.OrderByDescending(p => p.OCscore).ToList();
		//	ViewBag.ProductDatatablesJoin = xx;
		//	ViewBag.ProductDatatablesLow = z;
		//	ViewBag.ProductDatatablesHigh = zz;
		//	ViewBag.ProductDatatablesPT = zzz;
			return View();
		}


		public IActionResult Product([FromQuery] string? pid) {
            Console.WriteLine(pid);
            Console.WriteLine(1);
			return Content("this is Product Page");
            //int? pid = Convert.ToInt32(HttpContext.Request.Query["pid"]);
            //int? group = Convert.ToInt32(HttpContext.Request.Query["group"]);
			//return View();

			//var xx = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
			//			pdt => pdt.PNumber,
			//			ppt => ppt.PNumber,
			//			(pdt, ppt) => new {
			//				ProductData2 = pdt,
			//				ProductPic2 = ppt
			//			}).ToList().GroupJoin(_shopwebContext.OrderDatatables,
			//			XXX => XXX.ProductData2.PNumber,
			//			odt => odt.PNumber, (pdtPpt, odt) =>
			//			new {
			//				pdtPpt.ProductData2,
			//				pdtPpt.ProductPic2,
			//				odt
			//			}).ToList().GroupJoin(_shopwebContext.OrderAssesstables,
			//			zzz => zzz.ProductData2.PNumber,
			//			oat => oat.PNumber, (zzz, oat) => new {
			//				ProductData = zzz.ProductData2,
			//				ProductPic = zzz.ProductPic2,
			//				ProductOdt = zzz.odt,
			//				ProductOat = oat.Select(x => x.OCscore).Average()
			//			}).ToList();
			//var y = _shopwebContext.FirmPagetables.FirstOrDefault();
			//if (pid != null) {
			//	xx = xx.Where(x => x.ProductData.PNumber == pid).ToList();
			//}
			//var yy = _shopwebContext.FirmPagetables.Where(x => x.FNumber == xx[0].ProductData.FNumber).FirstOrDefault();
			//var zzz = _shopwebContext.GroupDatatables.Select(x=>x.PNumber).ToList();
			//int aaa = 0;
			//for (int i = 0; i < zzz.Count; i++) {
   //             if (zzz[i] == pid)
   //             {
   //                 aaa = 1;
   //             }           
			//}
			//var mm = _shopwebContext.GroupDatatables.GroupJoin(_shopwebContext.MemberMembertables,
			//	gdt => gdt.GNumber,
			//	mmt => mmt.GNumber, (gdt, mmt) => new {
			//		GroupDatatable = gdt,
			//		MemberMembertable = mmt.Select(x=>x.MNumber).Single()
			//	}).ToList();
			//mm = mm.Where(x => x.GroupDatatable.PNumber == pid).ToList();
			
			//ViewBag.ProductData = xx;
			//ViewBag.FirmData = yy?.FPagename;
			//ViewBag.GroupTF = aaa;
			
   //         //ViewBag.MMT = 10000;
				

   //         return View();
		}
	}
}
