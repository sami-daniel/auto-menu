using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.DTO.AddRequests;
using Services.DTO.Responses;
using Services.Helpers;
using Servicos.Exceptions;

namespace Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AutoMenuDbContext _db;

        public RestaurantService(AutoMenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<RestaurantResponse> AddRestaurantAsync(RestaurantAddRequest restauranteAddRequest)
        {
            if (restauranteAddRequest == null) throw new ArgumentNullException(nameof(restauranteAddRequest));
            if (!ValidationHelper.IsValid(restauranteAddRequest)) throw new ArgumentException("Restaurante invalido!");

            var restaurant = restauranteAddRequest.ToRestaurant();

            if (_db.Restaurants.Select(r => r.Cnpj).Contains(restauranteAddRequest.CNPJ))
            {
                throw new ExistingRestaurantException();
            }

            await _db.Restaurants.AddAsync(restaurant);
            await _db.SaveChangesAsync();

            return restaurant.ToRestaurantResponse();
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

        public async Task RemoveRestaurantByCNPJAsync(string CNPJ)
        {
            var elementToRemove = await _db.Restaurants.FirstOrDefaultAsync(r => r.Cnpj == CNPJ);

            if (elementToRemove == null)
            {
                throw new ArgumentNullException(nameof(CNPJ));
            }

            _db.Restaurants.Remove(elementToRemove);
            await _db.SaveChangesAsync();
        }
    }
}
