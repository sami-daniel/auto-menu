using System;
using System.Collections.Generic;

namespace Entities;

public partial class Restaurant
{
    public string Cnpj { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int FkAddressId { get; set; }

    public virtual Address FkAddress { get; set; } = null!;
}
