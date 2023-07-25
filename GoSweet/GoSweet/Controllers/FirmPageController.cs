using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            var data = _context.FirmPagetables.Where(x => x.FNumber == FirmNumber).Select(x => x.FPagename).Single();
            var data3 = _context.FirmPagetables.Where(x => x.FNumber == FirmNumber).Select(x => x.FPicurl).Single();

            ViewBag.FirmName = data;
            ViewBag.FirmPic = data3;

            return View();
        }
        //商品上架要用的
        [HttpPost]
        public async Task<ActionResult> ProductSale(ProductDatatable data, GroupDatatable groupdata, List<IFormFile> files, IFormCollection form, FirmPagetable firm, ProductPicturetable picture)
        {
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            // 圖片路徑 Start
            // 儲存路徑參數
            var filePath = "";
            string mypath = "";
            ArrayList pathtest = new ArrayList();
            //List<IFormFile>拿出file
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    //設定儲存路徑及檔案名稱
                    filePath = Path.Combine("./wwwroot/img/ProductUrl/" + file.FileName);
                    System.Diagnostics.Debug.WriteLine(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //執行檔案複製到本地
                        file.CopyTo(stream);
                        //System.Diagnostics.Debug.WriteLine("wrtie file");
                    }
                    // 可以在此处进行进一步的处理或保存文件路径到数据库等
                    mypath = filePath.Substring(9, filePath.Length - 9);
                    pathtest.Add(mypath);
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
                var firmAccount = _context.FirmPagetables.SingleOrDefault(x => x.FNumber == FirmNumber);
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

                    int i = 1;
                    foreach (var valueitem in values)
                    {
                        ProductPicturetable newpic = new ProductPicturetable();
                        if (valueitem != "")
                        {
                            newpic.PUrl = valueitem;
                            newpic.PNumber = (int)proNum;
                            newpic.PPicnumber = i++;
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
                        TempData["SuccessFlag"] = true;
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
            //return RedirectToAction("ProductSale", "FirmPage");
            return RedirectToAction("ProductSearch", "FirmPage");
            //return View();
        }

        public IActionResult FirmData()
        {
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            var data = _context.FirmPagetables.Where(x => x.FNumber == FirmNumber).Select(x => x.FPagename).Single();
            var data2 = _context.FirmPagetables.Where(x => x.FNumber == FirmNumber).Select(x => x.FMessage).Single();
            var data3 = _context.FirmPagetables.Where(x => x.FNumber == FirmNumber).Select(x => x.FPicurl).Single();

            ViewBag.FirmName = data;
            ViewBag.FirmMes = data2;
            ViewBag.FirmPic = data3;

            return View();
        }


        public IActionResult ProductSearch()
        {
            return View();
        }

        //團購table要用的
        public IActionResult Index(string pname, int pmin, int pmax, string pCategory, string groupbuy, int soldmin, int soldmax, int orderby)
        {
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            var result = (from product in _context.ProductDatatables
                          join groupData in _context.GroupDatatables on product.PNumber equals groupData.PNumber
                          join pic in _context.ProductPicturetables on product.PNumber equals pic.PNumber
                          where product.FNumber == FirmNumber && pic.PPicnumber == 1
                          select new
                          {
                              pic.PUrl,
                              product.PName,
                              product.PInventory,
                              product.PCategory,
                              product.PPrice,
                              pnumber = product.PNumber,
                              soldnumber = 0,
                              groupData.GPrice,
                              groupData.GStart,
                              groupData.GEnd,
                          });

            // 根據填寫的欄位內容構造 where 條件
            if (!string.IsNullOrEmpty(pname))
            {
                result = result.Where(product => product.PName.Contains(pname));
            }

            if (pmin >= 0 && pmax > 0)
            {
                result = result.Where(product => product.PInventory >= pmin && product.PInventory <= pmax);
            }

            if (!string.IsNullOrEmpty(pCategory) && pCategory != "全部")
            {
                result = result.Where(product => product.PCategory == pCategory);
            }

            if (orderby == 2)
            {
                result = result.OrderBy(product => product.PInventory);
            }
            else if (orderby == 3)
            {
                result = result.OrderBy(product => product.soldnumber).ThenBy(product => product.PPrice);
            }
            else
            {
                result = result.OrderBy(product => product.PPrice);
            }

            return Content(JsonSerializer.Serialize(result));
        }

        //一般全部商品table要用的
        public IActionResult IndexWithoutJoin(string pname, int pmin, int pmax, string pCategory, string groupbuy, int soldmin, int soldmax, int orderby)
        {
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            var result = (from product in _context.ProductDatatables
                          join pic in _context.ProductPicturetables on product.PNumber equals pic.PNumber
                          where product.FNumber == FirmNumber && pic.PPicnumber == 1
                          select new
                          {
                              pic.PUrl,
                              product.PName,
                              product.PInventory,
                              product.PCategory,
                              product.PPrice,
                              pnumber = product.PNumber,
                              soldnumber = 0
                          });

            // 根據填寫的欄位內容構造 where 條件
            if (!string.IsNullOrEmpty(pname))
            {
                result = result.Where(product => product.PName.Contains(pname));
            }

            if (pmin >= 0 && pmax > 0)
            {
                result = result.Where(product => product.PInventory >= pmin && product.PInventory <= pmax);
            }

            if (!string.IsNullOrEmpty(pCategory) && pCategory != "全部")
            {
                result = result.Where(product => product.PCategory == pCategory);
            }

            if (orderby == 2)
            {
                result = result.OrderBy(product => product.PInventory);
            }
            else if (orderby == 3)
            {
                result = result.OrderBy(product => product.soldnumber).ThenBy(product => product.PPrice);
            }
            else
            {
                result = result.OrderBy(product => product.PPrice);
            }

            return Content(JsonSerializer.Serialize(result));
        }

        //售出數量要用的
        public IActionResult index2()
        {
            //HttpContext.Session.SetInt32("firmNumber", 60000);
            var FirmNumber = HttpContext.Session.GetInt32("firmNumber");

            var soldlist = from o in _context.OrderDatatables
                           where o.FNumber == FirmNumber
                           group o by o.PNumber into o2
                           select new { pnumber = o2.Key, soldnumber = o2.Sum(x => x.OBuynumber) };

            return Content(JsonSerializer.Serialize(soldlist));
        }
        // GET: ProductDatatables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductDatatables == null)
            {
                return NotFound();
            }

            var productDatatable = await _context.ProductDatatables.FindAsync(id);
            if (productDatatable == null)
            {
                return NotFound();
            }
            ViewData["FNumber"] = new SelectList(_context.FirmAccounttables, "FNumber", "FNumber", productDatatable.FNumber);
            return View(productDatatable);
        }

        // POST: ProductDatatables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FNumber,PNumber,PName,PSpec,PCategory,PPrice,PDescribe,PSavedate,PSaveway,PInventory,PShip,PPayment")] ProductDatatable productDatatable)
        {
            if (id != productDatatable.PNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDatatable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ProductDatatableExists(productDatatable.PNumber))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FNumber"] = new SelectList(_context.FirmAccounttables, "FNumber", "FNumber", productDatatable.FNumber);
            return View(productDatatable);
        }

        // GET: ProductDatatables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductDatatables == null)
            {
                return NotFound();
            }

            var productDatatable = await _context.ProductDatatables
                .Include(p => p.FNumberNavigation)
                .FirstOrDefaultAsync(m => m.PNumber == id);
            if (productDatatable == null)
            {
                return NotFound();
            }

            return View(productDatatable);
        }
        // POST: ProductDatatables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductDatatables == null)
            {
                return Problem("Entity set 'ShopwebContext.ProductDatatables'  is null.");
            }
            var productDatatable = await _context.ProductDatatables.FindAsync(id);
            if (productDatatable != null)
            {
                _context.ProductDatatables.Remove(productDatatable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(FirmAccountVm firmLoginData)
        //{
        //    if (ModelState.IsValid == false) return View();

        //    // get database firm account data
        //    var firmAccountQuery = _context.FirmAccounttables.Where((f) =>
        //        f.FAccount.Equals(firmLoginData.FAccount) &&
        //        f.FPassword.Equals(firmLoginData.FPassword)
        //    ).Select((f) =>
        //    new
        //    {
        //        Account = f.FAccount,
        //        AccountName = f.FNickname,
        //        f_number = f.FNumber,
        //    });

        //    bool accountNotExist = firmAccountQuery.IsNullOrEmpty();

        //    if (accountNotExist.Equals(true))
        //    {
        //        TempData["firmAccountNotExistMessage"] = "帳號不存在";
        //        return RedirectToAction("Login");
        //    }

        //    var firmAccount = firmAccountQuery.First();

        //    HttpContext.Session.SetString("firmAccount", firmAccount.Account);
        //    HttpContext.Session.SetString("firmAccountName", firmAccount.AccountName);
        //    HttpContext.Session.SetString("f_number", Convert.ToString(firmAccount.f_number));
        //    TempData["firmAccountLoginSuccessMessage"] = "帳號登入成功";

        //    return RedirectToAction("Homepage","Firm");
        //}


        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult SignUp(FirmAccountVm firmAccountData)
        //{
        //    if (ModelState.IsValid == false) return View();

        //    bool accountNotExist = _context.FirmAccounttables.Where((f) =>
        //        f.FNickname.Equals(firmAccountData.FNickname) &&
        //        f.FAccount.Equals(firmAccountData.FAccount) &&
        //        f.FPassword.Equals(firmAccountData.FPassword)
        //    ).IsNullOrEmpty();

        //    if (accountNotExist.Equals(false))
        //    {
        //        TempData["firmAccountExistMessage"] = "此帳號已被註冊";
        //        RedirectToAction("SignUp");
        //        return View();
        //    }

        //    try
        //    {
        //        CreateFirmAccount(firmAccountData);
        //        TempData["firmSignUpSuccessMessage"] = "帳號註冊成功";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    return RedirectToAction("SignUp");
        //}

        //private void CreateFirmAccount(FirmAccountVm firmAccountData)
        //{
        //    FirmAccounttable firmAccount = new FirmAccounttable()
        //    {
        //        FNickname = firmAccountData.FNickname,
        //        FAccount = firmAccountData.FAccount,
        //        FPassword = firmAccountData.FPassword,
        //        FMailpass = firmAccountData.FMailpass,
        //    };
        //    _context.FirmAccounttables.Add(firmAccount);
        //    _context.SaveChanges();
        //}

        //[HttpPost]
        //public IActionResult SendMail(string EmailAddress)
        //{
        //    if (ModelState.IsValid == false) return View();

        //    if (EmailAddress.IsNullOrEmpty())
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // 寄送 email 之前先檢查 email 是否存在
        //    bool frimAccountNotExist = _context.FirmAccounttables.Where(
        //        c => c.FAccount.Equals(EmailAddress)).IsNullOrEmpty();

        //    if (frimAccountNotExist.Equals(true))
        //    {
        //        TempData["firmAccountNotExistMessage"] = "帳號不存在";
        //        return RedirectToAction("Login");
        //    }


        //    Mail mailHandler = new Mail(EmailAddress, "FirmPage");
        //    string sendEmailResult = mailHandler.SendMail();
        //    TempData["sendEmailResultMessage"] = sendEmailResult;


        //    return RedirectToAction("Login");
        //}

        //public IActionResult ResetPassword(string EmailAddress)
        //{
        //    ViewBag.EmailAddress = EmailAddress;
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult ResetPassword(string EmailAddress, string oldPassword, string newPassword)
        //{

        //    var account = _context.FirmAccounttables.Where((c) => c.FAccount.Equals(EmailAddress)).First();

        //    try
        //    {
        //        account.FPassword = newPassword;
        //        _context.SaveChanges();
        //        TempData["resetPasswordSuccessMessage"] = "密碼重置成功";
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return RedirectToAction("Homepage","Firm");
        //}

        //public IActionResult Logout() {
        //    HttpContext.Session.Remove("firmAccountName");
        //    HttpContext.Session.Remove("firmAccount");
        //    //HttpContext.Session.SetString("AccountName", String.Empty);
        //    return RedirectToAction("Homepage", "Firm");
        //}

    }
}
