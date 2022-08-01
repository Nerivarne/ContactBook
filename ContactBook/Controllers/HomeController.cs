using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return LocalRedirect("~/swagger");
        }
    }
}
