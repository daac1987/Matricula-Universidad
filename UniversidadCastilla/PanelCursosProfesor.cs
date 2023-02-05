using DocumentFormat.OpenXml.Office2010.Excel;
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
using static System.Net.WebRequestMethods;

namespace UniversidadCastilla
{
    public partial class PanelCursosProfesor : UserControl
    {
        public PanelCursosProfesor()
        {
            InitializeComponent();
            mostrarCursosProfesor();
        }
        private void mostrarCursosProfesor()
        {
            try
            {
                //extraigo la cedula de ingreso para poder usarla en el where de la BD
                //para mostrar solo los cursos asociados
                int id = ingreso.idIngreso;
                ProfesorBD profesorBD = new ProfesorBD();
                DataTable dt = new DataTable();
                profesorBD.mostrarCursoProfesor(ref dt, id);
                dataGrid2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
