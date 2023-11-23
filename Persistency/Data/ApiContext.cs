using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistency.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detalle_Pedido> Detalles_Pedidos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Gama_Producto> Gamas_Productos { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Detalle_Pedido>().HasKey(p=>new {p.PedidoId,p.ProductoId});
            modelBuilder.Entity<Pago>().HasKey(p=>new {p.Id,p.ClienteId});
        }
    }
}
