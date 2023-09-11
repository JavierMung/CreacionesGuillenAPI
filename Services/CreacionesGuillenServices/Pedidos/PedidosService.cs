using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Services.CreacionesGuillenServices.Pedidos
{
	public class PedidosService : IPedidosService
	{
		public readonly CreacionesGuillenContext _context;
		public PedidosService(CreacionesGuillenContext context)
		{
			_context = context;
		}
		public async Task<List<DetallePedido>?> GetPedido(int id)
		{
			var pedidos = _context.DetallePedidos.Where(detalle => detalle.IdDetalle == id);
			if (pedidos == null)
			{
				return null;
			}
			return await pedidos.ToListAsync();
		}
		public async Task<List<Pedido>> AddPedido(List<DetallePedido> detalles)
		{

			await _context.Pedidos.AddAsync(new Pedido { FechaPedido = DateTime.Now });
			foreach (var detalle in detalles)
			{
				await _context.DetallePedidos.AddAsync(detalle);
			}
			_context.SaveChanges();
			return await _context.Pedidos.ToListAsync();
		}
		public async Task<List<List<DetallePedido>>> GetPedidos()
		{
			var detalles = await _context.DetallePedidos
				.GroupBy(detalle => detalle.IdDetalle)
				.Select(grupo => grupo.ToList())
				.ToListAsync();
			return detalles;
		}

		public Task<List<Pedido>?> UpdatePedido(int id, Pedido p)
		{
			throw new NotImplementedException();
		}
	}
}
