using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.DTO.AddRequests;
using Services.DTO.Responses;
using Services.Helpers;

namespace Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AutomenuDbContext _db;

        public RestaurantService(AutomenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<RestaurantResponse> AddRestaurantAsync(RestaurantAddRequest restauranteAddRequest)
        {
            if (restauranteAddRequest == null) throw new ArgumentNullException(nameof(restauranteAddRequest));
            if (!ValidationHelper.IsValid(restauranteAddRequest)) throw new ArgumentException("Restaurante invalido!");

            var restauranteResponse = restauranteAddRequest.ToRestaurant();
            await _db.Restaurants.AddAsync(restauranteResponse);
            await _db.SaveChangesAsync();

            return restauranteResponse.ToRestaurantResponse();
        }

        public async Task<IEnumerable<RestaurantResponse>> GetAllRestaurantsAsync()
        {
            var restaurants = await _db.Restaurants.ToListAsync();
            return restaurants.Select(r => r.ToRestaurantResponse());
        }

        public async Task<RestaurantResponse?> GetRestaurantByCNPJAsync(string CNPJ)
        {
            var restaurant = await _db.Restaurants.FirstOrDefaultAsync(r => r.Cnpj == CNPJ);

            return restaurant?.ToRestaurantResponse();
        }
    }
}
