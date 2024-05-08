using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.DTO.AddRequests;
using Services.DTO.Responses;
using Services.Helpers;

namespace Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly AutoMenuDbContext _db;
        public AddressService(AutoMenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<AddressResponse> AddAddressAsync(AddressAddRequest enderecoAddRequest)
        {
            if (enderecoAddRequest == null) throw new ArgumentNullException(nameof(enderecoAddRequest));
            if (!ValidationHelper.IsValid(enderecoAddRequest)) throw new ArgumentException("Endereço invalido!");

            Address endereco = enderecoAddRequest.ToAddress();


            await _db.Addresses.AddAsync(endereco);
            await _db.SaveChangesAsync();

            return endereco.ToAddressResponse();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<AddressResponse>> GetAllAddresses()
=======
        public async Task<IEnumerable<AddressResponse>> GetAllAddressesAsync()
>>>>>>> 9a2259b763348075f2339044e90270557de26982
        {
            var adresses = await _db.Addresses.ToListAsync();

<<<<<<< HEAD
            foreach (var item in _db.Addresses)
            {
                enderecoResponses.Add(item.ToAddressResponse());
            }

            return await enderecoResponses;
=======
            return adresses.Select(a => a.ToAddressResponse());
>>>>>>> 9a2259b763348075f2339044e90270557de26982
        }

        public async Task RemoveAddressByIDAsync(int ID)
        {

            var elementToRemove = await _db.Addresses.FirstOrDefaultAsync(a => a.IdAddress == ID);

            if (elementToRemove == null)
            {
                throw new ArgumentNullException(nameof(ID));
            }

            _db.Addresses.Remove(elementToRemove);
            await _db.SaveChangesAsync();
        }
    }
}
