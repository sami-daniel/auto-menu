using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;

namespace Servicos.Implementacoes
{
    public class RestauranteServico : IRestauranteServico
    {
        public Task<RestauranteResponse> AddRestauranteAsync(RestauranteAddRequest restauranteAddRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestauranteResponse> GetAllRestaurantes()
        {
            throw new NotImplementedException();
        }
    }
}
