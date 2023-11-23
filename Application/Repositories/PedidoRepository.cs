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
    public class PedidoRepository : GenericIntRepository<Pedido>, IPedido
    {
        public PedidoRepository(ApiContext context) : base(context)
        {
        }
    }
}