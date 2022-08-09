using Inventario.COMMON.Entidades;

namespace Inventario.COMMON.Interfaces;
public interface IManejadorMateriales : IManejadorGenerico<Material>
{
    List<Material> MaterialesDeCategoria(string categoria);
}
