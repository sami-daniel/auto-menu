using Entidades;
using System.ComponentModel.DataAnnotations;

namespace Servicos.DTO
{
    /// <summary>
    /// Representa um DTO para inserir um novo restaurante
    /// </summary>
    public class RestauranteAddRequest
    {
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 1, ErrorMessage = "O CNPJ deve ter entre 1 e 14 caracteres.")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ não é válido!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 e 80 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O email deve ter entre 1 e 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "A senha deve ter entre 1 e 255 caracteres.")]
        [Display(Name = "Senha")]
        public string HashSenha { get; set; }

        [Required(ErrorMessage = "O ID do endereço é obrigatório.")]
        [Display(Name = "ID do Endereço")]
        public int FkIdEndereco { get; set; }
    }
}
