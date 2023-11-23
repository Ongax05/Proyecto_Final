using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistency.Data;

namespace Application.Repositories
{
    public class PagoRepository : GenericStringRepository<Pago>, IPago
    {
        public PagoRepository(ApiContext context) : base(context)
        {
        }
    }
}