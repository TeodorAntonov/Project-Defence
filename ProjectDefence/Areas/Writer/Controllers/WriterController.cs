using DataModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Areas.Writer.Controllers
{
    //[Authorize]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class WriterController : Controller
    {
        [HttpGet]
        public IActionResult GetWriterScreen()
        {
            var model = new WriterViewModel();
            return View(model);
        }
    }
}
