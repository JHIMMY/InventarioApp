using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;

namespace Inventario.Biz;
public class ManejadorEmpleados : IManejadorEmpleados
{
    IRepositorio<Empleado> repositorio;

    public ManejadorEmpleados(IRepositorio<Empleado> repositorio)
    {
        this.repositorio = repositorio;
    }

    public List<Empleado> Listar => repositorio.Read;

    public bool Agregar(Empleado entidad)
    {
        return repositorio.Create(entidad);
    }

    public Empleado BuscarPorId(string id)
    {
        return Listar.Where(e => e.Id == id).SingleOrDefault();
    }

    public bool Eliminar(string id)
    {
        return repositorio.Delete(id);
    }

    public List<Empleado> EmpleadosPorArea(string area)
    {
        throw new NotImplementedException();
    }

    public bool Modificar(Empleado entidad)
    {
        return repositorio.Update(entidad);
    }
}
