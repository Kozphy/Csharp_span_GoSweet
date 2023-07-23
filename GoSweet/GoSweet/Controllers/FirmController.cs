using GoSweet.Models;
using GoSweet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Datafor0704.Controllers
{
    public class FirmpageController : Controller
    {
        readonly private ShopwebContext _context;
        private HomeIndexVm? _homeIndexVm = new HomeIndexVm();

        public FirmpageController(ShopwebContext context) { 
            _context = context;
        }

        public IActionResult Homepage()
        {
            //IEnumerable<BellContentVm>? bellContents = BellDropdownMessage();
            //_homeIndexVm.bellContentDatas = bellContents;
            return View();
        }

        //private IEnumerable<BellContentVm>? BellDropdownMessage() 
        //{

        //    string firmAccount = HttpContext.Session.GetString("frimAccount")!;
        //    if (firmAccount == null) {
        //        return null;
        //    }

        //    IEnumerable<BellContentVm> notifyMessage = (from notify in _context.NotifyDatatables
        //                                   join order in _context.OrderDatatables
        //                                       on notify.ONumber equals order.ONumber
        //                                   join customer in _context.CustomerAccounttables
        //                                       on notify.CNumber equals customer.CNumber
        //                                   join product in _context.ProductDatatables
        //                                       on order.PNumber equals product.PNumber
        //                                   where (notify.OStatus == "已成團" || notify.OStatus == "已寄出") && customer.CAccount == firmAccount
        //                                   select new BellContentVm
        //                                   {
        //                                       OrderNumber = notify.ONumber,
        //                                       //Account = customer.CAccount,
        //                                       ProductName = product.PName,
        //                                       OrderStatus = notify.OStatus,
        //                                   }).ToList();

        //    return notifyMessage;
        //}

        public IActionResult Revenue()
        {
            return View();
        }
    }
}
