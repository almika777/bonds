using Bonds.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bonds.App.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            return Ok("Registered");
        }
    }
}
