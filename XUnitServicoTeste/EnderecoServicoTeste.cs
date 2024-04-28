using Servicos.Abstracao;
using Servicos.Implementacoes;
using Servicos.DTO.AddRequests;

namespace XUnitServicoTeste
{
    public class EnderecoServicoTeste
    {
        private readonly IEnderecoServico _enderecoServico;
        public EnderecoServicoTeste()
        {
            _enderecoServico = new EnderecoServico();
        }

        [Fact]
        public void AddEndereco_AddEnderecoRequestNulo()
        {
            //Arrange
            EnderecoAddRequest? enderecoAddRequest = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                var resposta_enderecoServico_AddEndereco = _enderecoServico.AddEndereco(enderecoAddRequest!);
            });
        }
    }
}
