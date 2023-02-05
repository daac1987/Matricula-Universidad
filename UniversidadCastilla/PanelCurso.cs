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
    public partial class PanelCurso : UserControl
    {
        public PanelCurso()
        {
            InitializeComponent();
            mostrarCursos();
        }
        string codigoCurso;
        string nombre;
        int cantidadEstudiantes;
        int idProfesor;
        string codigoCarrera;

        //limpiar los texbox
        public void borrarTxt()
        {
            txtCodigo.Text = string.Empty;
            txtCantidadEstudiantes.Text = string.Empty;
            txtCodCarrera.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtIdProfesor.Text = string.Empty;
        }

        //llenar data grid con datos de los estudiantes
        private void mostrarCursos()
        {
            CursoDB cursoDB = new CursoDB();
            DataTable dt = new DataTable();
            cursoDB.mostrarCurso(ref dt);
            dataGrid2.DataSource = dt;
        }

        //verificamos que todos lo campos esten llenos y datos ingresados
        //correctamente
        public bool validarTxt()
        {
            if (!txtCodigo.Text.Equals(""))
            {
                codigoCurso = txtCodigo.Text;
                if (!txtNombre.Text.Equals(""))
                {
                    nombre = txtNombre.Text;
                    if (!txtCantidadEstudiantes.Text.Equals(""))
                    {
                        try
                        {
                            cantidadEstudiantes = int.Parse(txtCantidadEstudiantes.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Se esperan numeros en el campo.");
                            txtCantidadEstudiantes.Focus();
                            return false;
                        }
                        
                        if (!txtIdProfesor.Text.Equals(""))
                        {
                            try
                            {
                                idProfesor = int.Parse(txtIdProfesor.Text);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Se esperan numeros en el campo.");
                                txtIdProfesor.Focus();
                                return false;
                            }

                             if (!txtCodCarrera.Text.Equals(""))
                             {
                                   codigoCarrera = txtCodCarrera.Text;
                                   return true;
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
                            MessageBox.Show("No ingreso la cedula del Profesor.");
                            txtIdProfesor.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ingreso la cantidad de estudiantes.");
                        txtCantidadEstudiantes.Focus();
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
                MessageBox.Show("No ingreso el codigo del curso.");
                txtCodigo.Focus();
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        private void dataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigo.Text = dataGrid2.SelectedCells[0].Value.ToString();
                txtNombre.Text = dataGrid2.SelectedCells[1].Value.ToString();
                txtCantidadEstudiantes.Text = dataGrid2.SelectedCells[2].Value.ToString();
                txtIdProfesor.Text = dataGrid2.SelectedCells[3].Value.ToString();
                txtCodCarrera.Text = dataGrid2.SelectedCells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //si la validacion es true se crea el estudiante
            if (validarTxt() == true)
            {
                Curso curso = new Curso(codigoCurso, nombre, cantidadEstudiantes, idProfesor
                    , codigoCarrera);
                CursoDB.InsertarCurso(curso);
                //se actualiza el data grid
                mostrarCursos();
                borrarTxt();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                CursoDB.EliminarCurso(txtCodigo.Text);
                borrarTxt();
                //se actualiza el data grid
                mostrarCursos();
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
                codigoCurso = dataGrid2.SelectedCells[0].Value.ToString();
                if (validarTxt() == true)
                {
                    Curso curso = new Curso(codigoCurso,nombre,cantidadEstudiantes,idProfesor,codigoCarrera);
                    CursoDB.ActualizarCurso(curso);
                    borrarTxt();
                    //se actualiza el data grid
                    mostrarCursos();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }
    }
}
