using Microsoft.AspNetCore.Mvc;

namespace project_name.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
