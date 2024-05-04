using Entities;
using Services.Helpers;

namespace Services.DTO.Responses
{
    /// <summary>
    /// Represents a restaurant response that contains basic information about a restaurant.
    /// </summary>
    public class RestaurantResponse
    {
        /// <summary>
        /// Initializes a new instance of the RestaurantResponse class.
        /// </summary>
        /// <param name="ID">The ID of the restaurant.</param>
        /// <param name="cnpj">The CNPJ of the restaurant.</param>
        /// <param name="name">The name of the restaurant.</param>
        /// <param name="email">The email of the restaurant.</param>
        /// <param name="fkAddressId">The ID of the address associated with the restaurant.</param>
        public RestaurantResponse(int iD, string cnpj, string name, string email, string passwordHash, int fkAddressId)
        {
            ID = iD;
            Cnpj = cnpj;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            FkAddressId = fkAddressId;
        }
        /// <summary>
        /// Gets the ID of the restaurant.
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Gets the CNPJ of the restaurant.
        /// </summary>
        public string Cnpj { get; } = null!;

        /// <summary>
        /// Gets the name of the restaurant.
        /// </summary>
        public string Name { get; } = null!;

        /// <summary>
        /// Gets the email of the restaurant.
        /// </summary>
        public string Email { get; } = null!;

        /// <summary>
        /// Gets the PasswordHash of the restaurant.
        /// </summary>
        public string PasswordHash { get; } = null!;

        /// <summary>
        /// Gets the ID of the address associated with the restaurant.
        /// </summary>
        public int FkAddressId { get; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(RestaurantResponse)) return false;

            var response = obj as RestaurantResponse;

            return response.Cnpj == Cnpj && response.Name == Name && response.Email == Email && FkAddressId == FkAddressId && PasswordHash == PasswordHash;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Extension class for the Restaurant entity, providing methods to convert a restaurant to a restaurant response.
    /// </summary>
    public static class RestaurantExtensions
    {
        /// <summary>
        /// Converts a Restaurant object to an instance of RestaurantResponse.
        /// </summary>
        /// <param name="restaurant">The restaurant to be converted.</param>
        /// <returns>An instance of RestaurantResponse containing the restaurant information.</returns>
        public static RestaurantResponse ToRestaurantResponse(this Restaurant restaurant) =>
            new(iD: restaurant.IdRestaurant,
                                   cnpj: restaurant.Cnpj,
                                   name: restaurant.Name,
                                   email: restaurant.Email,
                                   passwordHash: restaurant.PasswordHash,
                                   fkAddressId: restaurant.FkAddressId);
    }
}
