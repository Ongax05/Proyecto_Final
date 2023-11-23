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
    public class ClienteRepository : GenericIntRepository<Cliente>, ICliente
    {
        private readonly ApiContext context;

        public ClienteRepository(ApiContext context)
            : base(context) {
                this.context = context;
             }

        public async Task<IEnumerable<Cliente>> ClientesJuntoConRepInfo()
        {
            var r = await context.Clientes
                .Include(c => c.Empleado)
                .ThenInclude(c => c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> ClientesQueHanHechoPagosJuntoConRepInfo()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count > 0)
                .Include(c => c.Empleado)
                .ThenInclude(c => c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> ClientesQueNoHanHechoPagosJuntoConRepInfo()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count == 0)
                .Include(c => c.Empleado)
                .ThenInclude(c => c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> ClientesQueNoHanRealizadoPagos()
        {
            var r = await context.Clientes.Where(p => p.Pagos.Count == 0).ToListAsync();
            return r;
        }
    }
}
