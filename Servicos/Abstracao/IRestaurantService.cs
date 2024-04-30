using Services.DTO.AddRequests;
using Services.DTO.Responses;

namespace Services.Abstracao
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
        IEnumerable<RestaurantResponse> GetAllRestaurants();
    }
}
