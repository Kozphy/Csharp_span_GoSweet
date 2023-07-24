using GoSweet.Models;
using GoSweet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GoSweet.Models.ViewModels;
using GoSweet.Models;

namespace GoSweet.Controllers
{
    public class FirmController : Controller
    {
        private   readonly ShopwebContext _context;

        public FirmController(ShopwebContext context)
        {
            _context = context;
        }

        public class global
        {
            public static string? StartDateString { get; set; }

            public static string? EndDateString { get; set; }

            public static DateTime Now { get { return DateTime.Now; } }

            public static DateTime StartDate { get; set; }

            public static DateTime EndDate { get; set; }
        }



        public IActionResult Homepage()
        {
            #region 日期參數
            DateTime MonthBegin = global.Now.AddDays(1 - global.Now.Day);
            DateTime LastMonthEnd = global.Now.AddDays(1 - global.Now.Day).AddDays(-1);
            DateTime LastMonthBegin = global.Now.AddDays(1 - global.Now.Day).AddMonths(-1);
            #endregion

            #region 當月訂單數
            string TotalOrders = (from someone in _context.OrderDatatables
                                 where someone.OStart <= global.Now && someone.OStart>=MonthBegin
                                 select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 當月出貨數
            string TotalShipped = (from someone in _context.OrderDatatables
                                   where someone.OStart<=global.Now && someone.OStart>=MonthBegin && someone.OShipstatus.Contains("已")
                                   select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 當月未出貨數
            string TotalunShipped = (from someone in _context.OrderDatatables
                                     where someone.OStart <= global.Now && someone.OStart >= MonthBegin && someone.OShipstatus.Contains("未")
                                     select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 當月總收入
            string TotalThisMonth = (from someone in _context.OrderDatatables
                                     where someone.OStart <= global.Now && someone.OStart >= MonthBegin
                                     select (someone.OBuynumber * someone.OPrice)).Sum().ToString("C0");
            #endregion

            #region 上月訂單數
            string LastMonthTotalOrders = (from someone in _context.OrderDatatables
                                 where someone.OStart <= LastMonthEnd && someone.OStart >= LastMonthBegin
                                 select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 上月出貨數
            string LastMonthTotalShipped = (from someone in _context.OrderDatatables
                                   where someone.OStart <= LastMonthEnd && someone.OStart >= LastMonthBegin && someone.OShipstatus.Contains("已")
                                   select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 上月未出貨數
            string LastMonthTotalunShipped = (from someone in _context.OrderDatatables
                                     where someone.OStart <= LastMonthEnd && someone.OStart >= LastMonthBegin && someone.OShipstatus.Contains("未")
                                     select someone.ONumber).Count().ToString("N0");
            #endregion

            #region 上月總收入
            string TotalLastMonth = (from someone in _context.OrderDatatables
                                     where someone.OStart <= LastMonthEnd && someone.OStart >= LastMonthBegin
                                     select (someone.OBuynumber * someone.OPrice)).Sum().ToString("C0");
            #endregion

            #region 待處理訂單
            var Waitinglist = from O in _context.OrderDatatables
                              join P in _context.ProductDatatables on O.PNumber equals P.PNumber
                              where O.OShipstatus.Contains("未")
                              orderby O.OStart
                              select new WaitingLists
                              {
                                  OrderDate = O.OStart.ToString(),
                                  OrderID = O.ONumber,
                                  Products = P.PName
                              };
            #endregion 直接使用Model

            #region 熱門評論
            var Comment = from someone in _context.OrderAssesstables
                          join something in _context.OrderDatatables on someone.ONumber equals something.ONumber
                          orderby something.OStart descending
                          select new RecentlyComment
                          {
                              CommentDate = something.OStart.ToString(),
                              Content = someone.OCcomment
                          };
            #endregion 預計也是使用Model

            #region 熱門商品
            var Hotsale = from someone in _context.OrderDatatables
                          join something in _context.ProductDatatables on someone.PNumber equals something.PNumber
                          select new { something, someone } into tempTable
                          group tempTable by tempTable.something.PName into TempTable
                          select new HotSales
                          {
                              ProductName = TempTable.FirstOrDefault().something.PName,
                              Quentity = TempTable.Sum(x => x.someone.OBuynumber)
                          };
            Hotsale = Hotsale.OrderByDescending(x => x.Quentity);
            #endregion 預計也是使用Model

            #region 建立Model存放資料
            FirmHomepageModel HomepageModels = new FirmHomepageModel
            {
                //類別賦值-當月訂單
                ThisMonthOrdersTotal = TotalOrders,
                //類別賦值-當月出貨
                ThisMonthShippedTotal = TotalShipped,
                //類別賦值-當月未出貨
                ThisMonthunShippedTotal = TotalunShipped,
                //類別賦值-當月收入
                ThisMonthReveune = TotalThisMonth,
                //類別賦值-上月訂單
                LastMonthOrdersTotal = LastMonthTotalOrders,
                //類別賦值-上月出貨
                LastMonthShippedTotal = LastMonthTotalShipped,
                //類別賦值-上月未出貨
                LastMonthunShippedTotal = LastMonthTotalunShipped,
                //類別賦值-上月收入
                LastMonthReveune = TotalLastMonth,

                //類別賦值-待處理訂單-取前五
                WaitingList = Waitinglist.Take(5).ToList(),

                //類別賦值-熱門評論-取前十
                RecentlyComments = Comment.Take(10).ToList(),

                //類別賦值-熱門商品-取前十
                HotSale = Hotsale.Take(10).ToList(),

                // bell dropdown message
                //FirmBellDropDownDatas = GetBellDropdownMessage()
                
            };
            #endregion


            //HomepageModels.FirmBellDropDownDatas = GetBellDropdownMessage();
            return View(HomepageModels);
        }

        private IEnumerable<FirmBellDropDownVm>? GetBellDropdownMessage()
        {
            string firmAccount = HttpContext.Session.GetString("frimAccount")!;
            if (firmAccount == null)
            {
                return null;
            }

            IEnumerable<FirmBellDropDownVm> firmNotifyMessage =
                (from notify in _context.NotifyDatatables
                 join order in _context.OrderDatatables
                     on notify.ONumber equals order.ONumber
                 join firm in _context.FirmAccounttables
                     on notify.FNumber equals firm.FNumber
                 join product in _context.ProductDatatables
                     on order.PNumber equals product.PNumber
                 where (notify.OStatus == "已下單" || notify.OStatus == "已取貨") && firm.FAccount == firmAccount
                 select new FirmBellDropDownVm
                 {
                     OrderNumber = notify.ONumber,
                     ProductName = product.PName,
                     OrderStatus = order.OStatus,
                 }).ToList();


            //IEnumerable<FirmBellDropDownVm> notifyAlreadyPickUpMessage =
            //                (from notify in _context.NotifyDatatables
            //                 join order in _context.OrderDatatables
            //                     on notify.ONumber equals order.ONumber
            //                 join firm in _context.FirmAccounttables
            //                     on notify.FNumber equals firm.FNumber
            //                 join product in _context.ProductDatatables
            //                     on order.PNumber equals product.PNumber
            //                 where notify.OStatus == "已取貨" && firm.FAccount == firmAccount
            //                 select new FirmBellDropDownVm
            //                 {
            //                     OrderNumber = notify.ONumber,
            //                     ProductName = product.PName,
            //                     OrderStatus = order.OStatus,
            //                 }).ToList();

            return firmNotifyMessage;
        }

        public JsonResult RatingJson() 
        {
            var somebody = (from someone in _context.OrderAssesstables
                            select someone.OCscore).Sum();
            var something = (from someone in _context.OrderAssesstables
							 select someone.OCscore).Count();
            ratingvalue rateValue = new ratingvalue
            {
                ratingScore = somebody,
                ratingQuentity = something
            };

            return Json(rateValue);
		}


		public IActionResult Revenue()
        {

            #region 日期設定
            global.StartDateString = HttpContext.Request.Query["StartDate"];
            global.EndDateString = HttpContext.Request.Query["EndDate"];
            if (global.StartDateString is null && global.EndDateString is null)
            {
                global.StartDate = global.Now.AddMonths(-3);
                global.EndDate = global.Now;
            } else
            {
                global.StartDate = Convert.ToDateTime(global.StartDateString);
                global.EndDate = Convert.ToDateTime(global.EndDateString);
            }
            ViewData["Start"] = global.StartDate.ToString("yyyy-MM-dd");
            ViewData["End"] = global.EndDate.ToString("yyyy-MM-dd");
            #endregion 日期預設跟GET接收

            #region 期間帳務
            var Period = from someone in _context.OrderDatatables
                         where someone.OStart >= global.StartDate && someone.OStart <= global.EndDate
                         select someone.OPrice * someone.OBuynumber;
            //期間結餘
            ViewData["Revenue"] = Period.Sum().ToString("C0");

            // 期間收入
            ViewData["Income"] = Period.Where(Money => Money >= 0).Sum().ToString("C0");

            //期間支出
            ViewData["Expenses"] = Period.Where(Money => Money < 0).Sum().ToString("C0");
            #endregion

            JsonData();
            return View();
        }

        public JsonResult JsonData()
        {
            var somebody = from someone in _context.OrderDatatables
                           join something in _context.ProductDatatables on someone.PNumber equals something.PNumber
                           where someone.OStart >= global.StartDate && someone.OStart< global.EndDate
                           orderby someone.OStart
                           select new RevenueSearch
                           {
                               orderDate = someone.OStart.ToString(),
                               name = something.PName,
                               orderType = someone.OType?"團購":"直購",
                               shipState = someone.OShipstatus,
                               categories = something.PCategory,
                               id = someone.ONumber,
                               quentity = someone.OBuynumber,
                               price = someone.OPrice,
                               total = decimal.Round(someone.OBuynumber * someone.OPrice, 2)
                           };
            return Json(somebody.ToList<RevenueSearch>());
        }
    }
}
