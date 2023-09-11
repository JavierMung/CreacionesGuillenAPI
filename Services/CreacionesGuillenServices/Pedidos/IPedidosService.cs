using webAPI.Models;

namespace webAPI.Services.CreacionesGuillenServices.Pedidos
{
	public interface IPedidosService
	{
		Task<List<List<DetallePedido>>> GetPedidos();
		Task<List<DetallePedido>?> GetPedido(int id);
		Task<List<Pedido>> AddPedido(List<DetallePedido> p);
		Task<List<Pedido>?> UpdatePedido(int id, Pedido p);
		Task<List<Pedido>?> DeletePedido(int id);
	}
}
