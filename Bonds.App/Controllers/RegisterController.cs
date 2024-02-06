using Bonds.App.Models;
using Bonds.Common.Entities;
using Bonds.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bonds.App.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public RegisterController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
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
