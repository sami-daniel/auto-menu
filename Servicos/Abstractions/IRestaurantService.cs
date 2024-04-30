using Services.DTO.AddRequests;
using Services.DTO.Responses;

namespace Services.Abstractions
{
    public interface IRestaurantService
    {
        /// <summary>
        /// Adds a new restaurant asynchronously.
        /// </summary>
        /// <param name="restaurantAddRequest">Object containing the details of the restaurant to be added.</param>
        /// <returns>A response object for adding a restaurant.</returns>
        Task<RestaurantResponse> AddRestaurantAsync(RestaurantAddRequest restaurantAddRequest);
        /// <summary>
        /// Retrieves all registered restaurants.
        /// </summary>
        /// <returns>Collection of objects representing the registered restaurants.</returns>
        Task<IEnumerable<RestaurantResponse>> GetAllRestaurantsAsync();
        /// <summary>
        /// Retrieves a restaurant by its CNPJ number.
        /// </summary>
        /// <param name="CNPJ">The CNPJ number of the restaurant to retrieve.</param>
        /// <returns>
        /// An object representing the restaurant identified by the provided CNPJ number.
        /// </returns>
        Task<RestaurantResponse?> GetRestaurantByCNPJAsync(string CNPJ);
    }
}
