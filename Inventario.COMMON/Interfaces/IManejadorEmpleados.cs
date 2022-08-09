using Inventario.COMMON.Entidades;

namespace Inventario.COMMON.Interfaces;
public interface IManejadorEmpleados : IManejadorGenerico<Empleado>
{
    List<Empleado> EmpleadosPorArea(string area);
}
