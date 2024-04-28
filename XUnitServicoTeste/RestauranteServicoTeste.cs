using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.Implementacoes;
using Xunit.Sdk;

namespace XUnitServicoTeste
{
    public class RestauranteServicoTeste
    {
        private readonly IRestauranteServico _restauranteServico;
        private readonly IEnderecoServico _enderecoServico;
        public RestauranteServicoTeste()
        {
            _restauranteServico = new RestauranteServico();
            _enderecoServico = new EnderecoServico();
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
        [Fact]
        // O restaurante a ser adicionado nao pode conter informacoes invalidas
        public async Task AddRestauranteAsync_RestauranteAddRequestInvalido()
        {
            //Act
            var restauranteAddRequest = new RestauranteAddRequest()
            {
                CNPJ = "sdasdasd@31212 a", //CNPJ no formato invalido
            };
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //act
                await _restauranteServico.AddRestauranteAsync(restauranteAddRequest);
            });
        }
    }
}
