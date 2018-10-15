using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gab.Web.Controllers
{
    public class PopularController : Controller
    {
        private readonly Client _gab;

        public PopularController(Gab.Client gab)
        {
            _gab = gab;
        }

        public async Task<IActionResult> PopularFeed()
        {
            var model = await _gab.PopularFeed();

            return View(model);
        }

        public async Task<IActionResult> PopularUsers()
        {
            var model = await _gab.PopularUsers();

            return View(model);
        }
    }
}