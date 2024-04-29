using Entidades;
using Microsoft.EntityFrameworkCore;
using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;
using Servicos.Helpers;

namespace Servicos.Implementacoes
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly AutomenuDbContext _db;
        public EnderecoServico(AutomenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<EnderecoResponse> AddEnderecoAsync(EnderecoAddRequest enderecoAddRequest)
        {
            if (enderecoAddRequest == null) throw new ArgumentNullException(nameof(enderecoAddRequest));
            if (!HelperValidacao.IsValido(enderecoAddRequest)) throw new ArgumentException("Endereço invalido!");

            Endereco endereco = enderecoAddRequest.ToEndereco();


            await _db.Enderecos.AddAsync(endereco);
            await _db.SaveChangesAsync();

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
