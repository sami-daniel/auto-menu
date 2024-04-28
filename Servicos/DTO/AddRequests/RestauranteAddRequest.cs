using Entidades;
using Servicos.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Servicos.DTO.AddRequests
{
    /// <summary>
    /// Classe que representa os dados de adição de um restaurante.
    /// </summary>
    public class RestauranteAddRequest
    {
#pragma warning disable CS8618
        /// <summary>
        /// Obtém ou define o CNPJ do restaurante.
        /// </summary>
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 1, ErrorMessage = "O CNPJ deve ter entre 1 e 14 caracteres.")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ não é válido!")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Obtém ou define o nome do restaurante.
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 e 80 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o email do restaurante.
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O email deve ter entre 1 e 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define a senha do restaurante.
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 30 caracteres.")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        /// <summary>
        /// Obtém ou define o ID do endereço do restaurante.
        /// </summary>
        [Required(ErrorMessage = "O ID do endereço é obrigatório.")]
        [Display(Name = "ID do Endereço")]
        public int FkIdEndereco { get; set; }

        /// <summary>
        /// Converte o objeto atual de RestauranteAddRequest para um novo objeto do tipo Restaurante.
        /// </summary>
        /// <returns>Um novo objeto do tipo Restaurante baseado nos dados do objeto atual de RestauranteAddRequest.</returns>
#pragma warning restore CS8618
        public Restaurante ToRestaurante() => new Restaurante()
        {
            Cnpj = CNPJ,
            Nome = Nome,
            Email = Email,
            HashSenha = HasherSenha.HashearSenha(Senha),
            FkIdEndereco = FkIdEndereco
        };
    }
}
