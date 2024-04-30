using Microsoft.AspNetCore.Mvc;
using Services.DTO.AddRequests;
using Services.Abstractions;

namespace AutoMenu.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IAddressService _addressService;
        private IRestaurantService _restaurantService;

        public AccountController(IAddressService addressService, IRestaurantService restaurantService)
        {
            _addressService = addressService;
            _restaurantService = restaurantService;
        }
        public IActionResult Account()
        {
            // metodo IActionResult para a pagina index principal
            ViewBag.Css = "Account.css";
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromForm]RestaurantAddRequest restaurantAddRequest, [FromForm]AddressAddRequest addressAddRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //Custom error page pra depois
            }
            var fk_address = await _addressService.AddAddressAsync(addressAddRequest);
            restaurantAddRequest.FkAddressId = fk_address.AddressID;
            await _restaurantService.AddRestaurantAsync(restaurantAddRequest);
            return RedirectPermanent("/");
        }
    }
}
