using Inventario.COMMON.Entidades;

namespace Inventario.COMMON.Interfaces;

/// <summary>
/// this represent a contract for a CRUD like repo
/// </summary>
public interface IRepositorio<T> where T : Base
{
    bool Create(T entidad);
    List<T> Read { get; }
    bool Update(string id, T entidadModificada);
    bool Delete(T entidad);
}
