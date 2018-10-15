using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gab.Web.Controllers
{
    public class EngagingController : Controller
    {
        private readonly Client _gab;

        public EngagingController(Gab.Client gab)
        {
            _gab = gab;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Follow()
        {
            var model = await _gab.Follow(233064);

            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> UnFollow()
        {
            var model = await _gab.UnFollow(233064);

            return RedirectToAction(nameof(Index)); 
        }
    }
}