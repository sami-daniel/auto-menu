using AutoMenu.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    public class InterfaceController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObject<RestaurantResponse>("User") == null)
            {
                RedirectToAction("", "Home");
            }
            return View();
        }
    }
}
