using System;
using System.Collections.Generic;

namespace webAPI.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Dirección { get; set; }

    public string? NumeroTelefono { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
