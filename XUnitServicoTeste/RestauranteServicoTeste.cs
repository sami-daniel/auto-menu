using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.Exceptions;
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
        #region AddRestauranteAsyncXUnitTest
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
        [Fact]
        // O restaurante a ser adicionado não pode existir
        public async Task AddRestauranteAsync_RestauranteJaExitente()
        {
            //Assert
            var restauranteAddRequest = new RestauranteAddRequest()
            {
                CNPJ = "12.345.678/0001-90",
                Email = "restaurante@gmail.com",
                Nome = "Comidas Delicosas E Sabor",
                Senha = "Amaads@S1234!",
                FkIdEndereco = _enderecoServico.GetAllEnderecos().First(endereco => endereco.IDEndereco == 0).IDEndereco
            };
            var restauranteAddRequest1 = new RestauranteAddRequest()
            {
                CNPJ = "12.345.678/0001-90",
                Email = "restaurante@gmail.com",
                Nome = "Comidas Delicosas E Sabor",
                Senha = "Amaads@S1234!",
                FkIdEndereco = _enderecoServico.GetAllEnderecos().First(endereco => endereco.IDEndereco == 0).IDEndereco
            };
            //Assert
            await Assert.ThrowsAsync<RestauranteExistenteException>(async () =>
            {
                //act
                await _restauranteServico.AddRestauranteAsync(restauranteAddRequest);
                await _restauranteServico.AddRestauranteAsync(restauranteAddRequest1);
            });
        }
        [Fact]
        // O restaurante a ser adicionado não pode existir
        public async Task AddRestauranteAsync_RestauranteAddRequestAdicionadoCorretamente()
        {
            //Assert
            var restauranteAddRequest = new RestauranteAddRequest()
            {
                CNPJ = "12.345.678/0001-90",
                Email = "restaurante@gmail.com",
                Nome = "Comidas Delicosas E Sabor",
                Senha = "Amaads@S1234!",
                FkIdEndereco = _enderecoServico.GetAllEnderecos().First(endereco => endereco.IDEndereco == 0).IDEndereco
            };
            //Act
            var response_addrestaurante = await _restauranteServico.AddRestauranteAsync(restauranteAddRequest);
            var restaurante = _restauranteServico.GetAllRestaurantes();
            //Assert
            Assert.Contains(response_addrestaurante, restaurante);
        }
        #endregion
    }
}
