using Entities;
using Services.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Services.DTO.AddRequests
{
    /// <summary>
    /// Class that represents the data for adding a restaurant.
    /// </summary>
    public class RestaurantAddRequest
    {
#pragma warning disable CS8618
        /// <summary>
        /// Gets or sets the CNPJ of the restaurant.
        /// </summary>
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 1, ErrorMessage = "O CNPJ deve ter entre 1 e 14 caracteres.")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ não é válido!")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Gets or sets the name of the restaurant.
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 e 80 caracteres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the restaurant.
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O email deve ter entre 1 e 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ID of the restaurant's address.
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 30 caracteres.")]
        [Display(Name = "Senha")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z@$!%*?&]*$", ErrorMessage = "A senha deve conter pelo menos uma letra minúscula, uma letra maiúscula, um caractere especial (@$!%*?&)")]
        public string Password { get; set; }


        /// <summary>
        /// Gets or sets the ID of the restaurant's address.
        /// </summary>
        public int FkAddressId { get; set; }

        /// <summary>
        /// Converts the current RestaurantAddRequest object to a new object of type Restaurant.
        /// </summary>
        /// <returns>A new object of type Restaurant based on the data from the current RestaurantAddRequest object.</returns>
#pragma warning restore CS8618
        public Restaurant ToRestaurant() => new Restaurant()
        {
            Cnpj = CNPJ,
            Name = Name,
            Email = Email,
            PasswordHash = PasswordHasher.HashPassword(Password),
            FkAddressId = FkAddressId
        };
    }
}
