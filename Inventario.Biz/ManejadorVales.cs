using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System.Linq;

namespace Inventario.Biz;
public class ManejadorVales : IManejadorVales
{
    IRepositorio<Vale> repositorio;

    public ManejadorVales(IRepositorio<Vale> repositorio)
    {
        this.repositorio = repositorio;
    }

    public List<Vale> Listar => repositorio.Read;

    public bool Agregar(Vale entidad)
    {
        return repositorio.Create(entidad);
    }

    public Vale BuscarPorId(string id)
    {
        return Listar.Where(e => e.Id == id).SingleOrDefault();
    }

    public bool Eliminar(string id)
    {
        return repositorio.Delete(id);
    }

    public bool Modificar(Vale entidad)
    {
        return repositorio.Update(entidad);
    }

    public List<Vale> ValesEnIntervalo(DateTime inicio, DateTime fin)
    {
        throw new NotImplementedException();
    }

    public List<Vale> ValesPorLiquidar()
    {
        throw new NotImplementedException();
    }
}
