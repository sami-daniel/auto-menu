using Entidades;

namespace Servicos.DTO.Responses
{
    /// <summary>
    /// Representa a resposta de um endereço.
    /// </summary>
    public class EnderecoResponse
    {
        /// <summary>
        /// Construtor da classe EnderecoResponse.
        /// </summary>
        /// <param name="iDEndereco">O ID do endereço.</param>
        /// <param name="uF">O estado ou unidade federativa.</param>
        /// <param name="cidade">A cidade.</param>
        /// <param name="bairro">O bairro.</param>
        /// <param name="logradouro">O logradouro.</param>
        /// <param name="numero">O número do endereço.</param>
        /// <param name="complemento">O complemento do endereço (opcional).</param>
        public EnderecoResponse(int iDEndereco,
            string uF, string cidade,
            string bairro,
            string logradouro,
            ushort numero,
            string complemento)
        {
            IDEndereco = iDEndereco;
            UF = uF;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
        }

        /// <summary>
        /// Obtém o ID do endereço.
        /// </summary>
        public int IDEndereco { get; }

        /// <summary>
        /// Obtém o estado ou unidade federativa.
        /// </summary>
        public string UF { get; }

        /// <summary>
        /// Obtém a cidade.
        /// </summary>
        public string Cidade { get; }

        /// <summary>
        /// Obtém o bairro.
        /// </summary>
        public string Bairro { get; }

        /// <summary>
        /// Obtém o logradouro.
        /// </summary>
        public string Logradouro { get; }

        /// <summary>
        /// Obtém o número do endereço.
        /// </summary>
        public ushort Numero { get; }

        /// <summary>
        /// Obtém o complemento do endereço.
        /// </summary>
        public string Complemento { get; }
    }

    /// <summary>
    /// Classe de extensões para a classe Endereco.
    /// </summary>
    public static class EnderecoExtensions
    {
        /// <summary>
        /// Converte um objeto Endereco para um objeto EnderecoResponse.
        /// </summary>
        /// <param name="endereco">O objeto Endereco a ser convertido.</param>
        /// <returns>O objeto EnderecoResponse correspondente.</returns>
        public static EnderecoResponse ToEnderecoResponse(this Endereco endereco) =>
            new EnderecoResponse(iDEndereco: endereco.IDEndereco,
                                 uF: endereco.UF,
                                 cidade: endereco.Cidade,
                                 bairro: endereco.Bairro,
                                 logradouro: endereco.Logradouro,
                                 numero: endereco.Numero,
                                 complemento: endereco.Complemento);
    }
}
