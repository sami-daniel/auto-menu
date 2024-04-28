using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    //Controlador HOME
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // metodo IActionResult para a pagina index principal
            return View();
        }
    }
}
