using System;
using System.Collections.Generic;

namespace Entities;

public partial class Address
{
    public int IdAddress { get; set; }

    public string Uf { get; set; } = null!;

    public string City { get; set; } = null!;

    public string District { get; set; } = null!;

    public string Street { get; set; } = null!;

    public ushort Number { get; set; }

    public string Complement { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
