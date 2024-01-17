using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.Services.CreacionesGuillenServices;
using webAPI.ViewModels.CreacionesGuillenViews;

namespace webAPI.Services.CreacionesGuillenServices
{
	public class ProductoService : IProductoService
	{
		public readonly CreacionesGuillenContext _context;
		public ProductoService(CreacionesGuillenContext contex)
		{
			_context = contex;
		}
		public async Task<List<ProductoView>> AddProducto(Producto p)
		{
			_context.Productos.Add(p);
			await _context.SaveChangesAsync();

			return await obtenerLista();
		}

		public async Task<List<ProductoView>?> DeleteProducto(int id)
		{
			var producto = await _context.Productos.FindAsync(id);
			if (producto is null)
				return null;
			_context.Productos.Remove(producto);
			await _context.SaveChangesAsync();
			return await obtenerLista();
		}

		public async Task<List<ProductoView>> GetAllProductos()
		{
			return await obtenerLista();
		}

		public async Task<ProductoView?> GetProducto(int id)
		{
			var producto = await _context.Productos.FindAsync(id);
			if (producto is null) return null;
			return new ProductoView(producto.IdProducto, producto.Nombre ?? "Sin Nombre", producto.Cantidad, producto.Precio);
		}

		public async Task<List<ProductoView>?> UpdateProducto(int id, Producto p)
		{
			var producto = await _context.Productos.FindAsync(id);
			if (producto is null)
				return null;
			producto.Nombre = p.Nombre;
			producto.Precio = p.Precio;
			producto.Cantidad = p.Cantidad;
			await _context.SaveChangesAsync();

			return await obtenerLista();

		}

		private async Task<List<ProductoView>> obtenerLista()
		{
			var Productos = await _context.Productos.ToListAsync();
			List<ProductoView> productos = new List<ProductoView>();
			foreach (var producto in Productos)
			{
				productos.Add(new ProductoView(producto.IdProducto, producto.Nombre ?? "Sin Nombre", producto.Cantidad, producto.Precio));
			}
			return productos;
		}

	}
}
