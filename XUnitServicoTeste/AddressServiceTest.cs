using Services.Abstractions;
using Services.Implementations;
using Services.DTO.AddRequests;
using Entities;

namespace XUnitServicoTeste
{
    public class AddressServiceTest
    {
        private readonly IAddressService _enderecoServico;
        public AddressServiceTest()
        {
            _enderecoServico = new AddressService(new AutomenuDbContext());
        }
        #region AddEnderecoAsyncXUnitTest
        [Fact]
        // O objeto EnderecoAddRequest não pode ser nulo ao passar como argumento para o metodo AddEndereco
        public async Task AddEnderecoAsync_EnderecoAddRequestNulo()
        {
            //Arrange
            AddressAddRequest? enderecoAddRequest = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddAddressAsync(enderecoAddRequest!);
            });
        }
        [Fact]
        // O objeto EnderecoAddRequest não pode conter propriedades invalidas ao ser adicionado
        public async Task AddEnderecoAsync_EnderecoAddRequestInvalido()
        {
            //Arrange
            AddressAddRequest? enderecoAddRequest = new AddressAddRequest()
            {
                UF = "MG12131", //Nao pode conter mais de duas letras
                District = "", //Nao pode ser vazio
                //Todas propriedades devem ser preenchidas
            };
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddAddressAsync(enderecoAddRequest!);

            });
        }
        [Fact]
        // O objeto EnderecoAddRequest não pode conter propriedades invalidas ao ser adicionado
        public async Task AddEnderecoAsync_EnderecoAddRequestAdicionadoCorretamente()
        {
            //Arrange
            AddressAddRequest? enderecoAddRequest = new AddressAddRequest()
            {
                UF = "MG",
                District = "Alto Vera Cruz",
                City = "Belo Horizonte",
                Complement = "3 Andar",
                Street = "Rua dos Bobos Numero 0",
                Number = 555
            };
            //Assert
            var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddAddressAsync(enderecoAddRequest!);
            var respostas_enderecos = _enderecoServico.GetAllAddresses();
            //Act
            Assert.Contains(resposta_enderecoServico_AddEndereco, respostas_enderecos);
        }
        #endregion
    }
}
