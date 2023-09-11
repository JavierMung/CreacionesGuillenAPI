using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.Services.CreacionesGuillenServices;

namespace webAPI.Services.CreacionesGuillenServices
{
    public class ProductoService : IProductoService
	{
		public readonly CreacionesGuillenContext _context;
		public ProductoService(CreacionesGuillenContext contex)
		{
			_context = contex;
		}
		public async Task<List<Producto>> AddProducto(Producto p)
		{
			_context.Productos.Add(p);
			await _context.SaveChangesAsync();
			return await _context.Productos.ToListAsync();
		}

		public async Task<List<Producto>?> DeleteProducto(int id)
		{
			var producto = await _context.Productos.FindAsync(id);
			if (producto is null)
				return null;
			_context.Productos.Remove(producto);
			await _context.SaveChangesAsync();
			return await _context.Productos.ToListAsync();
		}

		public async Task<List<Producto>> GetAllProductos()
		{
			return await _context.Productos.ToListAsync(); ;
		}

		public async Task<Producto?> GetProducto(int id)
		{
			var producto = await _context.Productos.FindAsync(id);
			return producto;
		}

		public async Task<List<Producto>?> UpdateProducto(int id, Producto p)
		{
			var producto = await _context.Productos.FindAsync(id);
			if (producto is null)
				return null;
			producto.Nombre = p.Nombre;
			producto.Precio = p.Precio;
			producto.Cantidad = p.Cantidad;
			await _context.SaveChangesAsync();

			return await _context.Productos.ToListAsync();

		}

	}
}
