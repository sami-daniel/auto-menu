using Entidades;
using Servicos.Abstracao;
using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;
using System.ComponentModel.DataAnnotations;

namespace Servicos.Implementacoes
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly AutomenuDbContext _db;
        public EnderecoServico() 
        {
            _db = new AutomenuDbContext();
        }
        public Task<EnderecoResponse> AddEnderecoAsync(EnderecoAddRequest enderecoAddRequest)
        {
            if (enderecoAddRequest == null) throw new ArgumentNullException(nameof(enderecoAddRequest));
            ValidationContext validationContext = new ValidationContext(enderecoAddRequest);

        }

        public Task<IEnumerable<EnderecoResponse>> GetAllEnderecosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
