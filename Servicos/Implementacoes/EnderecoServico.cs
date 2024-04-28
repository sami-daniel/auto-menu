using Entidades;
using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;
using Servicos.Helpers;

namespace Servicos.Implementacoes
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly AutomenuDbContext _db;
        public EnderecoServico()
        {
            _db = new AutomenuDbContext();
        }

        public async Task<EnderecoResponse> AddEnderecoAsync(EnderecoAddRequest enderecoAddRequest)
        {
            if (enderecoAddRequest == null) throw new ArgumentNullException(nameof(enderecoAddRequest));
            if (!HelperValidacao.IsValido(enderecoAddRequest)) throw new ArgumentException("Endereço invalido!");

            Endereco endereco = enderecoAddRequest.ToEndereco();

            Task adicionar = Task.Run(async () =>
            {
                await _db.Enderecos.AddAsync(endereco);
            });
            await adicionar;
            Task salvarMudancas = Task.Run(async () =>
            {
                await _db.SaveChangesAsync();
            });
            await salvarMudancas;
            return endereco.ToEnderecoResponse();
        }

        public IEnumerable<EnderecoResponse> GetAllEnderecos()
        {
            List<EnderecoResponse> enderecoResponses = new List<EnderecoResponse>();

            foreach (var item in _db.Enderecos)
            {
                enderecoResponses.Add(item.ToEnderecoResponse());
            }

            return enderecoResponses;
        }       
    }
}
