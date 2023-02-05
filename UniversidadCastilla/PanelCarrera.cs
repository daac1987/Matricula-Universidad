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
    public partial class PanelCarrera : UserControl
    {
        public PanelCarrera()
        {
            InitializeComponent();
            mostrarCarrera();
        }
        string codigoCarrera;
        string nombre;
        int version;
        string facultad;
        string sede;
        public void borrarTxt()
        {
            txtCodigoCarrera.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtVersion.Text = string.Empty;
            txtFacultad.Text = string.Empty;
            cbSede.SelectedIndex = -1;
        }

        public bool validarTxt ()
        {
            if (!txtCodigoCarrera.Text.Equals(""))
            {
                codigoCarrera = txtCodigoCarrera.Text;
                if (!txtNombre.Text.Equals(""))
                {
                    nombre = txtNombre.Text;
                    if (!txtVersion.Text.Equals(""))
                    {
                        try
                        {
                            version = int.Parse(txtVersion.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("En version se espera un numero");
                            return false;
                        }
                        if (cbSede.SelectedIndex>-1)
                        {
                            sede = cbSede.SelectedItem.ToString();
                            if (!txtFacultad.Text.Equals(""))
                            {
                                facultad = txtFacultad.Text;
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("No ingreso la facultad");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No selecciono la sede");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ingreso el numero de version");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No ingreso el nombre");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No ingreso el Codigo de Carrera");
                return false;
            }
        }
        private void mostrarCarrera()
        {
            CarreraBD carreraBD = new CarreraBD();
            DataTable dt = new DataTable();
            carreraBD.mostrarCarrera(ref dt);
            dataGrid.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigoCarrera.Text = dataGrid.SelectedCells[0].Value.ToString();
                txtNombre.Text = dataGrid.SelectedCells[1].Value.ToString();
                txtVersion.Text = dataGrid.SelectedCells[2].Value.ToString();
                txtFacultad.Text = dataGrid.SelectedCells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (validarTxt()==true)
            {
                Carrera carrera = new Carrera(codigoCarrera,nombre,version,sede,facultad);
                CarreraBD.InsertarCarrera(carrera);
                mostrarCarrera();
                borrarTxt();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (validarTxt() == true)
            {
                Carrera carrera = new Carrera(codigoCarrera, nombre, version, sede, facultad);
                CarreraBD.ActualizarCarrera(carrera);
                mostrarCarrera();
                borrarTxt();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                string codigoCar =dataGrid.SelectedCells[0].Value.ToString();
                CarreraBD.EliminarCarrera(codigoCar);
                borrarTxt();
                //se actualiza el data grid
                mostrarCarrera();
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }
    }
}
