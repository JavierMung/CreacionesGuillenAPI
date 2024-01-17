using System;
using System.Collections.Generic;

namespace webAPI.Models;

public partial class DetallePedido
{
    public int IdDetalle { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int IdEncargado { get; set; }

    public int Cantidad { get; set; }

    public string Color { get; set; } = null!;

    public virtual Trabajador IdEncargadoNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
