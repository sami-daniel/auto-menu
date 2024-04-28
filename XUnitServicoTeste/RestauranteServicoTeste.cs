using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.Implementacoes;
using Xunit.Sdk;

namespace XUnitServicoTeste
{
    public class RestauranteServicoTeste
    {
        private readonly IRestauranteServico _restauranteServico;
        public RestauranteServicoTeste()
        {
            _restauranteServico = new RestauranteServico();
        }
        [Fact]
        // O restaurante a ser adicionado nao pode ser nulo
        public async Task AddRestauranteAsync_RestauranteAddRequestNulo()
        {
            //Arrange
            RestauranteAddRequest? restauranteAddRequest = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _restauranteServico.AddRestauranteAsync(restauranteAddRequest!);
            });
        }
        
    }
}
