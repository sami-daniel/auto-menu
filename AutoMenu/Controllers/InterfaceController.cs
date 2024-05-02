using AutoMenu.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    public class InterfaceController : Controller
    {
        public IActionResult Interface()
        {
            /* 
             if(HttpContext.Session.GetObject<RestaurantResponse>("User") == null)
            {
                return RedirectToAction("", "Home");
            }
            
            */
            ViewBag.Css = "Interface.css";
            return View();
        }
    }
}
