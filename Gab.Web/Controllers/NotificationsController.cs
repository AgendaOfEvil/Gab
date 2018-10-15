using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gab.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly Client _gab;

        public NotificationsController(Gab.Client gab)
        {
            _gab = gab;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _gab.Notifications();
             
            return View(model); 
        }
    }
}