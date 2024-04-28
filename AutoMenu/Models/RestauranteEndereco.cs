using Servicos.DTO.AddRequests;

namespace AutoMenu.Models
{
    /// <summary>
    /// Modelo para tornar a view de cadastro fortemente tipada para usar taghelpers
    /// </summary>
    public class RestauranteEndereco
    {
        public RestauranteAddRequest RestauranteAddRequest { get; } = new RestauranteAddRequest();
        public EnderecoAddRequest EnderecoAddRequest { get; } = new EnderecoAddRequest();
    }
}
