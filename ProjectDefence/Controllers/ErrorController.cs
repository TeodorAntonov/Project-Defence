using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult BadRequestAdmin()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult BadRequest()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
