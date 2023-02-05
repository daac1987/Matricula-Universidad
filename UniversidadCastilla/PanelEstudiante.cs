using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversidadCastilla.Clases;
using UniversidadCastilla.ConexionBD;

namespace UniversidadCastilla
{
    public partial class PanelEstudiante : UserControl
    {
        public PanelEstudiante()
        {
            InitializeComponent();
            //se actualiza el data grid
            mostrarEstudiantes();
        }
        //creamos variables globales
        DateTime fecha;
        string fecha2;
        string nombre;
        int cedula;
        string codigoCarrera;

        private void button1_Click(object sender, EventArgs e)
        {
            //seleccionamos la fecha del calendario
            fecha = calendario.SelectionStart;
            txtFecha.Text = fecha.ToString(("dd'/'MM'/'yyyy"));
        }

        //boton para limpiar los textbox
        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        //limpiar los texbox
        public void borrarTxt()
        {
            txtCedula.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtCodCarrera.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        //verificamos que todos lo campos esten llenos y datos ingresados
        //correctamente
        public bool validarTxt ()
        {
            if (!txtCedula.Text.Equals(""))
            {
                try
                {
                    cedula = int.Parse(txtCedula.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se esperan numeros en el campo.");
                    txtCedula.Focus();
                    return false;

                }
                
                if (!txtNombre.Text.Equals(""))
                {
                    nombre = txtNombre.Text;
                    if (!txtCodCarrera.Text.Equals(""))
                    {
                        codigoCarrera = txtCodCarrera.Text;
                        if (!txtFecha.Text.Equals(""))
                        {
                            fecha2 = txtFecha.Text;
                            //aca se crea el estudiante, ya todos lo campos fueron 
                            //validados
                            borrarTxt();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No selecciono la fecha.");
                            txtFecha.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ingreso el codigo de carrera.");
                        txtCodCarrera.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No ingreso el nombre.");
                    txtNombre.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("No ingreso el numero de cedula.");
                txtCedula.Focus();
                return false;
            }
        }

        //insertar estudiantes
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //si la validacion es true se crea el estudiante
            if (validarTxt()==true)
            {
                Estudiante estudiante = new Estudiante(cedula, nombre,
                    fecha, codigoCarrera);
                EstudianteBD.InsertarEstudiante(estudiante);
                //se actualiza el data grid
                mostrarEstudiantes();
                borrarTxt();
            }
        }

        //borrar estudiante
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                int id = int.Parse(dataGrid.SelectedCells[0].Value.ToString());
                EstudianteBD.EliminarEstudiante(id);
                borrarTxt();
                //se actualiza el data grid
                mostrarEstudiantes();
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }

        //llenar data grid con datos de los estudiantes
        private void mostrarEstudiantes()
        {
            EstudianteBD estudianteBD = new EstudianteBD();
            DataTable dt = new DataTable();
            estudianteBD.mostrarEsutdiantes(ref dt);
            dataGrid.DataSource = dt;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCedula.Text = dataGrid.SelectedCells[0].Value.ToString();
                txtNombre.Text = dataGrid.SelectedCells[1].Value.ToString();
                txtFecha.Text = dataGrid.SelectedCells[2].Value.ToString();
                txtCodCarrera.Text = dataGrid.SelectedCells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }

        }

        //modificamos los estudiantes
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGrid.SelectedCells[0].Value.ToString());
                if (validarTxt() == true)
                {
                    Estudiante estudiante = new Estudiante(id, nombre,
                   fecha, codigoCarrera);
                    EstudianteBD.ActualizarEstudiante(estudiante);
                    borrarTxt();
                    //se actualiza el data grid
                    mostrarEstudiantes();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }
    }
}
