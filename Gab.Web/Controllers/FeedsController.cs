using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gab.Web.Controllers
{
    public class FeedsController : Controller
    {
        private readonly Client _gab;

        public FeedsController(Gab.Client gab)
        {
            _gab = gab;
        }

        public async Task<IActionResult> MainFeed()
        {
            var model = await _gab.MainFeed(); 

            return View(model);
        }

        public async Task<IActionResult> UserFeed()
        {
            var model = await _gab.UserFeed("AgendaOfEvil"); 

            return View(model);
        }
    }
}