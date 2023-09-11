using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services.CreacionesGuillenServices;
using webAPI.ViewModels;

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
        public async Task<ActionResult<List<ProductoView>>> GetAllProductos()
        {
            var Productos = await _productoService.GetAllProductos();
            List<ProductoView> productos = new List<ProductoView>();
            foreach (var producto in Productos)
            {
                productos.Add(new ProductoView(producto.IdProducto, producto.Nombre ?? "Sin Nombre", producto.Cantidad , producto.Precio));
            }
            return Ok(productos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoView>> GetProducto(int id)
        {
            var resultado = await _productoService.GetProducto(id);

            if (resultado == null)
                return NotFound("No se encontro el producto");

            var Producto = new ProductoView(resultado.IdProducto, resultado.Nombre??"Sin Nombre", resultado.Cantidad, resultado.Precio);

            return Ok(Producto);
        }

        [HttpPost("agregarProducto")]
        public async Task<ActionResult<List<ProductoView>>> AddProducto(Producto p)
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
