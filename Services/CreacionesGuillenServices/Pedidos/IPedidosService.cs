using webAPI.Models;
using webAPI.ViewModels;
using webAPI.ViewModels.CreacionesGuillenViews;

namespace webAPI.Services.CreacionesGuillenServices.Pedidos
{
	public interface IPedidosService
	{
		Task<List<List<PedidoView>>> GetPedidos();
		Task<List<PedidoView>?> GetPedido(int id);
		Task<List<PedidoView>> AddPedido(List<DetallePedido> p);
		Task<List<PedidoView>?> UpdatePedido(int id, Pedido p);
	}
}
