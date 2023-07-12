using Microsoft.AspNetCore.Mvc;

namespace DataSchemaLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

