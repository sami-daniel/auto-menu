using AutoMenu.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    public class InterfaceController : Controller
    {
        private readonly IConfiguration _configuration;
        public InterfaceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Interface()
        {
            if (HttpContext.Session.GetObject<RestaurantResponse>("User") == null && _configuration["environmentVariables:ASPNETCORE_ENVIRONMENT"] != "Development")
            {
                return RedirectToAction("", "Home");
            }


            ViewBag.Css = "Interface.css";
            return View();
        }
    }
}
