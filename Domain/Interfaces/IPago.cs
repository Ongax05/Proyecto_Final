using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPago : IGenericString<Pago>
    {
        Task<IEnumerable<Pago>> PagosEn2008Paypal();
        Task<IEnumerable<Pago>> PosiblesEstadosDePago();
    }
}