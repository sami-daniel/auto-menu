using Entities;
using Services.Abstracao;
using Services.DTO.AddRequests;
using Services.DTO.Responses;
using Services.Helpers;

namespace Services.Implementacoes
{
    public class AddressService : IAddressService
    {
        private readonly AutomenuDbContext _db;
        public AddressService(AutomenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<AddressResponse> AddAddressAsync(AddressAddRequest enderecoAddRequest)
        {
            if (enderecoAddRequest == null) throw new ArgumentNullException(nameof(enderecoAddRequest));
            if (!ValidationHelper.IsValido(enderecoAddRequest)) throw new ArgumentException("Endereço invalido!");

            Address endereco = enderecoAddRequest.ToAddress();


            await _db.Addresses.AddAsync(endereco);
            await _db.SaveChangesAsync();

            return endereco.ToAddressResponse();
        }

        public IEnumerable<AddressResponse> GetAllAddresses()
        {
            List<AddressResponse> enderecoResponses = new List<AddressResponse>();

            foreach (var item in _db.Addresses)
            {
                enderecoResponses.Add(item.ToAddressResponse());
            }

            return enderecoResponses;
        }
    }
}
