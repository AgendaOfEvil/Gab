using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gab.Web.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly Client _gab;

        public UsersController(Gab.Client gab)
        {
            _gab = gab;
        }

        [Route("[action]")]
        public async Task<IActionResult> Me()
        {
            var model = await _gab.UserDetails();

            return View(model);
        }

        [Route("{username}")]
        public async Task<IActionResult> User(string username)
        {
            var model = await _gab.UserDetails(username);

            return View(model);
        }

        [Route("[action]/{username}")]
        public async Task<IActionResult> Followers(string username)
        {
            var model = await _gab.Followers(username);

            return View(model);
        }

        [Route("[action]/{username}")]
        public async Task<IActionResult> Followed(string username)
        {
            var model = await _gab.Followed(username);

            return View(model);
        }
    }
}