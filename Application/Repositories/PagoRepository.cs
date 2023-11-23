using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency.Data;

namespace Application.Repositories
{
    public class PagoRepository : GenericStringRepository<Pago>, IPago
    {
        private readonly ApiContext context;
        public PagoRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pago>> PagosEn2008Paypal()
        {
            var r = await context.Pagos.Where(p => p.Fecha_Pago.Year == 2008 && p.Forma_Pago.ToLower() == "paypal").OrderByDescending(p=>p.Total).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pago>> PosiblesEstadosDePago()
        {
            var r = await context.Pagos.ToListAsync();
            return r.DistinctBy(p=>p.Forma_Pago).ToList();
        }
    }
}