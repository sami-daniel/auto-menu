using Services.DTO.AddRequests;
using Services.DTO.Responses;

namespace Services.Abstracao
{
    /// <summary>
    /// Interface que define operações relacionadas a serviços de endereço.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Adds a new address based on the provided data and returns the response of the added address.
        /// </summary>
        /// <param name="addressAddRequest">The data of the new address to be added.</param>
        /// <returns>The response of the added address.</returns>
        Task<AddressResponse> AddAddressAsync(AddressAddRequest addressAddRequest);
        /// <summary>
        /// Gets all addresses from the Data Source synchronously.
        /// </summary>
        /// <returns>All addresses from the Data Source</returns>
        IEnumerable<AddressResponse> GetAllAddresses();
    }
}
