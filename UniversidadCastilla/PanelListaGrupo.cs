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
    public partial class PanelListaGrupo : UserControl
    {
        public PanelListaGrupo()
        {
            InitializeComponent();
        }
        int grupo;
        DateTime fecha;
        int numeroMatricuala;
        string estadoAsistencia;
        string fecha2;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!txtGrupo.Text.Equals(""))
            {
                try
                {
                    grupo = int.Parse(txtGrupo.Text);
                    mostrarGrupos(grupo);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se espera en casilla Grupo un numero.");
                    txtGrupo.Focus();
                }

            }
            else
            {
                MessageBox.Show("No ingreso el dato en casilla Grupo.");
                txtGrupo.Focus();
            }
        }

        private void mostrarGrupos(int grupo)
        {
            ProfesorBD profesorBD = new ProfesorBD();
            DataTable dt = new DataTable();
            profesorBD.mostrarGrupo(ref dt,grupo);
            dataGrid.DataSource = dt;
        }

        public void borrarTxt()
        {
            txtGrupo.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtIdAlumno.Text = string.Empty;
            cbAsistencia.Text = string.Empty;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdAlumno.Text = dataGrid.SelectedCells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fecha = calendario.SelectionStart;
            txtFecha.Text = fecha.ToString(("dd'/'MM'/'yyyy"));
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (validarTxt()==true)
            {
                Asistencia asistencia = new Asistencia(numeroMatricuala,fecha,estadoAsistencia);
                ProfesorBD.ingresarAsistencia(asistencia);
                borrarTxt();
            }
        }

        public bool validarTxt()
        {
            if (!txtIdAlumno.Text.Equals(""))
            {
                numeroMatricuala = int.Parse(dataGrid.SelectedCells[4].Value.ToString());
                if (cbAsistencia.SelectedIndex > -1)
                {
                    estadoAsistencia = cbAsistencia.SelectedItem.ToString();
                    if (!txtFecha.Text.Equals(""))
                    {
                        fecha2 = txtFecha.Text;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No seleccion la fecha.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccion el estado del estudiante.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No seleccion el estudiante de la tabla.");
                return false;
            }
        }
    }
}
