using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography.Xml;

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
            var groups = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData = pdt,
                            ProductPic = ppt
                        }).ToList();
            if (x != null) {
                int pid = int.Parse(x);
                groups = groups.Where(x => x.ProductData.PNumber == pid).ToList();
            }
            ViewBag.ProductData = groups;
            ViewBag.buyNum = y;
            return View();
        }

        [HttpPost]
        public ActionResult BuyList(IFormCollection form) {


			int id = Convert.ToInt32(HttpContext.Session.GetInt32("mycnumber")); ;
            
			if (form != null) {
                var result = new OrderDatatable();
                result.OStart = DateTime.Now;
                //result.CNumber = Convert.ToInt32(form["CNumber"]);
				result.CNumber = id;
				result.FNumber = Convert.ToInt32(form["FNumber"]);
                result.PNumber = Convert.ToInt32(form["PNumber"]);
                result.OBuynumber = Convert.ToInt32(form["OBuynumber"]);
                result.OType = false;
                result.OPrice = Convert.ToInt32(form["OPrice"]);
                result.OStatus = "已下單";
                result.OShip = Convert.ToInt32(form["Delivery"]);
                result.OPayment = Convert.ToInt32(form["Payment"]);
                result.OPlace = form["OPlace"];
                result.OShipstatus = "未寄出";
                _shopwebContext.Add(result);
                _shopwebContext.SaveChanges();


                //下單成功後 加入notify通知給廠商
                var getneworder = from o in _shopwebContext.OrderDatatables
                                  orderby o.ONumber descending
                                  select o;

                NotifyDatatable notify = new NotifyDatatable();
                notify.FNumber = getneworder.First().FNumber;
                notify.ONumber = getneworder.First().ONumber;
                notify.OStatus = getneworder.First().OStatus;
                notify.NRead = false;
                _shopwebContext.Update(notify);
                _shopwebContext.SaveChanges();


                return Redirect("/home/index");
            }
            return View();
        }


        public async Task<IActionResult> BuyListGroup() {

            int? pid = Convert.ToInt32(HttpContext.Request.Query["pid"]);
            int num = Convert.ToInt32(HttpContext.Request.Query["num"]);
            int mmt = Convert.ToInt32(HttpContext.Request.Query["mmt"]);

			
			int id = Convert.ToInt32(HttpContext.Session.GetInt32("mycnumber"));

			var groups = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData = pdt,
                            ProductPic = ppt
                        }).ToList();
            groups = groups.Where(x => x.ProductData.PNumber == pid).ToList();
            // var gdtg = _shopwebContext.GroupDatatables.GroupJoin(_shopwebContext.MemberMembertables,
            //     gdt => gdt.GNumber,
            //     mmt => mmt.GNumber, (gdt, mmt) => new {
            //         GroupDatatable = gdt,
            //         //MemberMembertable = mmt.Select(x => x.MNumber).Single()
            //         MemberMembertable = mmt
            //     }).ToList();
            //// var values = gdtg[0].MemberMembertable.FirstOrDefault().MStatus;
            // gdtg = gdtg.Where(x => x.GroupDatatable.PNumber == pid).ToList();
            //gdtg = gdtg.Where(x => x.GroupDatatable.PNumber == pid && !x.MemberMembertable.MStatus).ToList();
            //if (gdtg.Count > 0) {
            //    gdtg = gdtg.Where(x => x.MemberMembertable.FirstOrDefault().MStatus = false).ToList();
            //}


            var gdtg = _shopwebContext.GroupDatatables
                            .GroupJoin(_shopwebContext.MemberMembertables,
                                gdt => gdt.GNumber,
                                mmt => mmt.GNumber,
                                (gdt, mmt) => new {
                                    GroupDatatable = gdt,
                                    MemberMembertable = mmt
                                })
                            .Where(x => x.GroupDatatable.PNumber == pid)
                            .ToList();


            var x = _shopwebContext.MemberMembertables.
                Where(x => x.GNumber == gdtg[0].GroupDatatable.GNumber)
                .OrderByDescending(x => x.MNumber).
                Select(x => x).ToList();


            if (x[0].MStatus == false) {
				MemberMembertable? updateNewMMT = _shopwebContext.MemberMembertables
					.FirstOrDefault(qqq => qqq.MNumber == gdtg[0].MemberMembertable.Select(x => x.MNumber)
					.LastOrDefault());
				if (updateNewMMT != null) {
					updateNewMMT.MNowpeople++;
					_shopwebContext.Update(updateNewMMT);
					await _shopwebContext.SaveChangesAsync();

                    //member滿人判斷 後 修改訂單狀態 並新增 notify
                    int mymnumber = gdtg[0].MemberMembertable.Select(x => x.MNumber)
                        .FirstOrDefault();
                    var membermax = from m in _shopwebContext.MemberMembertables
                                    where m.MNumber == mymnumber && m.GMaxpeople == m.MNowpeople
                                    select m;
                    if ((membermax.FirstOrDefault() != null) && (membermax.First().MStatus == false))
                    {
                        membermax.First().MStatus = true;
                        _shopwebContext.Update(membermax.First());
                        _shopwebContext.SaveChanges();
                        var orderlist = from o in _shopwebContext.OrderDatatables
                                        where o.MNumber == mymnumber
                                        select o;

                        foreach (var item in orderlist)
                        {
                            item.OStatus = "已成團";
                            _shopwebContext.Update(item);

                            NotifyDatatable notify = new NotifyDatatable();
                            notify.CNumber = item.CNumber;
                            notify.ONumber = item.ONumber;
                            notify.OStatus = item.OStatus;
                            notify.NRead = false;
                            _shopwebContext.Update(notify);

                        }
                        _shopwebContext.SaveChanges();

                    }
                    //member滿人判斷 後 修改訂單狀態 並新增 notify 完畢	

                }
            } else {
				var addNewMMT = new MemberMembertable();
				addNewMMT.GNumber = gdtg[0].GroupDatatable.GNumber;
				addNewMMT.GMaxpeople = x[0].GMaxpeople;
				addNewMMT.MNowpeople = 1;
				addNewMMT.MStatus = false;
				_shopwebContext.Add(addNewMMT);
				_shopwebContext.SaveChanges();
			}


                

            var result2 = new OrderDatatable();
            result2.OStart = DateTime.Now;
            result2.CNumber = id;
            result2.FNumber = groups[0].ProductData.FNumber;
            result2.PNumber = groups[0].ProductData.PNumber;
            result2.OBuynumber = num;
            result2.OType = true;
            result2.MNumber = Convert.ToInt32(gdtg[0].MemberMembertable.Select(x => x.MNumber).FirstOrDefault());
            result2.OPrice = groups[0].ProductData.PNumber;
            result2.OStatus = "待成團";
            result2.OShipstatus = "未寄出";
            _shopwebContext.Add(result2);
            _shopwebContext.SaveChanges();

            ViewBag.ProductData = groups;
            ViewBag.num = num;
            ViewBag.total = groups[0].ProductData.PPrice * num;

            return View();
        }

        [HttpGet]
        public IActionResult BuyListGp() {
            string? x = HttpContext.Request.Query["pid"];
            string? y = HttpContext.Request.Query["num"];
            int num = 0;
            if (y != null) {
                num = int.Parse(y);
            }
            var groups = _shopwebContext.ProductDatatables.GroupJoin(_shopwebContext.ProductPicturetables,
                        pdt => pdt.PNumber,
                        ppt => ppt.PNumber,
                        (pdt, ppt) => new {
                            ProductData = pdt,
                            ProductPic = ppt
                        }).ToList();
            int pid = 0;
            if (x != null) {
                pid = int.Parse(x);
                groups = groups.Where(x => x.ProductData.PNumber == pid).ToList();
            }
            var xxgp = _shopwebContext.GroupDatatables.Where(p => p.PNumber == pid).Select(p => p.GPrice).FirstOrDefault();

            ViewBag.ProductData = groups;
            ViewBag.GPrice = xxgp;
            ViewBag.buyNum = num;
            return View();
        }

        [HttpPost]
        public ActionResult BuyListgp(IFormCollection form) {
			

			int id =Convert.ToInt32(HttpContext.Session.GetInt32("mycnumber"));

			if (form != null) {
                var result = new OrderDatatable();
                result.OStart = DateTime.Now;
                //result.CNumber = Convert.ToInt32(form["CNumber"]);
				result.CNumber = id;
				result.FNumber = Convert.ToInt32(form["FNumber"]);
                result.PNumber = Convert.ToInt32(form["PNumber"]);
                result.OBuynumber = Convert.ToInt32(form["OBuynumber"]);
                result.OType = true;
                result.OPrice = Convert.ToInt32(form["OPrice"]);
                result.OStatus = "已下單";
                result.OShip = Convert.ToInt32(form["Delivery"]);
                result.OPayment = Convert.ToInt32(form["Payment"]);
                result.OPlace = form["OPlace"];
                result.OShipstatus = "未寄出";
                _shopwebContext.Add(result);
                _shopwebContext.SaveChanges();

                return Redirect("/home/index");
            }
            return View();
        }
    }
}
