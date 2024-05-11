using AutoMenu.Infra.Extensions;
using AutoMenu.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    [CheckSessionObjectFilter()]
    public class InterfaceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InterfaceController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Interface()
        {
            ViewBag.ViewModelTRestaurantResponse = HttpContext.Session.GetObject<RestaurantResponse>("User");
            return View();
        }
        [Route("Menu/[action]")]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetObject<RestaurantResponse>("User") == null && !_webHostEnvironment.IsDevelopment())
            {
                return RedirectToAction("", "Home");
            }
            //Nao o if

            ViewBag.ViewModelTRestaurantResponse = HttpContext.Session.GetObject<RestaurantResponse>("User");
            return View();
        }


    }
}