﻿using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using GoSweet.Controllers.feature;
using GoSweet.Models.ViewModels;

namespace GoSweet.Controllers
{
    public class FirmPageController : Controller
    {

        private readonly ShopwebContext _context;
        private readonly IConfiguration _config;

        public FirmPageController(ShopwebContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }
        public IActionResult ProductSale()
        {
            var data = _context.FirmPagetables.Where(x => x.FNumber == 60000).Select(x => x.FPagename).Single();
            var data3 = _context.FirmPagetables.Where(x => x.FNumber == 60000).Select(x => x.FPicurl).Single();

            ViewBag.FirmName = data;
            ViewBag.FirmPic = data3;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ProductSale(ProductDatatable data, GroupDatatable groupdata, List<IFormFile> files, IFormCollection form, FirmPagetable firm, ProductPicturetable picture)
        {
            // 圖片路徑 Start
            // 儲存路徑參數
            var filePath = "";
            ArrayList pathtest = new ArrayList();
            //List<IFormFile>拿出file
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    //設定儲存路徑及檔案名稱
                    filePath = Path.Combine("/img/" + file.FileName);
                    System.Diagnostics.Debug.WriteLine(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //執行檔案複製到本地
                        file.CopyTo(stream);
                        //System.Diagnostics.Debug.WriteLine("wrtie file");
                        stream.Close();
                    }
                    pathtest.Add(filePath);
                }
            }
            // 產生要顯示的string
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var item in pathtest)
            {
                resultBuilder.AppendLine(item.ToString());
                //ViewBag.path = resultBuilder.ToString();
            }
            string resultString = resultBuilder.ToString(); // 把StringBuilder 轉為string
            string[] lines = resultString.Split(Environment.NewLine); // 把string按行分割成數組

            List<string> values = new List<string>(); // 儲存每個行的值的列表
            foreach (var line in lines)
            {
                // 處理每個行的值
                string value = line.Trim(); // 去除行兩端的空格
                values.Add(value); // 将值添加到列表中
            }
            // 圖片路徑 end

            using (var dbContext = new ShopwebContext())
            {
                // 獲取對應的 FirmPagetables 記錄
                var firmAccount = _context.FirmPagetables.SingleOrDefault(x => x.FNumber == 60000);
                if (firmAccount == null)
                {
                    // 處理找不到 Firm_accounttable 記錄的邏輯
                    return BadRequest("找不到對應的 Firm_accounttable 記錄");
                }
                // 建立新的 Product 物件並設定屬性值
                var product = new ProductDatatable
                {
                    PName = data.PName,
                    PCategory = data.PCategory,
                    PDescribe = data.PDescribe,
                    PSavedate = data.PSavedate,
                    PSaveway = data.PSaveway,
                    PPrice = data.PPrice,
                    PInventory = data.PInventory,
                    PSpec = data.PSpec,
                    FNumber = firmAccount.FNumber // 使用獲取到的 FNumber 值
                };

                // 將 Product 物件加入資料庫內容
                _context.Add(product);

                try
                {
                    await _context.SaveChangesAsync();
                    // 成功保存到資料庫的處理邏輯

                    // 確保成功保存並生成了正確的 PNumber 值
                    if (product.PNumber == 0)
                    {
                        // 處理 PNumber 生成錯誤的邏輯
                        return BadRequest("無法生成正確的 PNumber 值");
                    }

                    // 獲取生成的 PNumber
                    int generatedPNumber = product.PNumber;

                    //System.Diagnostics.Debug.WriteLine(generatedPNumber.ToString());

                    var proNum = _context.ProductDatatables.Where(y => y.PName == data.PName).Select(data => data.PNumber).Single();

                    int i = 0;
                    foreach (var valueitem in values)
                    {
                        ProductPicturetable newpic = new ProductPicturetable();
                        if (valueitem != "")
                        {
                            newpic.PUrl = valueitem;
                            newpic.PNumber = (int)proNum;
                            newpic.PPicnumber = i++;
                            //System.Diagnostics.Debug.WriteLine("write pic");
                            _context.Add(newpic);
                        }
                    }

                    // 建立新的 Group 物件並設定屬性值
                    var gobuydata = form["gobuy"];
                    if (gobuydata == "1")
                    {
                        var group = new GroupDatatable
                        {
                            GPrice = groupdata.GPrice,
                            GStart = groupdata.GStart,
                            GEnd = groupdata.GEnd,
                            GMaxpeople = groupdata.GMaxpeople,
                            FNumber = firmAccount.FNumber,
                            PNumber = (int)proNum // 將 Group 關聯到對應的 Product
                        };
                        // 將 Group 物件加入資料庫內容
                        _context.Add(group);


                        // 設置一個標誌值，表示成功寫入資料庫
                        ViewBag.SuccessFlag = true;
                        //}
                    }
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // 處理保存到資料庫失敗的邏輯
                    //Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.Message);
                    return BadRequest("保存到資料庫失敗：" + ex.Message);
                    //return BadRequest("保存到資料庫失敗：" + ex.InnerException.Message);
                }
            }
            // 在前端彈出提示視窗
            //return Content("<script>alert('商品上架完成!'); window.location.href = '/ProductSale';</script>");
            return RedirectToAction("ProductSale", "FirmPage");
            // return View();
        }


        public IActionResult FirmData()
        {
            var data = _context.FirmPagetables.Where(x => x.FNumber == 60000).Select(x => x.FPagename).Single();
            var data2 = _context.FirmPagetables.Where(x => x.FNumber == 60000).Select(x => x.FMessage).Single();
            var data3 = _context.FirmPagetables.Where(x => x.FNumber == 60000).Select(x => x.FPicurl).Single();

            ViewBag.FirmName = data;
            ViewBag.FirmMes = data2;
            ViewBag.FirmPic = data3;

            return View();
        }


        public IActionResult ProductSearch()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult ProductSearch(IFormCollection form)
        //{
        //    string PName = form["PName"];
        //    string PInventorymin = form["PInventory"];
        //    string PInventorymax = form["PInventory[1]"];
        //    string PCategory = form["PCategory"];
        //    //string gobuy = form["gobuy"];
        //    string OBuynumberMin = form["OBuynumber[0]"];
        //    string OBuynumberMax = form["OBuynumber[1]"];

        // 正常可動的
        //var result = (_context.ProductDatatables)
        //   .Where(p => p.PInventory >= int.Parse(PInventorymin) && p.PInventory <= int.Parse(PInventorymax)
        //       && p.PCategory == PCategory)
        //   .Select(p => new {
        //       p.PName,
        //       p.PInventory,
        //       p.PCategory,
        //       p.PPrice
        //   })
        //   .ToList();
        //ViewBag.resultdata = result;

        //var result = (from product in _context.ProductDatatables
        //              //join groupData in _context.GroupDatatables on product.PNumber equals groupData.PNumber
        //              join pic in _context.ProductPicturetables on product.PNumber equals pic.PNumber
        //              //join salenum in _context.OrderDatatables on product.PNumber equals salenum.PNumber
        //              where product.FNumber == 60000 && pic.PPicnumber == 1
        //              //product.PInventory >= int.Parse(PInventorymin) && product.PInventory <= int.Parse(PInventorymax)
        //              //      && product.PCategory == PCategory && pic.PPicnumber == 0
        //              select new
        //              {
        //                  //FirstPUrl = pic.PUrl.First(),
        //                  pic.PUrl,
        //                  product.PName,
        //                  product.PInventory,
        //                  product.PCategory,
        //                  product.PPrice,
        //                  //salenum.OBuynumber,
        //                  //groupData.GStart
        //              });



        //ViewBag.resultdata = result.ToList();



        //var result = (
        //    from p in _context.ProductDatatables
        //    join pic in _context.ProductPicturetables on p.PNumber equals pic.PNumber
        //    join salenum in _context.OrderDatatables on p.PNumber equals salenum.PNumber
        //    where p.PInventory >= int.Parse(PInventorymin) && p.PInventory <= int.Parse(PInventorymax)
        //        && p.PCategory == PCategory
        //        //|| p.PName == PName
        //    select new { 
        //    p.PName,p.PInventory, p.PCategory,p.PPrice
        //    })
        //    .ToList();
        //ViewBag.resultdata = result;

        //return PartialView("ProductSearch", result);
        //}
        public IActionResult Index(string pname, int pmin, int pmax, string pCategory, string groupbuy, int soldmin, int soldmax, int orderby)
        {
            var result = (from product in _context.ProductDatatables
                              //join groupData in _context.GroupDatatables on product.PNumber equals groupData.PNumber
                          join pic in _context.ProductPicturetables on product.PNumber equals pic.PNumber
                          //join salenum in _context.OrderDatatables on product.PNumber equals salenum.PNumber
                          where product.FNumber == 60000 && pic.PPicnumber == 1
                          //product.PInventory >= int.Parse(PInventorymin) && product.PInventory <= int.Parse(PInventorymax)
                          //      && product.PCategory == PCategory && pic.PPicnumber == 0
                          select new
                          {
                              //FirstPUrl = pic.PUrl.First(),
                              pic.PUrl,
                              product.PName,
                              product.PInventory,
                              product.PCategory,
                              product.PPrice,
                              //salenum.OBuynumber,
                              //groupData.GStart
                          });

            if (orderby == 2)
            {
                result = from r in result
                         orderby r.PInventory
                         select r;
            }
            else
            {
                result = from r in result
                         orderby r.PPrice
                         select r;
            }



            return Content(JsonSerializer.Serialize(result));
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(FirmAccountVm firmLoginData)
        {
            if (ModelState.IsValid == false) return View();

            // get database firm account data
            var firmAccountQuery = _context.FirmAccounttables.Where((f) =>
                f.FAccount.Equals(firmLoginData.FAccount) &&
                f.FPassword.Equals(firmLoginData.FPassword)
            ).Select((f) =>
            new
            {
                Account = f.FAccount,
                AccountName = f.FNickname,
                f_number = f.FNumber,
            });

            bool accountNotExist = firmAccountQuery.IsNullOrEmpty();

            if (accountNotExist.Equals(true))
            {
                TempData["firmAccountNotExistMessage"] = "帳號不存在";
                return RedirectToAction("Login");
            }

            var firmAccount = firmAccountQuery.First();

            HttpContext.Session.SetString("firmAccount", firmAccount.AccountName);
            HttpContext.Session.SetString("firmAccountName", firmAccount.AccountName);
            HttpContext.Session.SetString("f_number", Convert.ToString(firmAccount.f_number));
            TempData["firmAccountLoginSuccessMessage"] = "帳號登入成功";

            return RedirectToAction("Homepage","FirmPage");
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(FirmAccountVm firmAccountData)
        {
            if (ModelState.IsValid == false) return View();

            bool accountNotExist = _context.FirmAccounttables.Where((f) =>
                f.FNickname.Equals(firmAccountData.FNickname) &&
                f.FAccount.Equals(firmAccountData.FAccount) &&
                f.FPassword.Equals(firmAccountData.FPassword)
            ).IsNullOrEmpty();

            if (accountNotExist.Equals(false))
            {
                TempData["firmAccountExistMessage"] = "此帳號已被註冊";
                RedirectToAction("SignUp");
                return View();
            }

            try
            {
                CreateFirmAccount(firmAccountData);
                TempData["firmSignUpSuccessMessage"] = "帳號註冊成功";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("SignUp");
        }

        private void CreateFirmAccount(FirmAccountVm firmAccountData)
        {
            FirmAccounttable firmAccount = new FirmAccounttable()
            {
                FNickname = firmAccountData.FNickname,
                FAccount = firmAccountData.FAccount,
                FPassword = firmAccountData.FPassword,
                FMailpass = firmAccountData.FMailpass,
            };
            _context.FirmAccounttables.Add(firmAccount);
            _context.SaveChanges();
        }

        [HttpPost]
        public IActionResult SendMail(string EmailAddress)
        {
            if (ModelState.IsValid == false) return View();

            if (EmailAddress.IsNullOrEmpty())
            {
                return RedirectToAction("Login");
            }

            // 寄送 email 之前先檢查 email 是否存在
            bool frimAccountNotExist = _context.FirmAccounttables.Where(
                c => c.FAccount.Equals(EmailAddress)).IsNullOrEmpty();

            if (frimAccountNotExist.Equals(true))
            {
                TempData["firmAccountNotExistMessage"] = "帳號不存在";
                return RedirectToAction("Login");
            }


            Mail mailHandler = new Mail(EmailAddress, "FirmPage");
            string sendEmailResult = mailHandler.SendMail();
            TempData["sendEmailResultMessage"] = sendEmailResult;


            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string EmailAddress)
        {
            ViewBag.EmailAddress = EmailAddress;
            return View();
        }


        [HttpPost]
        public IActionResult ResetPassword(string EmailAddress, string oldPassword, string newPassword)
        {

            var account = _context.FirmAccounttables.Where((c) => c.FAccount.Equals(EmailAddress)).First();

            try
            {
                account.FPassword = newPassword;
                _context.SaveChanges();
                TempData["resetPasswordSuccessMessage"] = "密碼重置成功";
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Homepage","FirmPage");
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("firmAccountName");
            HttpContext.Session.Remove("firmAccount");
            //HttpContext.Session.SetString("AccountName", String.Empty);
            return RedirectToAction("Homepage", "FirmPage");
        }

    }
}
