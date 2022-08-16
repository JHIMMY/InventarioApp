using Inventario.Biz;
using Inventario.COMMON.Interfaces;
using Inventario.DAL;
using System;
using System.Windows;

namespace Inventario.GUI.Administrador;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    enum Accion
    {
        Nuevo,
        Editar
    }

    private Accion accionEmpleados;

    private readonly IManejadorEmpleados manejadorEmpleados;

    public MainWindow()
    {
        InitializeComponent();

        manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados());

        PonerBotonesEmpleadosEnEdicion(false);
        LimpiarCamposDeEmpleados();
        ActualizarTablaEmpleados();
    }

    private void ActualizarTablaEmpleados()
    {
        //dataGridEmpleados.ItemsSource = null;
        dataGridEmpleados.ItemsSource = manejadorEmpleados.Listar;
    }

    private void LimpiarCamposDeEmpleados()
    {
        txtBlockEmpleadosId.Text = string.Empty;
        txtBoxEmpleadosNombre.Clear();
        txtBoxEmpleadosApellidos.Clear();
        txtBoxEmpleadosArea.Clear();
    }

    private void PonerBotonesEmpleadosEnEdicion(bool value)
    {
        btnEmpleadosEditar.IsEnabled = !value;
        btnEmpleadosEliminar.IsEnabled = !value;
        btnEmpleadosNuevo.IsEnabled = !value;
        btnEmpleadosGuardar.IsEnabled = value;
        btnEmpleadosCancelar.IsEnabled = value;
    }

    private void btnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
    {
        LimpiarCamposDeEmpleados();
        PonerBotonesEmpleadosEnEdicion(true);
        accionEmpleados = Accion.Nuevo;
    }

    private void btnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
    {
        LimpiarCamposDeEmpleados();
        PonerBotonesEmpleadosEnEdicion(true);
        accionEmpleados = Accion.Editar;
    }

    private void btnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnEmpleadosCancelar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
    {

    }
}
