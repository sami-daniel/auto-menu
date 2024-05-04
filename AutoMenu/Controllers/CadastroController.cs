using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    //Controlador Cadastro
    public class CadastroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}