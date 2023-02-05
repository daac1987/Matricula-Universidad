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
    public partial class formDirector : Form
    {
        public formDirector()
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
                    PanelCurso panelCurso = new PanelCurso();
                    panelCurso.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelCurso);
                    break;
                case 1:
                    PanelEstudiante panelEstudiante  = new PanelEstudiante();
                    panelEstudiante.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelEstudiante);
                    break;
            }
        }
    }
}
