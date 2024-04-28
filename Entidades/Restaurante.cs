namespace Entidades;

public partial class Restaurante
{
    public string Cnpj { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HashSenha { get; set; } = null!;

    public int FkIdEndereco { get; set; }

    public virtual Endereco FkIdEnderecoNavigation { get; set; } = null!;
}
