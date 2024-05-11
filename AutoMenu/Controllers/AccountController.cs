using Microsoft.AspNetCore.Mvc;
using Services.DTO.AddRequests;
using Services.Abstractions;
using Servicos.Exceptions;
using Services.Helpers;
using Entities;
using Services.DTO.Responses;
using AutoMenu.Infra.Extensions;

namespace AutoMenu.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IRestaurantService _restaurantService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(IAddressService addressService, IRestaurantService restaurantService, IWebHostEnvironment webHostEnvironment)
        {
            _addressService = addressService;
            _restaurantService = restaurantService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Account()
        {
            // metodo IActionResult para a pagina index principal
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromForm] RestaurantAddRequest restaurantAddRequest, [FromForm] AddressAddRequest addressAddRequest)
        {
            if (!ModelState.IsValid && _webHostEnvironment.IsDevelopment())
            {
                return BadRequest(ModelState); //Custom error page pra depois
            }
            else if (!ModelState.IsValid)
                return BadRequest(string.Join(',', ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage)));


            var fk_address = await _addressService.AddAddressAsync(addressAddRequest);
            restaurantAddRequest.FkAddressId = fk_address.AddressID;
            RestaurantResponse restaurantResponse;
            try
            {
                restaurantResponse = await _restaurantService.AddRestaurantAsync(restaurantAddRequest);
            }
            catch (ExistingRestaurantException)
            {
                await _addressService.RemoveAddressByIDAsync(fk_address.AddressID);
                return BadRequest($"Um restaurante com o CNPJ {restaurantAddRequest.CNPJ} já está registrado!");
            }
            HttpContext.Session.SetObject("User", restaurantResponse);
            return RedirectToActionPermanent("", "Interface");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromForm] string CNPJ, [FromForm] string password)
        {
            var restaurant = await _restaurantService.GetRestaurantByCNPJAsync(CNPJ);
            if (restaurant == null || password == null) return BadRequest("Senha ou CNPJ Invalido!");

            if (!PasswordHasher.VerifyPassword(password, restaurant.PasswordHash))
            {
                return BadRequest("Senha ou CNPJ Invalido!");
            }

            HttpContext.Session.SetObject("User", restaurant);

            return RedirectToActionPermanent("", "Interface");
        }
        [HttpPost]
        [Route("verify/cnpj")]
        public async Task<IActionResult> CheckCNPJAvailability([FromBody] string CNPJ)
        {
            if (string.IsNullOrEmpty(CNPJ)) return BadRequest();
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();


            if(restaurants.FirstOrDefault(restaurant => restaurant.Cnpj == CNPJ) == null)
                return Ok("Valid CNPJ");

            return Ok("Invalid CNPJ");

        }
    }
}
