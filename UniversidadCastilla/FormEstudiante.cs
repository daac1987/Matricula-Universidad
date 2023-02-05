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
    public partial class FormEstudiante : Form
    {
        public FormEstudiante()
        {
            InitializeComponent();
            mostrarCurso();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingreso ingreso = new ingreso();
            ingreso.Show();
            this.Hide();
        }
        private void mostrarCurso()
        {
            int id = ingreso.idIngreso;
            EstudianteBD estudianteBD = new EstudianteBD();
            DataTable dt = new DataTable();
            estudianteBD.mostrarEsutdiantesPorId(ref dt, id);
            dataGrid2.DataSource = dt;
        }


    }
}
