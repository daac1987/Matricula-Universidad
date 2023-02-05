using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversidadCastilla.ConexionBD;

namespace UniversidadCastilla
{
    public partial class PanelVerEstadoAsistencia : UserControl
    {
        public PanelVerEstadoAsistencia()
        {
            InitializeComponent();
        }
        int grupo;

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
            profesorBD.mostrarAsistenciaPorGrupo(ref dt, grupo);
            dataGrid.DataSource = dt;
        }
    }
}
