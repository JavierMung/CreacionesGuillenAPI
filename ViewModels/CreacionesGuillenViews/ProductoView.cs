namespace webAPI.ViewModels.CreacionesGuillenViews
{
    public record ProductoView(int IdProducto, string Nombre, int Cantidad, decimal Precio);
    public record PedidoView(int IdPedido, string Producto, string Cliente, string Encargado, int cantidad, string color, decimal Total);
}
