using AngleSharp.Browser.Dom;
using GoSweet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.Json;

namespace GoSweet.Controllers
{
    public class Talk_datatableController : Controller
    {
        public readonly ShopwebContext _context;
        public Talk_datatableController(ShopwebContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var read = from t in _context.TalkDatatables
                       where t.CNumber == 10000 && t.FNumber == 60000 && t.TPost == 1
                       select t;


            return Content(JsonSerializer.Serialize(read));
        }


        public IActionResult talk()
        {

            if (HttpContext.Session.GetInt32("cnumber") != null)
            {
                return RedirectToAction("talk_c", "Talk_datatable");
            }
            else if (HttpContext.Session.GetInt32("fnumber") != null)
            {
                return RedirectToAction("talk_f", "Talk_datatable");
            }


            return Content("no http session");
        }

        //聊天室網頁  客戶用  
        public IActionResult talk_c()
        {
            //HttpContext.Session.SetInt32("cnumber",10000);
            return View();
        }


        //取得聊天名單
        [HttpGet]
        public IActionResult getlist_c()
        {
            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;




            var list = from t in _context.TalkMembertables
                       join f in _context.FirmPagetables
                       on t.FNumber equals f.FNumber
                       where t.CNumber == cnumber
                       select new { fnumber = t.FNumber, fname = f.FPagename, fpic = f.FPicurl , noread =0 };




            return Content(JsonSerializer.Serialize(list));
        }

        //取得未讀數量
        [HttpGet]
        public IActionResult getnoread_c()
        {
            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;


            var noreadlist = from t in _context.TalkDatatables
                             where t.CNumber == cnumber && t.TPost == 1
                             group t by new { fnumber = t.FNumber } into t2
                             select new { fnumber = t2.Key.fnumber, noread = t2.Sum(x => x.TRead) };






            return Content(JsonSerializer.Serialize(noreadlist));
        }


        //取得聊天歷史傳到前端
        [HttpPost]
        public IActionResult gethistory_c(string fname)
        {
            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;

            int fnumber = _context.FirmPagetables.Where(x => x.FPagename == fname).First().FNumber;
            System.Diagnostics.Debug.WriteLine(fname + fnumber);

            var history = from t in _context.TalkDatatables
                          where t.CNumber == cnumber && t.FNumber == fnumber
                          select new {  message = t.TMessage, time = t.TTime.ToString("yyyy-MM-dd HH:mm"), post = t.TPost };

            


            return Content(JsonSerializer.Serialize(history));
        }

        //取得聊天內容寫入db
        [HttpPost]
        public IActionResult postmessage_c(int fnumber,string time,string message)
        {
            if (fnumber == 0)
            {
                return Content(" postmessage_c fail fnumber is 0");
            }

            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;


            TalkDatatable talk = new TalkDatatable();

            talk.CNumber = cnumber;
            talk.FNumber = fnumber;
            talk.TTime= DateTime.Parse(time);
            talk.TMessage = message;
            talk.TRead = 1;
            talk.TPost = 0;
            _context.Add(talk);
            _context.SaveChanges();

            return Content("postmessage write to db");
        }



        //將編號及uid寫入資料庫
        [HttpPost]
        public string chatid_c( string uid)
        {
            TalkPersontable person = new TalkPersontable();
            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;

            person.CNumber = cnumber;
            person.TId = uid;
            var getuid = from t in _context!.TalkPersontables
                         where t.CNumber == cnumber
                         select t;
            if (getuid.FirstOrDefault() == null)
            {
                _context.Add(person);
                _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("add CNumber to db");
            }
            else
            {
                getuid.First().TId = uid;
                _context.Update(getuid.First());
                _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Update CNumber to db");
            }

            return "uid update";
        }



        //已讀聊天室內容
        [HttpPost]
        public IActionResult read_c(int fnumber)
        {
            if (fnumber == 0) {
                return Content("read_c fail fnumber is 0");
            }

            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;


             var read = from t in _context.TalkDatatables
                        where t.CNumber == cnumber && t.FNumber == fnumber && t.TPost==1
                        select t;
            foreach (var item in read)
            {
                item.TRead = 0;
                _context.Update(item);
            }
            
            _context.SaveChanges();


            return Content("read  message");
        }




















        //聊天室網頁  廠商用 
        public IActionResult talk_f()
        {
            //HttpContext.Session.SetInt32("fnumber", 60000);
            return View();
        }






        //取得聊天名單
        [HttpGet]
        public IActionResult getlist_f()
        {
            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;





            var list = from t in _context.TalkMembertables
                       join c in _context.CustomerAccounttables
                       on t.CNumber equals c.CNumber
                       where t.FNumber == fnumber
                       select new { cnumber = t.CNumber, cname = c.CNickname, noread =0 };

            return Content(JsonSerializer.Serialize(list));
        }

        //取得未讀數量
        [HttpGet]
        public IActionResult getnoread_f()
        {
            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;


            var noreadlist = from t in _context.TalkDatatables
                             where t.FNumber == fnumber && t.TPost == 0
                             group t by new { cnumber = t.CNumber } into t2
                             select new { cnumber = t2.Key.cnumber, noread = t2.Sum(x => x.TRead) };






            return Content(JsonSerializer.Serialize(noreadlist));
        }


        //取得聊天歷史傳到前端
        [HttpPost]
        public IActionResult gethistory_f(int cnumber)
        {
            if (cnumber == 0) {
                return Content("gethistory_f fail cnumber is 0");
            }

            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;

            

            var history = from t in _context.TalkDatatables
                          where t.CNumber == cnumber && t.FNumber == fnumber
                          select new { message = t.TMessage, time = t.TTime.ToString("yyyy-MM-dd HH:mm"), post = t.TPost };


            return Content(JsonSerializer.Serialize(history));
        }

        //取得聊天內容寫入db
        [HttpPost]
        public IActionResult postmessage_f(int cnumber, string time, string message)
        {

            if (cnumber == 0)
            {
                return Content("postmessage_f fail cnumber is 0");
            }
            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;


            TalkDatatable talk = new TalkDatatable();

            talk.CNumber = cnumber;
            talk.FNumber = fnumber;
            talk.TTime = DateTime.Parse(time);
            talk.TMessage = message;
            talk.TRead = 1;
            talk.TPost = 1;
            _context.Add(talk);
            _context.SaveChanges();

            return Content("postmessage write to db");
        }



        //將編號及uid寫入資料庫
        [HttpPost]
        public string chatid_f( string uid)
        {
            TalkPersontable person = new TalkPersontable();

            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;

            person.FNumber = fnumber;
            person.TId = uid;
            var getuid = from t in _context!.TalkPersontables
                         where t.FNumber == fnumber
                         select t;
            if (getuid.FirstOrDefault() == null)
            {

                _context.Add(person);
                _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("add FNumber to db");
            }
            else
            {
                getuid.First().TId = uid;
                _context.Update(getuid.First());
                _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Update FNumberto db");
            }


            return "uid update";
        }



        //已讀聊天室內容
        [HttpPost]
        public IActionResult read_f(int cnumber)
        {

            if (cnumber == 0)
            {
                return Content("read_f fail cnumber is 0");
            }
            int fnumber = (int)HttpContext.Session.GetInt32("fnumber")!;


            var read = from t in _context.TalkDatatables
                       where t.CNumber == cnumber && t.FNumber == fnumber && t.TPost == 0
                       select t;
            foreach (var item in read)
            {
                item.TRead = 0;
                _context.Update(item);
            }

            _context.SaveChanges();


            return Content("read  message");
        }







        //聊天室網頁  廠商與客戶共用 
        public IActionResult getsendid(int sendnumber)
        {
            if (sendnumber == 0)
            {
                return Content("getsendid fail sendnumber is 0");
            }

            var sendid = from t in _context.TalkPersontables
                         where sendnumber == t.CNumber || sendnumber == t.FNumber
                         select new { id = t.TId };
            

            return Content(JsonSerializer.Serialize(sendid));
        }













    }
}
