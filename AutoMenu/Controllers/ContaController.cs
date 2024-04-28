using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    //Controlador HOME
    public class ContaController : Controller
    {
        public IActionResult Conta()
        {
            // metodo IActionResult para a pagina index principal
            ViewBag.Css = "Conta.css";
            return View();
        }
    }
}
