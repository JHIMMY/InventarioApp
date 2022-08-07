namespace Inventario.COMMON.Entidades;
public class Vale : Base
{
    public DateTime FechaHoraSolicitud { get; set; }
    public DateTime FechaEntrega { get; set; }
    public DateTime? FechaEntregaReal { get; set; }
    public List<Material> MaterialesPrestados { get; set; }
    public Empleado Solicitante { get; set; }
    public Empleado EncargadoAlmacen { get; set; }

    public Vale(DateTime fechaHoraSolicitud, DateTime fechaEntrega, List<Material> materialesPrestados, Empleado solicitante, Empleado encargadoAlmacen)
    {
        FechaHoraSolicitud = fechaHoraSolicitud;
        FechaEntrega = fechaEntrega;
        MaterialesPrestados = materialesPrestados;
        Solicitante = solicitante;
        EncargadoAlmacen = encargadoAlmacen;
    }
}