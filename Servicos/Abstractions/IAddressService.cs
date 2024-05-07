using Services.DTO.AddRequests;
using Services.DTO.Responses;

namespace Services.Abstractions
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
        Task<IEnumerable<AddressResponse>> GetAllAddressesAsync();
        /// <summary>
        /// Removes a address by its ID number.
        /// </summary>
        /// <param name="ID">The ID number of the address to remove.</param>
        Task RemoveAddressByIDAsync(int ID);
    }
}
