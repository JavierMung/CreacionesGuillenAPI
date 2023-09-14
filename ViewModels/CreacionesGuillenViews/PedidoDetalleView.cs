namespace webAPI.ViewModels.CreacionesGuillenViews
{
    public record PedidoDetalleView<T>(T Encargado, int Cantidad, String Color, T Producto);
}
