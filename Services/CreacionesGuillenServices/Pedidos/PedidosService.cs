﻿using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.ViewModels.CreacionesGuillenViews;

namespace webAPI.Services.CreacionesGuillenServices.Pedidos
{
    public class PedidosService : IPedidosService
    {
        public readonly CreacionesGuillenContext _context;
        public PedidosService(CreacionesGuillenContext context)
        {
            _context = context;
        }
        public async Task<PedidoView<String>?> GetPedido(int id)
        {
            var Pedido = await _context.Pedidos.Where(pedido => pedido.IdPedido == id).FirstOrDefaultAsync();

            if (Pedido == null) return null;

            var pedidos = await _context.DetallePedidos.Where(detalle => detalle.IdDetalle == id).ToListAsync();

            var p = new List<PedidoDetalleView<String>>();
            var total = 0m;
            foreach (var pedido in pedidos)
            {
                var pedidoView = new PedidoDetalleView<String>(pedido.IdEncargadoNavigation.Nombre, pedido.Cantidad, pedido.Color, pedido.IdProductoNavigation.Nombre);// Puedes calcular el total según tu lógica aquí
                total += pedido.Cantidad * pedido.IdProductoNavigation.Precio;

                p.Add(pedidoView);

            }
            var resultado = new PedidoView<String>(Pedido.IdClienteNavigation.Nombre,p, total);
            return resultado;
        }
        public async Task<List<PedidoView>> AddPedido(List<DetallePedido> detalles)
        {
            var total = 0m;
            foreach (var detalle in detalles)
            {
                var precio = detalle.IdProductoNavigation?.Precio ?? 0m;
                total += detalle.Cantidad * precio;
            }
            await _context.Pedidos.AddAsync(new Pedido { FechaPedido = DateTime.Now, Total = total });
            _context.SaveChanges();
            int ultimoPedidoId = await _context.Pedidos
                                .OrderByDescending(p => p.IdPedido)
                                .Select(p => p.IdPedido)
                                .FirstOrDefaultAsync();
            foreach (var detalle in detalles)
            {
                detalle.IdPedido = ultimoPedidoId;
                await _context.DetallePedidos.AddAsync(detalle);
            }
            _context.SaveChanges();
            return await _context.Pedidos.ToListAsync();
        }
        public async Task<List<List<PedidoView>>> GetPedidos()
        {
            var detalles = await _context.DetallePedidos
                .GroupBy(detalle => detalle.IdDetalle)
                .Select(grupo => grupo.ToList())
                .ToListAsync();


            List<List<PedidoView>> pedidos = new List<List<PedidoView>>();

            foreach (var pedidoDetalle in detalles)
            {
                var Pedido = new List<PedidoView>();
                foreach (var detalle in pedidoDetalle)
                {
                    // Obtener el nombre del Producto, Cliente y Encargado en una sola consulta
                    var pedidoView = new PedidoView(
                        detalle.IdPedido,
                        detalle.IdProductoNavigation?.Nombre ?? string.Empty,
                        detalle.IdEncargadoNavigation?.Nombre ?? string.Empty,
                        detalle.Cantidad,
                        detalle.Color ?? string.Empty,
                        0 // Puedes calcular el total según tu lógica aquí
                    );

                    Pedido.Add(pedidoView);
                }
                pedidos.Add(Pedido);
            }
            return pedidos;
        }

        public Task<List<PedidoView>?> UpdatePedido(int id, Pedido p)
        {
            throw new NotImplementedException();
        }
        private async Task<List<PedidoView>> obtenerLista()
        {

        }
    }
}
