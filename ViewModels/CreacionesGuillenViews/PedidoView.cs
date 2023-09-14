namespace webAPI.ViewModels.CreacionesGuillenViews
{
    public record PedidoView<T> (T Cliente , List<PedidoDetalleView<T>> Pedidos, decimal Total);


}
