using Entidades;
using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;
using Servicos.Helpers;

namespace Servicos.Implementacoes
{
    public class RestauranteServico : IRestauranteServico
    {
        private readonly AutomenuDbContext _db;

        public RestauranteServico()
        {
            _db = new AutomenuDbContext();
        }

        public async Task<RestauranteResponse> AddRestauranteAsync(RestauranteAddRequest restauranteAddRequest)
        {
            if (restauranteAddRequest == null) throw new ArgumentNullException(nameof(restauranteAddRequest));
            if (!HelperValidacao.IsValido(restauranteAddRequest)) throw new ArgumentException("Restaurante invalido!");

            var restauranteResponse = restauranteAddRequest.ToRestaurante();
            await _db.Restaurantes.AddAsync(restauranteResponse);
            await _db.SaveChangesAsync();

            return restauranteResponse.ToRestauranteResponse();
        }

        public IEnumerable<RestauranteResponse> GetAllRestaurantes()
        {
            List<RestauranteResponse> restauranteResponses = new List<RestauranteResponse>();

            foreach(var item in _db.Restaurantes) 
            {
                restauranteResponses.Add(item.ToRestauranteResponse());
            }

            return restauranteResponses;
        }
    }
}
