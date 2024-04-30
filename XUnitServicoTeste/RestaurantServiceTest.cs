using Entities;
using Services.Abstractions;
using Services.DTO.AddRequests;
using Services.Implementations;
using Xunit.Sdk;

namespace XUnitServicoTeste
{
    public class RestaurantServiceTest
    {
        private readonly IRestaurantService _restauranteServico;
        private readonly IAddressService _enderecoServico;
        public RestaurantServiceTest()
        {
            _restauranteServico = new RestaurantService(new AutomenuDbContext());
            _enderecoServico = new AddressService(new AutomenuDbContext());
        }
        #region AddRestauranteAsyncXUnitTest
        [Fact]
        // O restaurante a ser adicionado nao pode ser nulo
        public async Task AddRestauranteAsync_RestauranteAddRequestNulo()
        {
            //Arrange
            RestaurantAddRequest? restauranteAddRequest = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _restauranteServico.AddRestaurantAsync(restauranteAddRequest!);
            });
        }
        [Fact]
        // O restaurante a ser adicionado nao pode conter informacoes invalidas
        public async Task AddRestauranteAsync_RestauranteAddRequestInvalido()
        {
            //Act
            var restauranteAddRequest = new RestaurantAddRequest()
            {
                CNPJ = "sdasdasd@31212 a", //CNPJ no formato invalido
            };
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //act
                await _restauranteServico.AddRestaurantAsync(restauranteAddRequest);
            });
        }
        [Fact]
        // O restaurante a ser adicionado não pode existir
        public async Task AddRestauranteAsync_RestauranteAddRequestAdicionadoCorretamente()
        {
            //Assert
            var restauranteAddRequest = new RestaurantAddRequest()
            {
                CNPJ = "12.345.678/0001-90",
                Email = "restaurante@gmail.com",
                Name = "Comidas Delicosas E Sabor",
                Password = "Amaads@S1234!",
                FkAddressId = _enderecoServico.GetAllAddresses().First(endereco => endereco.AddressID == 1).AddressID
            };
            //Act
            var response_addrestaurante = await _restauranteServico.AddRestaurantAsync(restauranteAddRequest);
            var restaurante = _restauranteServico.GetAllRestaurants();
            //Assert
            Assert.Contains(response_addrestaurante, restaurante);
        }
        #endregion
    }
}
