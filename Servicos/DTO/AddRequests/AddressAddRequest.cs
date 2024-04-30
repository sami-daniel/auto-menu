using System.ComponentModel.DataAnnotations;
using Entities;

namespace Services.DTO.AddRequests
{
    /// <summary>
    /// Represents a DTO for adding a new address.
    /// </summary>
    public class AddressAddRequest
    {
#pragma warning disable CS8618
        [Required(ErrorMessage = "A sigla do estado é obrigatória.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A sigla do estado deve ter 2 caracteres.")]
        private string uF;
        /// <summary>
        /// Gets or sets the state abbreviation.
        /// </summary>
        public string UF { get => uF; set => uF = value.ToUpper(); }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode exceder 100 caracteres.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the district name.
        /// </summary>
        [Required(ErrorMessage = "O nome do bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do bairro não pode exceder 100 caracteres.")]
        public string District { get; set; }

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        [Required(ErrorMessage = "O nome do logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do logradouro não pode exceder 100 caracteres.")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the address number.
        /// </summary>
        [Required(ErrorMessage = "O número do endereço é obrigatório.")]
        public ushort Number { get; set; }

        /// <summary>
        /// Gets or sets the address complement.
        /// </summary>
        [StringLength(100, ErrorMessage = "O complemento do endereço não pode exceder 100 caracteres.")]
        public string Complement { get; set; }
        /// <summary>
        /// Converts the current AddressAddRequest object to a new object of type Address.
        /// </summary>
        /// <returns>A new object of type Address based on the current AddressAddRequest object.</returns>
#pragma warning restore CS8618
        public Address ToAddress() => new Address()
        {
            Uf = UF,
            City = City,
            District = District,
            Street = Street,
            Number = Number,
            Complement = Complement
        };
    }
}
