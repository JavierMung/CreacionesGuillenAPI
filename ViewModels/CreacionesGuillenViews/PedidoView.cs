namespace webAPI.ViewModels.CreacionesGuillenViews
{
    public record PedidoView(int IdPedido, string Producto, string Encargado, int cantidad, string color, decimal Total);

}
