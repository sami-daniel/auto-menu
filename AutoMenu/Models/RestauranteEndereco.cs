using Services.DTO.AddRequests;

namespace AutoMenu.Models
{
    /// <summary>
    /// Modelo para tornar a view de cadastro fortemente tipada para usar taghelpers
    /// </summary>
    public class RestauranteEndereco
    {
        public RestaurantAddRequest RestauranteAddRequest { get; } = new RestaurantAddRequest();
        public AddressAddRequest EnderecoAddRequest { get; } = new AddressAddRequest();
    }
}
