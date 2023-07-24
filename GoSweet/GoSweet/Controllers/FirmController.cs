using GoSweet.Models;
using GoSweet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Datafor0704.Controllers
{
    public class FirmpageController : Controller
    {
        private readonly  ShopwebContext _context;
        private HomeIndexVm? _homeIndexVm = new();

        public FirmpageController(ShopwebContext context)
        {
            _context = context;
        }

        public IActionResult Homepage()
        {
            //IEnumerable<BellContentVm>? bellContents = BellDropdownMessage();
            //_homeIndexVm.bellContentDatas = bellContents;
            _homeIndexVm!.FirmBellDropDownDatas = GetBellDropdownMessage();
            return View(_homeIndexVm);
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

        public IActionResult Revenue()
        {
            return View();
        }
    }
}
