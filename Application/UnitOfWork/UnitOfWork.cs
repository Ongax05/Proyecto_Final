using Application.Repositories;
using Domain.Interfaces;
using Persistency.Data;

namespace Aplication.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    private ICliente _Clientes;
    public ICliente Clientes
    {
        get
        {
            _Clientes ??= new ClienteRepository(_context);
            return _Clientes;
        }
    }
    private IEmpleado _Empleados;
    public IEmpleado Empleados
    {
        get
        {
            _Empleados ??= new EmpleadoRepository(_context);
            return _Empleados;
        }
    }
    private IGama_Producto _Gamas_Productos;
    public IGama_Producto Gamas_Productos
    {
        get
        {
            _Gamas_Productos ??= new Gama_ProductoRepository(_context);
            return _Gamas_Productos;
        }
    }
    private IOficina _Oficinas;
    public IOficina Oficinas
    {
        get
        {
            _Oficinas ??= new OficinaRepository(_context);
            return _Oficinas;
        }
    }
    private IPago _Pagos;
    public IPago Pagos
    {
        get
        {
            _Pagos ??= new PagoRepository(_context);
            return _Pagos;
        }
    }
    private IPedido _Pedidos;
    public IPedido Pedidos
    {
        get
        {
            _Pedidos ??= new PedidoRepository(_context);
            return _Pedidos;
        }
    }
    private IProducto _Productos;
    public IProducto Productos
    {
        get
        {
            _Productos ??= new ProductoRepository(_context);
            return _Productos;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
