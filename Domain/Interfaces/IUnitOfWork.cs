namespace Domain.Interfaces;

public interface IUnitOfWork
{
    ICliente Clientes { get; }
    IEmpleado Empleados { get; }
    IGama_Producto Gamas_Productos { get; }
    IOficina Oficinas { get; }
    IPago Pagos { get; }
    IPedido Pedidos { get; }
    IProducto Productos { get; }
    Task<int> SaveAsync();
}
