using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency.Data;

namespace Application.Repositories
{
    public class ProductoRepository : GenericStringRepository<Producto>, IProducto
    {
        private readonly ApiContext context;
        public ProductoRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Producto>> ProductosQueNoHanEstadoEnPedidos()
        {
            var ids = await context.Detalles_Pedidos.Select(p=>p.ProductoId).ToListAsync();
            var r = await context.Productos.Where(p => !ids.Contains(p.Id)).Include(p=>p.Gama_Producto).ToListAsync();
            return r;
        }
    }
}