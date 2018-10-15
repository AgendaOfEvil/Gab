using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gab.Web.Controllers
{
    public class ReactingController : Controller
    {
        private readonly Client _gab;

        public ReactingController(Gab.Client gab)
        {
            _gab = gab;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpVote()
        {
            var model = await _gab.UpVote(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> DownVote()
        {
            var model = await _gab.DownVote(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> RePost()
        {
            var model = await _gab.RePost(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> RemoveUpVote()
        {
            var model = await _gab.RemoveUpVote(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> RemoveDownVote()
        {
            var model = await _gab.RemoveDownVote(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> RemoveRePost()
        {
            var model = await _gab.RemoveRePost(38332631);

            return RedirectToAction(nameof(Index));
            // return View(model);
        }

        public async Task<IActionResult> PostDetails()
        {
            var model = await _gab.PostDetails(38332631);

            return View(model);
        }
    }
}