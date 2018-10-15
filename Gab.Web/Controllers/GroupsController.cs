using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gab.Web.Controllers
{
    public class GroupsController : Controller
    {
        private readonly Client _gab;

        public GroupsController(Gab.Client gab)
        {
            _gab = gab;
        }

        public async Task<IActionResult> PopularGroups()
        {
            var model = await _gab.PopularGroups(); 

            return View(model);
        }

        public async Task<IActionResult> GroupDetails()
        {
            var model = await _gab.GroupDetails(Guid.Parse("f8f914da-4423-4f0b-abb0-9e289cad8413")); 

            return View(model);
        }

        public async Task<IActionResult> GroupUsers()
        {
            var model = await _gab.GroupUsers(Guid.Parse("f8f914da-4423-4f0b-abb0-9e289cad8413")); 

            return View(model.Data);
        }

        public async Task<IActionResult> GroupModerationLogs()
        {
            var model = await _gab.GroupModerationLogs(Guid.Parse("f8f914da-4423-4f0b-abb0-9e289cad8413")); 

            return View(model);
        } 
    }
}