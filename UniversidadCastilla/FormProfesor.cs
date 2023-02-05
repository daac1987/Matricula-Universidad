using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversidadCastilla
{
    public partial class FormProfesor : Form
    {
        public FormProfesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingreso ingreso = new ingreso();
            ingreso.Show();
            this.Hide();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            switch (cbOperacion.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("No ingreso eleccion");
                    break;
                case 0:
                    PanelCursosProfesor panelCursosProfesor = new PanelCursosProfesor();
                    panelCursosProfesor.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelCursosProfesor);
                    break;
                case 1:
                    PanelListaGrupo grupo = new PanelListaGrupo();
                    grupo.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(grupo);
                    break;
                case 2:
                    PanelVerEstadoAsistencia verEstadoAsistencia = new PanelVerEstadoAsistencia();
                    verEstadoAsistencia.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(verEstadoAsistencia);
                    break;
            }
        }

    }
}
