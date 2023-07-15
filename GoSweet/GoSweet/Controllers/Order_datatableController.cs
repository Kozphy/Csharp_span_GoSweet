using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GoSweet.Controllers
{
    public class Order_datatableController : Controller
    {

        private readonly ShopwebContext _context;

        public Order_datatableController(ShopwebContext context)
        {
            _context = context;
        }

        //取得訂單列表
        public IActionResult c_order()
        {
            HttpContext.Session.SetInt32("mycnumber",10000);

            var id = HttpContext.Session.GetInt32("mycnumber");

            var orderdata = from o in _context.OrderDatatables
                            join pic in _context.ProductPicturetables
                            on o.PNumber equals pic.PNumber
                            join f in _context.FirmPagetables
                            on o.FNumber equals f.FNumber
                            join p in _context.ProductDatatables
                            on o.PNumber equals p.PNumber
                            join s in _context.ShipDatatables
                            on o.OShip equals s.ShipNumber
                            join pay in _context.PaymentDatatables
                            on o.OPayment equals pay.PaymentNumber
                            where pic.PPicnumber == 1 && o.CNumber == id
                            orderby o.OStart descending
                            select new
                            {
                                pic = pic.PUrl,
                                fname = f.FPagename,
                                pname = p.PName,
                                pbuy = o.OBuynumber,
                                otype = o.OType,
                                ostatus = o.OStatus,
                                oshipstatus = o.OShipstatus,
                                oplace = o.OPlace,
                                ostart = o.OStart.ToString("yyyy-MM-dd"),
                                oprice = o.OPrice,
                                onumber = o.ONumber,
                                oship = s.ShipName,
                                opay = pay.PaymentName
                            };



            ViewBag.order = orderdata.ToList();

            return View();
        }


        //接收取貨寫入db
        [HttpPost]
        public IActionResult orderdone(int onumber, string end)
        {


            var getorder = from o in _context.OrderDatatables
                           where o.ONumber == onumber
                           select o;
            if (getorder.FirstOrDefault() == null)
            {
                return Content("order is null");
            }

            getorder.First().OEnd = DateTime.Parse(end);
            getorder.First().OStatus = "已結單";
            getorder.First().OShipstatus = "已取貨";
            _context.Update(getorder.First());
            _context.SaveChanges();


            return Content("orderdone is write to db");
        }

        //查詢評分資料
        [HttpPost]
        public IActionResult getassess(int onumber)
        {
            if (_context.OrderAssesstables.Where(x => x.ONumber == onumber).FirstOrDefault() == null)
            {
                return Content("null");
            }

            var myassess = from o in _context.OrderAssesstables
                           where o.ONumber == onumber
                           select new { ocs = o.OCscore, ocm = o.OCcomment, ofs = o.OFscore, ofm = o.OFcomment };



            return Content(JsonSerializer.Serialize(myassess));
        }
        //寫入客戶評分資料
        [HttpPost]
        public IActionResult setassess(int onumber, float ocs, string ocm)
        {
            if (_context.OrderAssesstables.Where(x => x.ONumber == onumber).FirstOrDefault() == null)
            {
                OrderAssesstable myassess = new OrderAssesstable();
                myassess.ONumber = onumber;
                myassess.OCscore = ocs;
                myassess.OCcomment = ocm;
                _context.Add(myassess);
                _context.SaveChanges();

                return Content("assess add to db ");
            }
            else
            {
                var myassess = from o in _context.OrderAssesstables
                               where o.ONumber == onumber
                               select o;
                myassess.First().OCscore = ocs;
                myassess.First().OCcomment = ocm;
                _context.Update(myassess.First());
                _context.SaveChanges();

                return Content("assess update to db ");
            }

        }



        //新增talk member到db
        [HttpPost]
        public IActionResult gotalk(int onumber)
        {


            int cnumber = (int)HttpContext.Session.GetInt32("mycnumber")!;

            int fnumber = _context.OrderDatatables.Where(x => x.ONumber == onumber).First().FNumber;

            var memberinlist = from t in _context.TalkMembertables
                               where t.CNumber == cnumber && t.FNumber == fnumber
                               select t;
            if (memberinlist.FirstOrDefault() == null)
            {
                TalkMembertable member = new TalkMembertable();
                member.CNumber = cnumber;
                member.FNumber = fnumber;
                _context.Add(member);
                _context.SaveChanges();

                return Content("talk memeber add to db");
            }

            return Content("talk memeber in list");
        }





        //取得廠商訂單資料  訂單網頁使用者為廠商
        public IActionResult f_order()
        {
            HttpContext.Session.SetInt32("myfnumber",60000);

            var id = HttpContext.Session.GetInt32("myfnumber");

            var orderdata = from o in _context.OrderDatatables
                            join pic in _context.ProductPicturetables
                            on o.PNumber equals pic.PNumber
                            join c in _context.CustomerAccounttables
                            on o.CNumber equals c.CNumber
                            join p in _context.ProductDatatables
                            on o.PNumber equals p.PNumber
                            join s in _context.ShipDatatables
                            on o.OShip equals s.ShipNumber
                            join pay in _context.PaymentDatatables
                            on o.OPayment equals pay.PaymentNumber
                            where  o.FNumber == id && pic.PPicnumber == 1 && (o.OStatus == "已下單" || o.OStatus == "已結單")
                            orderby o.OStart descending
                            select new
                            {
                                pic = pic.PUrl,
                                cname = c.CNickname,
                                pname = p.PName,
                                pbuy = o.OBuynumber,
                                otype = o.OType,
                                ostatus = o.OStatus,
                                oshipstatus = o.OShipstatus,
                                oplace = o.OPlace,
                                ostart = o.OStart.ToString("yyyy-MM-dd"),
                                oprice = o.OPrice,
                                onumber = o.ONumber,
                                oship = s.ShipName,
                                opay = pay.PaymentName
                            };



            ViewBag.order2 = orderdata.ToList();
            System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(orderdata));
            return View();
        }


        //接收出貨寫入db 訂單網頁使用者為廠商
        [HttpPost]
        public IActionResult orderdone2(int onumber)
        {


            var getorder = from o in _context.OrderDatatables
                           where o.ONumber == onumber
                           select o;
            if (getorder.FirstOrDefault() == null)
            {
                return Content("order is null");
            }

            getorder.First().OShipstatus = "已寄出";
            _context.Update(getorder.First());
            _context.SaveChanges();


            return Content("orderdone is write to db");
        }


        //查詢評分資料  訂單網頁使用者為廠商
        [HttpPost]
        public IActionResult getassess2(int onumber)
        {
            if (_context.OrderAssesstables.Where(x => x.ONumber == onumber).FirstOrDefault() == null)
            {
                return Content("null");
            }

            var myassess = from o in _context.OrderAssesstables
                           where o.ONumber == onumber
                           select new { ocs = o.OCscore, ocm = o.OCcomment, ofs = o.OFscore, ofm = o.OFcomment };



            return Content(JsonSerializer.Serialize(myassess));
        }



        //寫入廠商評分資料  訂單網頁使用者為廠商
        [HttpPost]
        public IActionResult setassess2(int onumber, float ofs, string ofm)
        {
            if (_context.OrderAssesstables.Where(x => x.ONumber == onumber).FirstOrDefault() == null)
            {
                OrderAssesstable myassess = new OrderAssesstable();
                myassess.ONumber = onumber;
                myassess.OFscore = ofs;
                myassess.OFcomment = ofm;
                _context.Add(myassess);
                _context.SaveChanges();

                return Content("assess add to db ");
            }
            else
            {
                var myassess = from o in _context.OrderAssesstables
                               where o.ONumber == onumber 
                               select o;
                myassess.First().OFscore = ofs;
                myassess.First().OFcomment = ofm;
                _context.Update(myassess.First());
                _context.SaveChanges();

                return Content("assess update to db ");
            }

        }

        //新增talk member到db  訂單網頁使用者為廠商
        [HttpPost]
        public IActionResult gotalk2(int onumber)
        {


            int fnumber = (int)HttpContext.Session.GetInt32("myfnumber")!;

            int cnumber = _context.OrderDatatables.Where(x => x.ONumber == onumber).First().CNumber;

            var memberinlist = from t in _context.TalkMembertables
                               where t.CNumber == cnumber && t.FNumber == fnumber
                               select t;
            if (memberinlist.FirstOrDefault() == null)
            {
                TalkMembertable member = new TalkMembertable();
                member.CNumber = cnumber;
                member.FNumber = fnumber;
                _context.Add(member);
                _context.SaveChanges();

                return Content("talk memeber add to db");
            }

            return Content("talk memeber in list");
        }

    }
}
