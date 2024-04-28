using Servicos.DTO.AddRequests;

namespace project_name.Models
{
    /// <summary>
    /// Modelo para tornar a view de cadastro fortemente tipada para usar taghelpers
    /// </summary>
    internal class RestauranteEndereco
    {
        public RestauranteAddRequest RestauranteAddRequest { get; } = new RestauranteAddRequest();
        public EnderecoAddRequest EnderecoAddRequest { get; } = new EnderecoAddRequest();
    }
}
