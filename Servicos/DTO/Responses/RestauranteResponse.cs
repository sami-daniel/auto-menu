using Entidades;

namespace Servicos.DTO.Responses
{
    /// <summary>
    /// Representa uma resposta de restaurante que contém informações básicas sobre um restaurante.
    /// </summary>
    public class RestauranteResponse
    {
        /// <summary>
        /// Inicializa uma nova instância da classe RestauranteResponse.
        /// </summary>
        /// <param name="cnpj">O CNPJ do restaurante.</param>
        /// <param name="nome">O nome do restaurante.</param>
        /// <param name="email">O e-mail do restaurante.</param>
        /// <param name="fkIdEndereco">O ID do endereço associado ao restaurante.</param>
        public RestauranteResponse(string cnpj, string nome, string email, int fkIdEndereco)
        {
            Cnpj = cnpj;
            Nome = nome;
            Email = email;
            FkIdEndereco = fkIdEndereco;
        }

        /// <summary>
        /// Obtém o CNPJ do restaurante.
        /// </summary>
        public string Cnpj { get; } = null!;

        /// <summary>
        /// Obtém o nome do restaurante.
        /// </summary>
        public string Nome { get; } = null!;

        /// <summary>
        /// Obtém o e-mail do restaurante.
        /// </summary>
        public string Email { get; } = null!;

        /// <summary>
        /// Obtém o ID do endereço associado ao restaurante.
        /// </summary>
        public int FkIdEndereco { get; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(RestauranteResponse)) return false;

            var response = obj as RestauranteResponse;

            return response.Cnpj == Cnpj && response.Nome == Nome && response.Email == Email && FkIdEndereco == FkIdEndereco;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Classe de extensão para a entidade Restaurante, fornecendo métodos para converter um restaurante em uma resposta de restaurante.
    /// </summary>
    public static class RestauranteExtensions
    {
        /// <summary>
        /// Converte um objeto Restaurante em uma instância de RestauranteResponse.
        /// </summary>
        /// <param name="restaurante">O restaurante a ser convertido.</param>
        /// <returns>Uma instância de RestauranteResponse contendo as informações do restaurante.</returns>
        public static RestauranteResponse ToRestauranteResponse(this Restaurante restaurante) =>
            new RestauranteResponse(cnpj: restaurante.Cnpj,
                                    nome: restaurante.Nome,
                                    email: restaurante.Email,
                                    fkIdEndereco: restaurante.FkIdEndereco);
    }
}
