using Entidades;
using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;

namespace Servicos.Implementacoes
{
    public class RestauranteServico : IRestauranteServico
    {
        private readonly AutomenuDbContext _db;

        public RestauranteServico()
        {
            _db = new AutomenuDbContext();
        }

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
