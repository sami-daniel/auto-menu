using Microsoft.AspNetCore.Mvc;

namespace AutoMenu.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        public IActionResult Account()
        {
            // metodo IActionResult para a pagina index principal
            ViewBag.Css = "Account.css";
            return View();
        }
    }
}
