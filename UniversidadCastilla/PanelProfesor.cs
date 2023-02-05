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
    public partial class PanelProfesor : UserControl
    {
        public PanelProfesor()
        {
            InitializeComponent();
            mostrarProfesor();
        }
        int idProfesor;
        string nombre;
        DateTime fecha;
        string fechaIngreso;
        int idDirector;
        string tipo;
        string codigoCarrera;

        public void borrarTxt()
        {
            txtCedula.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtCodCarrera.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtIdDirector.Text = string.Empty;
            txtTipo.Text = string.Empty;
        }
        private void mostrarProfesor()
        {
           ProfesorCRUDBD profesorCRUDBD = new ProfesorCRUDBD();
            DataTable dt = new DataTable();
            profesorCRUDBD.mostrarProfesor(ref dt);
            dataGrid.DataSource = dt;
        }

        public bool validarTxt ()
        {
            if (!txtCedula.Text.Equals(""))
            {
                try
                {
                    idProfesor = int.Parse(txtCedula.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se espera en campo cedula un numero.");
                    return false;
                }
                if (!txtNombre.Text.Equals(""))
                {
                    nombre = txtNombre.Text;
                    if (!txtTipo.Text.Equals(""))
                    {
                        tipo = txtTipo.Text;
                        if (!txtIdDirector.Text.Equals(""))
                        {
                            try
                            {
                                idDirector = int.Parse(txtIdDirector.Text);
                                if (!txtCodCarrera.Text.Equals(""))
                                {
                                    codigoCarrera = txtCodCarrera.Text;
                                    if (!txtFecha.Text.Equals(""))
                                    {
                                        fechaIngreso = txtFecha.Text;
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No selecciono fecha.");
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No ingreso el codigo de carrera.");
                                    return false;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("En campo cedula de director se esperan numeros.");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No lleno el campo de cedula de director.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No lleno el campo de tipo de profesor.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No lleno el campo de nombre de profesor.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No lleno el campo de cedula de profesor.");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCedula.Text = dataGrid.SelectedCells[0].Value.ToString();
                txtNombre.Text = dataGrid.SelectedCells[1].Value.ToString();
                txtFecha.Text = dataGrid.SelectedCells[2].Value.ToString();
                txtTipo.Text = dataGrid.SelectedCells[3].Value.ToString();
                txtIdDirector.Text = dataGrid.SelectedCells[4].Value.ToString();
                txtCodCarrera.Text = dataGrid.SelectedCells[5].Value.ToString();
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

                Profesor profesor = new Profesor(idProfesor, nombre, fecha, tipo, idDirector,
                    codigoCarrera);
                ProfesorCRUDBD.InsertarProfesor(profesor);
                //se actualiza el data grid
                mostrarProfesor();
                borrarTxt();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //si la validacion es true se crea el estudiante
            if (validarTxt() == true)
            {

                Profesor profesor = new Profesor(idProfesor, nombre, fecha, tipo, idDirector,
                    codigoCarrera);
                ProfesorCRUDBD.ActualizarEstudiante(profesor);
                //se actualiza el data grid
                mostrarProfesor();
                borrarTxt();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                int id = int.Parse(dataGrid.SelectedCells[0].Value.ToString());
                ProfesorCRUDBD.EliminarProfesor(id);
                borrarTxt();
                //se actualiza el data grid
                mostrarProfesor();
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono fila");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //seleccionamos la fecha del calendario
            fecha = calendario.SelectionStart;
            txtFecha.Text = fecha.ToString(("dd'/'MM'/'yyyy"));
        }
    }
}
