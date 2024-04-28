namespace Entidades;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public string UF { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public ushort Numero { get; set; }

    public string Complemento { get; set; } = null!;

    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
