using AutoMenu.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Responses;

namespace AutoMenu.Controllers
{
    [Route("[controller]")]
    public class ListMenuController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ListMenuController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult ListMenu()
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
