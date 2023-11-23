using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistency.Data;

namespace Application.Repositories
{
    public class ProductoRepository : GenericStringRepository<Producto>, IProducto
    {
        public ProductoRepository(ApiContext context) : base(context)
        {
        }
    }
}