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
    public class ClienteRepository : GenericIntRepository<Cliente>, ICliente
    {
        public ClienteRepository(ApiContext context) : base(context)
        {
        }
    }
}