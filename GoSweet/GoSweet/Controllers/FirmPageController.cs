using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lab_0704_Firm.Controllers {
    public class FirmPageController : Controller {

        private readonly shopwebContext _context;
        public FirmPageController(shopwebContext context) {
            _context = context;
        }

        public IActionResult ProductSale()
        {
            return View();
        }

        public IActionResult FirmData()
        {
            return View();
        }

        public IActionResult ProductSearch()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Firm_accounttable firmAccountData) 
        {
            if (ModelState.IsValid) {
                bool accountNotExist = _context.Firm_accounttables.Where((f) =>
                    f.f_nickname.Equals(firmAccountData.f_nickname) &&
                    f.f_account.Equals(firmAccountData.f_account)  &&
                    f.f_password.Equals(firmAccountData.f_password)
                ).IsNullOrEmpty();

                if (accountNotExist.Equals(false)){
                    TempData["frimAccountExistMessage"] = "此帳號已被註冊";
                    return View();
                }

                try {
                    _context.Firm_accounttables.Add(firmAccountData);
                    _context.SaveChanges();
                    TempData["firmSignUpSuccessMessage"] = "帳號註冊成功";
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            return View();
        }
    }
}
