using webAPI.Models;
using webAPI.ViewModels.CreacionesGuillenViews;

namespace webAPI.Services.CreacionesGuillenServices
{
    public interface IProductoService
	{
		Task<List<ProductoView>> GetAllProductos();
		Task<ProductoView?> GetProducto(int id);
		Task<List<ProductoView>> AddProducto(Producto p);
		Task<List<ProductoView>?> UpdateProducto(int id, Producto p);
		Task<List<ProductoView>?> DeleteProducto(int id);
	}
}
