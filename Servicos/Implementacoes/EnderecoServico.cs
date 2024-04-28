using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;

namespace Servicos.Implementacoes
{
    public class EnderecoServico : IEnderecoServico
    {
        public Task<EnderecoResponse> AddEnderecoAsync(EnderecoAddRequest enderecoAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoResponse>> GetAllEnderecosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
