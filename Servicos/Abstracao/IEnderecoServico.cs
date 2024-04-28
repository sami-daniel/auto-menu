using Servicos.DTO.AddRequests;
using Servicos.DTO.Responses;

namespace Servicos.Abstracao
{
    /// <summary>
    /// Interface que define operações relacionadas a serviços de endereço.
    /// </summary>
    public interface IEnderecoServico
    {
        /// <summary>
        /// Adiciona um novo endereço com base nos dados fornecidos e retorna a resposta do endereço adicionado.
        /// </summary>
        /// <param name="enderecoAddRequest">Os dados do novo endereço a serem adicionados.</param>
        /// <returns>A resposta do endereço adicionado.</returns>
        Task<EnderecoResponse> AddEnderecoAsync(EnderecoAddRequest enderecoAddRequest);
        /// <summary>
        /// Obtem todos os enderecos no Data Source de forma sincrona
        /// </summary>
        /// <returns>Todos os enderecos do Data Source</returns>
        IEnumerable<EnderecoResponse> GetAllEnderecos();
    }
}
