using Microsoft.AspNetCore.Mvc;

namespace Bonds.App.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Json("ok");
        }
    }
}
