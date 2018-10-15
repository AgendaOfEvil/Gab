using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gab.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly Client _gab;

        public PostsController(Gab.Client gab)
        {
            _gab = gab;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _gab.CreatePost(DateTimeOffset.UtcNow.ToString("F"));

            return View(model);
        }
    }
}