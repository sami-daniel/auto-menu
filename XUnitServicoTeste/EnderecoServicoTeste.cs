using Servicos.Abstracao;
using Servicos.Implementacoes;
using Servicos.DTO.AddRequests;
using Entidades;

namespace XUnitServicoTeste
{
    public class EnderecoServicoTeste
    {
        private readonly IEnderecoServico _enderecoServico;
        public EnderecoServicoTeste()
        {
            _enderecoServico = new EnderecoServico(new AutomenuDbContext());
        }
        #region AddEnderecoAsyncXUnitTest
        [Fact]
        // O objeto EnderecoAddRequest não pode ser nulo ao passar como argumento para o metodo AddEndereco
        public async Task AddEnderecoAsync_EnderecoAddRequestNulo()
        {
            //Arrange
            EnderecoAddRequest? enderecoAddRequest = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddEnderecoAsync(enderecoAddRequest!);
            });
        }
        [Fact]
        // O objeto EnderecoAddRequest não pode conter propriedades invalidas ao ser adicionado
        public async Task AddEnderecoAsync_EnderecoAddRequestInvalido()
        {
            //Arrange
            EnderecoAddRequest? enderecoAddRequest = new EnderecoAddRequest()
            {
                UF = "MG12131", //Nao pode conter mais de duas letras
                Bairro = "", //Nao pode ser vazio
                //Todas propriedades devem ser preenchidas
            };
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddEnderecoAsync(enderecoAddRequest!);

            });
        }
        [Fact]
        // O objeto EnderecoAddRequest não pode conter propriedades invalidas ao ser adicionado
        public async Task AddEnderecoAsync_EnderecoAddRequestAdicionadoCorretamente()
        {
            //Arrange
            EnderecoAddRequest? enderecoAddRequest = new EnderecoAddRequest()
            {
                UF = "MG",
                Bairro = "Alto Vera Cruz",
                Cidade = "Belo Horizonte",
                Complemento = "3 Andar",
                Logradouro = "Rua dos Bobos Numero 0",
                Numero = 555
            };
            //Assert
            var resposta_enderecoServico_AddEndereco = await _enderecoServico.AddEnderecoAsync(enderecoAddRequest!);
            var respostas_enderecos = _enderecoServico.GetAllEnderecos();
            //Act
            Assert.Contains(resposta_enderecoServico_AddEndereco, respostas_enderecos);
        }
        #endregion
    }
}
