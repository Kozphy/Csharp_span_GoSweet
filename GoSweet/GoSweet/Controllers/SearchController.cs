
using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoSweet.Controllers {
    public class SearchController : Controller {
        private readonly ShopwebContext _context;
        public SearchController(ShopwebContext shopwebContext) {
            _context = shopwebContext;
        }
        public IActionResult SearchResult() {
            string? keyWord = HttpContext.Request.Query["keyWord"];
            var groups = _context.ProductDatatables.GroupJoin(_context.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData2 = pdt,
                            ProductPic2 = ppt
                        }).ToList().GroupJoin(_context.OrderDatatables,
                        pdtPpt => pdtPpt.ProductData2.PNumber,
                        odt => odt.PNumber, (pdtPpt, odt) =>
                        new {
                            pdtPpt.ProductData2,
                            pdtPpt.ProductPic2,
                            odt
                        }).ToList().GroupJoin(_context.OrderAssesstables,
                        zzz => zzz.ProductData2.PNumber,
                        oat => oat.PNumber, (zzz, oat) => new {
                            ProductData = zzz.ProductData2,
                            ProductPic = zzz.ProductPic2,
                            ProductOdt = zzz.odt,
                            ProductOat = oat.Select(x => x.OCscore).Average()
                        }).ToList();

            if (keyWord != null) {
                groups = groups.Where(x => x.ProductData.PName.Contains(keyWord)).ToList();
            }

            var gpl = groups.OrderBy(p => p.ProductData?.PPrice).ToList();
            var gph = groups.OrderByDescending(p => p.ProductData?.PPrice).ToList();
            var gpp = groups.OrderByDescending(p => p.ProductOat).ToList();
            ViewBag.ProductDatatablesJoin = groups;
            ViewBag.ProductDatatablesLow = gpl;
            ViewBag.ProductDatatablesHigh = gph;
            ViewBag.ProductDatatablesPT = gpp;
            return View();
        }

        public IActionResult SearchResultGroup() {
            string? keyWord = HttpContext.Request.Query["keyWord"];

            var xx = from groupTable in _context.GroupDatatables
                     join productTable in _context.ProductDatatables on groupTable.PNumber equals productTable.PNumber
                     join pictureTable in _context.ProductPicturetables on productTable.PNumber equals pictureTable.PNumber
                     join orderTable in _context.OrderAssesstables on productTable.PNumber equals orderTable.PNumber
                     select new {
                         groupTable.PNumber,
                         productTable.PName,
                         productTable.PSpec,
                         productTable.PCategory,
                         productTable.PPrice,
                         productTable.PDescribe,
                         productTable.PInventory,
                         productTable.PPayment,
                         pictureTable.PPicnumber,
                         pictureTable.PUrl,
                         groupTable.GPrice,
                         groupTable.GNumber,
                         orderTable.ONumber,
                         orderTable.OCscore
                     };


            //var groups = xx.GroupBy(item => item.PName)
            // .Select(group => group.FirstOrDefault())
            // .ToList();

            var groups = xx.GroupBy(item => item.PName)
               .Select(group => new {
                   PName = group.Key,
                   FirstResult = group.FirstOrDefault(),
                   AverageOCscore = group.Average(item => item.OCscore)
               }).ToList();



			//var groups = _context.ProductGroupViews.ToList();
			groups = groups.Where(x => x.FirstResult.PPicnumber == 1).ToList();

            if (keyWord != null) {
                groups = groups.Where(x => x.PName.Contains(keyWord) && x.FirstResult.PPicnumber == 1).ToList();
            }
            var gpl = groups.OrderBy(p => p?.FirstResult.PPrice).ToList();
            var gph = groups.OrderByDescending(p => p?.FirstResult.PPrice).ToList();
            var gpp = groups.OrderByDescending(p => p.FirstResult.OCscore).ToList();
            ViewBag.ProductDatatablesJoin = groups;
            ViewBag.ProductDatatablesLow = gpl;
            ViewBag.ProductDatatablesHigh = gph;
            ViewBag.ProductDatatablesPT = gpp;
            return View();
        }

        public IActionResult Product() {
            int? pid = Convert.ToInt32(HttpContext.Request.Query["pid"]);
            int? group = Convert.ToInt32(HttpContext.Request.Query["group"]);

            var groups = _context.ProductDatatables.GroupJoin(_context.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData2 = pdt,
                            ProductPic2 = ppt
                        }).ToList().GroupJoin(_context.OrderDatatables,
                        pdtPpt => pdtPpt.ProductData2.PNumber,
                        odt => odt.PNumber, (pdtPpt, odt) =>
                        new {
                            pdtPpt.ProductData2,
                            pdtPpt.ProductPic2,
                            odt
                        }).ToList().GroupJoin(_context.OrderAssesstables,
                        zzz => zzz.ProductData2.PNumber,
                        oat => oat.PNumber, (zzz, oat) => new {
                            ProductData = zzz.ProductData2,
                            ProductPic = zzz.ProductPic2,
                            ProductOdt = zzz.odt,
                            ProductOat = oat.Select(x => x.OCscore).Average()
                        }).ToList();

            //var y = _context.FirmPagetables.FirstOrDefault();
            if (pid != null) {
                groups = groups.Where(x => x.ProductData.PNumber == pid).ToList();
            }
            var fpt = _context.FirmPagetables.Where(x => x.FNumber == groups[0].ProductData.FNumber).FirstOrDefault();
            var gdt = _context.GroupDatatables.Select(x => x.PNumber).ToList();

            var test = _context.GroupDatatables.Where(x=>x.PNumber==pid).Select(x=>x.GPrice).FirstOrDefault();

            int gp = 0;
            for (int i = 0; i < gdt.Count; i++) {
                if (gdt[i] == pid) {
                    gp = 1;
				}
            }
            ViewBag.ProductData = groups;
            ViewBag.FirmData = fpt?.FPagename;
            ViewBag.GroupTF = gp;
            ViewBag.lastPic = groups[0].ProductPic.LastOrDefault();
            ViewBag.GPrice = test;
            return View();
        }
    }
}
