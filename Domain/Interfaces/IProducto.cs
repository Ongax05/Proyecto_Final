using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProducto : IGenericString<Producto> { 
        Task<IEnumerable<Producto>> ProductosQueNoHanEstadoEnPedidos ();
    }
}
