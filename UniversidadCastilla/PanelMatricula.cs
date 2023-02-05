
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
using UniversidadCastilla.Clases;
using UniversidadCastilla.ConexionBD;

namespace UniversidadCastilla
{
    public partial class PanelMatricula : UserControl
    {
        public PanelMatricula()
        {
            InitializeComponent();
            mostrarMatricula();
        }
        DateTime fecha1;
        DateTime fecha2;
        int cedula;
        string codigoCurso;
        int grupo;
        string periodo;
        string hora;
        string fechaInicio;
        string fechaFinal;
        string dia;
        string horarioCompleto;

        private void btnFFinal_Click(object sender, EventArgs e)
        {
            fecha2 = calendario.SelectionStart;
            txtFechaFinal.Text = fecha2.ToString(("dd'/'MM'/'yyyy"));
        }

        private void btnFI_Click(object sender, EventArgs e)
        {
            fecha1 = calendario.SelectionStart;
            txtFechaInicio.Text = fecha1.ToString(("dd'/'MM'/'yyyy"));
        }

        public bool validarTxt()
        {
            if (!txtCedula.Text.Equals(""))
            {
                try
                {
                    cedula = int.Parse(txtCedula.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se esperan numeros en el campo.");
                    txtCedula.Focus();
                    return false;
                }
                if (!txtCodigoCurso.Text.Equals(""))
                {
                    codigoCurso = txtCodigoCurso.Text;
                    if (!txtGrupo.Text.Equals(""))
                    {
                        try
                        {
                            grupo = int.Parse(txtGrupo.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Se esperan numeros en el Grupo.");
                            txtGrupo.Focus();
                            return false;
                        }
                        if (cbPeriodo.SelectedIndex > -1)
                        {
                            periodo = cbPeriodo.SelectedItem.ToString();
                            if (cbDia.SelectedIndex > -1)
                            {
                                dia = cbDia.SelectedItem.ToString();
                                if (cbHora.SelectedIndex > -1)
                                {
                                    hora = cbHora.SelectedItem.ToString();
                                    if (!txtFechaInicio.Text.Equals(""))
                                    {
                                        fechaInicio = txtFechaInicio.Text;
                                        if (!txtFechaFinal.Text.Equals(""))
                                        {
                                            fechaFinal = txtFechaFinal.Text;
                                            horarioCompleto = dia + "-" + hora;
                                            return true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("No seleciono Fecha Final.");
                                            txtFechaFinal.Focus();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No seleciono Fecha Inicio.");
                                        txtFechaInicio.Focus();
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No seleciono el Hora.");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No seleciono el Dia.");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No seleciono el Periodo.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se lleno el campo Grupo.");
                        txtGrupo.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No se lleno el campo Codigo Curso.");
                    txtCodigoCurso.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("No se lleno el campo Cedula.");
                txtCedula.Focus();
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrarTxt();
        }

        public void borrarTxt()
        {
            txtCedula.Text = string.Empty;
            txtCodigoCurso.Text = string.Empty;
            txtFechaFinal.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            cbHora.Text = string.Empty;
            cbPeriodo.Text = string.Empty;
        }

        //llenar data grid con datos de los estudiantes
        private void mostrarMatricula()
        {
            MatriculaBD matriculaBD = new MatriculaBD();
            DataTable dt= new DataTable();
            matriculaBD.mostrarMatriculaPorCurso(ref dt,1);
            dataGrid2.DataSource = dt;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //si la validacion es true se crea el estudiante
            if (validarTxt() == true)
            {

                Matricula matricula = new Matricula(0, codigoCurso, cedula, fecha1, fecha2, periodo, grupo, horarioCompleto);
               MatriculaBD.GenerarMatricula(matricula);
                //se actualiza el data grid
                mostrarMatricula();
                borrarTxt();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasamos el id del estudiante a eliminar
                int id = int.Parse(dataGrid2.SelectedCells[1].Value.ToString());
                MatriculaBD.EliminarMatricula(id);
                borrarTxt();
                //se actualiza el data grid
                mostrarMatricula();
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
                if (lbmaticula.Text.Equals(""));
                {
                    int id = int.Parse(lbmaticula.Text);
                    if (validarTxt() == true)
                    {
                        Matricula matricula = new Matricula(id, codigoCurso, cedula, fecha1, fecha2, periodo, grupo, horarioCompleto);
                        MatriculaBD.ActualizarMatricula(matricula);
                        borrarTxt();
                        //se actualiza el data grid
                        mostrarMatricula();
                    }
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("No selecciono fila");
                }
            
        }

        private void dataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbmaticula.Text = dataGrid2.SelectedCells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En la tabla no hay datos.");
            }
        }
    }
}
