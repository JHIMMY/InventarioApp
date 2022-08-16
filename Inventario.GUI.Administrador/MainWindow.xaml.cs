using Inventario.Biz;
using Inventario.COMMON.Entidades;
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

        if (dataGridEmpleados.SelectedItem is Empleado empleado)
        {
            txtBlockEmpleadosId.Text = empleado.Id;
            txtBoxEmpleadosNombre.Text = empleado.Nombre;
            txtBoxEmpleadosApellidos.Text = empleado.Apellidos;
            txtBoxEmpleadosArea.Text = empleado.Area;

            accionEmpleados = Accion.Editar;
            PonerBotonesEmpleadosEnEdicion(true);
        }


    }

    private void BtnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
    {
        if (accionEmpleados == Accion.Nuevo)
        {
            var empleado = new Empleado()
            {
                Nombre = txtBoxEmpleadosNombre.Text,
                Apellidos = txtBoxEmpleadosApellidos.Text,
                Area = txtBoxEmpleadosArea.Text,
            };

            if (manejadorEmpleados.Agregar(empleado))
            {
                MessageBox.Show("Empleado agreagado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCamposDeEmpleados();
                ActualizarTablaEmpleados();
                PonerBotonesEmpleadosEnEdicion(false);
            }
            else
            {
                MessageBox.Show("El empleado no se pudo agregar", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            // editar
            var empleado = dataGridEmpleados.SelectedItem as Empleado;

            empleado.Nombre = txtBoxEmpleadosNombre.Text;
            empleado.Apellidos = txtBoxEmpleadosApellidos.Text;
            empleado.Area = txtBoxEmpleadosArea.Text;

            if (manejadorEmpleados.Modificar(empleado))
            {
                MessageBox.Show("Empleado modificado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCamposDeEmpleados();
                ActualizarTablaEmpleados();
                PonerBotonesEmpleadosEnEdicion(false);
            }
            else
            {
                MessageBox.Show("El empleado no se pudo actualizar", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void BtnEmpleadosCancelar_Click(object sender, RoutedEventArgs e)
    {
        LimpiarCamposDeEmpleados();
        PonerBotonesEmpleadosEnEdicion(false);
    }

    private void BtnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
    {
        if (dataGridEmpleados.SelectedItem is Empleado empleado)
        {

            if (MessageBox.Show("Realmente deseas eliminar este empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manejadorEmpleados.Eliminar(empleado.Id))
                {
                    MessageBox.Show("Empleado eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);

                    ActualizarTablaEmpleados();
                }
                else
                {
                    MessageBox.Show("No se pudo elimanar el empleado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
