using AutoMenu.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    public class InterfaceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InterfaceController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Interface()
        {

            if (HttpContext.Session.GetObject<RestaurantResponse>("User") == null && !_webHostEnvironment.IsDevelopment())
            {
                return RedirectToAction("", "Home");
            }
            //Nao o if


            ViewBag.Css = "Interface.css";
            return View();
        }
    }
}
