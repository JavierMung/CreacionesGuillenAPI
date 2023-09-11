using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services.CreacionesGuillenServices;

namespace webAPI.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class ProductosController : Controller
	{
		private readonly IProductoService _productoService;
		public ProductosController(IProductoService productoService)
		{
			_productoService = productoService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Producto>>> GetAllProductos()
		{
			var Productos = await _productoService.GetAllProductos();
			return Ok(Productos);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<List<Producto>>> GetProducto(int id)
		{
			var resultado = await _productoService.GetProducto(id);
			if (resultado == null)
			{
				NotFound("No se encontro el producto");
			}
			return Ok(resultado);
		}
		[HttpPost("agregarProducto")]
		public async Task<ActionResult<List<Producto>>> AddProducto(Producto p)
		{
			var resultado = await _productoService.AddProducto(p);
			return Ok(resultado);

		}
		[HttpPut("actualizarProducto")]
		public async Task<ActionResult<List<Producto>>> UpdateProducto(int id, Producto p)
		{
			var resultado = await _productoService.UpdateProducto(id, p);
			if (resultado == null)
			{
				NotFound("No se encontro el producto");
			}
			return Ok(resultado);
		}
		[HttpPost("eliminarProducto")]
		public async Task<ActionResult<List<Producto>>> DeleteProducto(int id)
		{
			var resultado = await _productoService.DeleteProducto(id);
			if (resultado == null)
			{
				NotFound("No se encontro el producto");
			}
			return Ok(resultado);
		}
	}
}
