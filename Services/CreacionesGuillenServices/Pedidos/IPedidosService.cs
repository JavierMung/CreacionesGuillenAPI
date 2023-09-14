using webAPI.Models;
using webAPI.ViewModels;
using webAPI.ViewModels.CreacionesGuillenViews;

namespace webAPI.Services.CreacionesGuillenServices.Pedidos
{
    public interface IPedidosService
    {
        Task<List<PedidoView<String>>> GetPedidos();
        Task<PedidoView<String>> GetPedido(int id);
        Task<PedidoView<String>> AddPedido(PedidoView<String> pedido);
        Task<PedidoView<String>> UpdatePedido(PedidoView<String> pedido);
    }
}
