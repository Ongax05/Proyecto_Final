using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGenericInt<Cliente>
    {
        Task<IEnumerable<Cliente>> ClientesQueHanHechoPagosJuntoConRepInfo();
        Task<IEnumerable<Cliente>> ClientesQueNoHanHechoPagosJuntoConRepInfo();
        Task<IEnumerable<Cliente>> ClientesJuntoConRepInfo();
        Task<IEnumerable<Cliente>> ClientesQueNoHanRealizadoPagos ();
    }
}