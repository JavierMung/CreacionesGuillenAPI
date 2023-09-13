using System;
using System.Collections.Generic;

namespace webAPI.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public int IdTamaño { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
