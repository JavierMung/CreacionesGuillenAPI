using System;
using System.Collections.Generic;

namespace webAPI.Models;

public partial class Trabajador
{
    public int IdTrabajador { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Dirección { get; set; }

    public string? NumeroTelefono { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Role? IdRolNavigation { get; set; }
}
