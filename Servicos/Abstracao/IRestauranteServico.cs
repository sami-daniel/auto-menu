using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;

namespace Servicos.Abstracao
{
    public interface IRestauranteServico
    {
        /// <summary>
        /// Adiciona um novo restaurante de forma assíncrona.
        /// </summary>
        /// <param name="restauranteAddRequest">Objeto contendo os detalhes do restaurante a ser adicionado.</param>
        /// <returns>Um objeto de resposta à adição de um restaurante.</returns>
        Task<RestauranteResponse> AddRestauranteAsync(RestauranteAddRequest restauranteAddRequest);
        /// <summary>
        /// Obtém todos os restaurantes cadastrados.
        /// </summary>
        /// <returns>Coleção de objetos representando os restaurantes cadastrados.</returns>
        IEnumerable<RestauranteResponse> GetAllRestaurantes();
    }
}
