using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    //Controlador Cadastro
    [Route("[controller]")]
    public class CadastroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}