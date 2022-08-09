using Inventario.COMMON.Entidades;

namespace Inventario.COMMON.Interfaces;
public interface IManejadorVales : IManejadorGenerico<Vale>
{
    List<Vale> ValesPorLiquidar();
    List<Vale> ValesEnIntervalo(DateTime inicio, DateTime fin);
}
