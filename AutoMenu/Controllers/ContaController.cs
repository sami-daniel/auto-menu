using Microsoft.AspNetCore.Mvc;

namespace project_name.Controllers
{
    //Controlador HOME
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            // metodo IActionResult para a pagina index principal
            return View();
        }
    }
}
