using System;
using System.Collections.Generic;

namespace webAPI.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
}
