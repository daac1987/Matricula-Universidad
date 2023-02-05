
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversidadCastilla.Clases;
using UniversidadCastilla.ConexionBD;

namespace UniversidadCastilla
{
    public partial class PanelDirector : UserControl
    {
        public PanelDirector()
        {
            InitializeComponent();
            mostrarDirector();
        }
        DateTime fecha;
        int id;
        string nombre;
        string codigoCarrera;
        string fechaIngreso;
        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }
        public void borrarTxt()
        {
            txtCedula.Text = string.Empty;
            txtCodigoCarrera.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void mostrarDirector()
        {
            DirectorBD directorBD = new DirectorBD();
            DataTable dt = new DataTable();
            directorBD.mostrarDirector(ref dt);
            dataGrid2.DataSource = dt;
        }

        private void btnFI_Click(object sender, EventArgs e)
        {
            fecha = calendario.SelectionStart;
            txtFechaInicio.Text = fecha.ToString(("dd'/'MM'/'yyyy"));
        }

        private void dataGrid2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCedula.Text = dataGrid2.SelectedCells[0].Value.ToString();
                txtNombre.Text = dataGrid2.SelectedCells[1].Value.ToString();
                txtFechaInicio.Text = dataGrid2.SelectedCells[2].Value.ToString();
                txtCodigoCarrera.Text = dataGrid2.SelectedCells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }
        }

        public bool validarTxt()
        {
            if (!txtCedula.Text.Equals(""))
            {
                try
                {
                    id = int.Parse(txtCedula.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("En la campo cedula se espera un numero.");
                    return false;
                }
                if (!txtNombre.Text.Equals(""))
                {
                    nombre = txtNombre.Text;
                    if (!txtCodigoCarrera.Text.Equals(""))
                    {
                        codigoCarrera= txtCodigoCarrera.Text;
                        if (!txtFechaInicio.Text.Equals(""))
                        {
                            fechaIngreso = txtFechaInicio.Text;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No selecciono la fecha.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ingreso el codigo carrera.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No ingreso el nombre.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No ingreso la cedula.");
                return false;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (validarTxt()==true)
            {
                Director director = new Director(id, nombre, fecha, codigoCarrera);
                DirectorBD.InsertarDirector(director);
                mostrarDirector();
                borrarTxt();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                int id = int.Parse(txtCedula.Text);
                DirectorBD.EliminarDirector(id);
                borrarTxt();
                //se actualiza el data grid
                mostrarDirector();
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text.Equals("")) ;
                {
                    int id = int.Parse(dataGrid2.SelectedCells[0].Value.ToString());
                    if (validarTxt() == true)
                    {
                        Director director = new Director(id,nombre,fecha,codigoCarrera);
                        DirectorBD.ActualizarDirector(director);
                        borrarTxt();
                        //se actualiza el data grid
                        mostrarDirector();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }
    }
}
