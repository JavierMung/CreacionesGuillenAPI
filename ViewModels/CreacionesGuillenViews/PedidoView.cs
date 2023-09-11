namespace webAPI.ViewModels.CreacionesGuillenViews
{
    public record PedidoView(int IdPedido, string Producto, string Cliente, string Encargado, int cantidad, string color, decimal Total);

}
