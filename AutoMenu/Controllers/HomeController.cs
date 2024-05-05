using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    //Controlador HOME
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
