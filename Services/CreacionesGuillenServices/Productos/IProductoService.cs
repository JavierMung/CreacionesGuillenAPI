using webAPI.Models;

namespace webAPI.Services.CreacionesGuillenServices
{
	public interface IProductoService
	{
		Task<List<Producto>> GetAllProductos();
		Task<Producto?> GetProducto(int id);
		Task<List<Producto>> AddProducto(Producto p);
		Task<List<Producto>?> UpdateProducto(int id, Producto p);
		Task<List<Producto>?> DeleteProducto(int id);
	}
}
