using GoSweet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return View();
        }

        //聊天室網頁  客戶用  
        public IActionResult talk_c()
        {
            HttpContext.Session.SetInt32("cnumber",10000);
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
                       select new { fnumber = t.FNumber, fname = f.FPagename, fpic = f.FPicurl };

            return Content(JsonSerializer.Serialize(list));
        }

        //取得聊天內容
        [HttpPost]
        public IActionResult gethistory_c(string talkperson)
        {
            int cnumber = (int)HttpContext.Session.GetInt32("cnumber")!;

            int fnumber = _context.FirmPagetables.Where(x => x.FPagename == talkperson).First().FNumber;
            System.Diagnostics.Debug.WriteLine(talkperson + fnumber);

            var history = from t in _context.TalkDatatables
                          where t.CNumber == cnumber && t.FNumber == fnumber
                          select new { person = cnumber, message = t.TMessage, time = t.TTime.ToString("yyyy-MM-dd HH:mm"), post = t.TPost };


            return Content(JsonSerializer.Serialize(history));
        }

        //取得聊天內容
        [HttpPost]
        public IActionResult postmessage_c(int fnumber,string time,string message)
        {
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




















        public IActionResult talk_f()
        {
            HttpContext.Session.SetInt32("fnumber", 60000);
            return View();
        }


        





























    }
}
