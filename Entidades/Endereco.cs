using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades;

[Table("endereco")]
public partial class Endereco
{
    [Key]
    [Column("Id_endereco")]
    public int IdEndereco { get; set; }

    [Column("uf")]
    [StringLength(2)]
    public string Uf { get; set; } = null!;

    [Column("cidade")]
    [StringLength(100)]
    public string Cidade { get; set; } = null!;

    [Column("bairro")]
    [StringLength(100)]
    public string Bairro { get; set; } = null!;

    [Column("logradouro")]
    [StringLength(100)]
    public string Logradouro { get; set; } = null!;

    [Column("numero")]
    public ushort Numero { get; set; }

    [Column("complemento")]
    [StringLength(100)]
    public string Complemento { get; set; } = null!;

    [InverseProperty("FkIdEnderecoNavigation")]
    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
