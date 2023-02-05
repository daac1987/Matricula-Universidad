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
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
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
                    PanelMatricula panelMatricula  = new PanelMatricula();
                    panelMatricula.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelMatricula);
                    break;
                case 1:
                    PanelDirector panelDirector = new PanelDirector();
                    panelDirector.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelDirector);
                    break;
                case 2:
                    PanelEstudiante panelEstudiante = new PanelEstudiante();
                    panelEstudiante.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelEstudiante);
                    break; 
                case 3:
                    PanelVerEstadoAsistencia panelVerEstadoAsistencia = new PanelVerEstadoAsistencia();
                    panelVerEstadoAsistencia.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelVerEstadoAsistencia);
                    break; 
                case 4:
                    PanelCurso panelCurso = new PanelCurso();
                    panelCurso.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelCurso);
                    break;
                case 5:
                    PanelCarrera panelCarrera = new PanelCarrera();
                    panelCarrera.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelCarrera);
                    break;
                 case 6:
                    PanelProfesor panelProfesor = new PanelProfesor();
                    panelProfesor.Dock = DockStyle.Fill;
                    panelPrincipal.Controls.Add(panelProfesor);
                    break;
            }
        }
    }
}
