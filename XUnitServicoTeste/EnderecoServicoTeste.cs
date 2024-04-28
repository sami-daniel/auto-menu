namespace XUnitServicoTeste
{
    public class EnderecoServicoTeste
    {
        private readonly IEnderecoServico _enderecoServico;
        public EnderecoServicoTeste()
        {
            _enderecoServico = new EnderecoServico();
        }

    }
}
