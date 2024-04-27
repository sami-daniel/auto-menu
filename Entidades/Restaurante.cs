using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("restaurante")]
[Index("FkIdEndereco", Name = "Fk_Id_endereco")]
public partial class Restaurante
{
    [Key]
    [StringLength(14)]
    public string Cnpj { get; set; } = null!;

    [StringLength(80)]
    public string Nome { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("Hash_senha")]
    [StringLength(255)]
    public string HashSenha { get; set; } = null!;

    [Column("Fk_Id_endereco")]
    public int FkIdEndereco { get; set; }

    [ForeignKey("FkIdEndereco")]
    [InverseProperty("Restaurantes")]
    public virtual Endereco FkIdEnderecoNavigation { get; set; } = null!;
}
