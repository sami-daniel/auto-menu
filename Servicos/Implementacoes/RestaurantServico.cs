using Entities;
using Services.Abstracao;
using Services.DTO.AddRequests;
using Services.DTO.Responses;
using Services.Helpers;

namespace Services.Implementacoes
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
            if (!HelperValidacao.IsValido(restauranteAddRequest)) throw new ArgumentException("Restaurante invalido!");

            var restauranteResponse = restauranteAddRequest.ToRestaurant();
            await _db.Restaurants.AddAsync(restauranteResponse);
            await _db.SaveChangesAsync();

            return restauranteResponse.ToRestaurantResponse();
        }

        public IEnumerable<RestaurantResponse> GetAllRestaurants()
        {
            List<RestaurantResponse> restauranteResponses = new List<RestaurantResponse>();

            foreach(var item in _db.Restaurants) 
            {
                restauranteResponses.Add(item.ToRestaurantResponse());
            }

            return restauranteResponses;
        }
    }
}
