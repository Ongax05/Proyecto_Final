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
    public class EmpleadoRepository : GenericIntRepository<Empleado>, IEmpleado
    {
        private readonly ApiContext context;
        public EmpleadoRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Empleado>> EmpleadoConJefeConJefe()
        {
            var r = await context.Empleados.Include(e=>e.Jefe).ThenInclude(e=>e.Jefe).ToListAsync();
            return r;
        }
    }
}