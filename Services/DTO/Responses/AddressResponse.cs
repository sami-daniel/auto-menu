using Entities;

namespace Services.DTO.Responses
{
    /// <summary>
    /// Represents the response of an address.
    /// </summary>
    public class AddressResponse
    {
        /// <summary>
        /// Constructor of the AddressResponse class.
        /// </summary>
        /// <param name="addressID">The ID of the address.</param>
        /// <param name="state">The state or federative unit.</param>
        /// <param name="city">The city.</param>
        /// <param name="district">The district.</param>
        /// <param name="street">The street.</param>
        /// <param name="number">The address number.</param>
        /// <param name="complement">The address complement (optional).</param>
        public AddressResponse(int addressID,
            string uF, string city,
            string district,
            string street,
            ushort number,
            string complement)
        {
            AddressID = addressID;
            UF = uF;
            City = city;
            Neighborhood = district;
            Street = street;
            Number = number;
            Complement = complement;
        }

        /// <summary>
        /// Gets the ID of the address.
        /// </summary>
        public int AddressID { get; }

        /// <summary>
        /// Gets the UF unit.
        /// </summary>
        public string UF { get; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the neighborhood.
        /// </summary>
        public string Neighborhood { get; }

        /// <summary>
        /// Gets the street.
        /// </summary>
        public string Street { get; }

        /// <summary>
        /// Gets the address number.
        /// </summary>
        public ushort Number { get; }

        /// <summary>
        /// Gets the address complement.
        /// </summary>
        public string Complement { get; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(AddressResponse)) return false;

            var response = obj as AddressResponse;

            return response.AddressID == AddressID
                && response.UF == UF
                && response.City == City
                && response.Neighborhood == Neighborhood
                && response.Street == Street
                && response.Number == Number
                && response.Complement == Complement;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    /// <summary>
    /// Extension class for the Address class.
    /// </summary>
    public static class AddressExtensions
    {
        /// <summary>
        /// Converts an Address object to an AddressResponse object.
        /// </summary>
        /// <param name="address">The Address object to be converted.</param>
        /// <returns>The corresponding AddressResponse object.</returns>
        public static AddressResponse ToAddressResponse(this Address address) =>
            new(addressID: address.IdAddress,
                                uF: address.Uf,
                                city: address.City,
                                district: address.District,
                                street: address.Street,
                                number: address.Number,
                                complement: address.Complement);
    }

}
