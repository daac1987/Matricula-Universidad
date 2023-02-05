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
    public partial class ingreso : Form
    {
        public ingreso()
        {
            InitializeComponent();
        }
        public static int idIngreso;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarTxt()==true)
            {
                switch (cbTipoUsuario.SelectedIndex)
                {
                    case -1:
                        MessageBox.Show("No ingreso eleccion de tipo de usuario.");
                        break;
                    case 0:
                        if (DirectorBD.buscarDirector(idIngreso) == true)
                        {
                            txtCedula.Text = string.Empty;
                            formDirector frd = new formDirector();
                            frd.Show();
                            this.Hide();
                        }
                        else
                        {
                            txtCedula.Text = string.Empty;
                            txtCedula.Focus();
                        }
                        break;
                    case 1:
                        if (ProfesorBD.buscarProfesor(idIngreso) == true)
                        {
                            txtCedula.Text = string.Empty;
                            FormProfesor frp = new FormProfesor();
                            frp.lbCedula.Text = idIngreso.ToString();
                            frp.Show();
                            this.Hide();
                        }
                        else
                        {
                            txtCedula.Text = string.Empty;
                            txtCedula.Focus();
                        }
                        break;
                     case 2:
                        if (EstudianteBD.buscarEstudiante(idIngreso) == true)
                        {
                            txtCedula.Text = string.Empty;
                            FormEstudiante fre= new FormEstudiante();
                            fre.lbCedula.Text = idIngreso.ToString();
                            fre.Show();
                            this.Hide();
                        }
                        else
                        {
                            txtCedula.Text = string.Empty;
                            txtCedula.Focus();
                        }
                        break;

                     case 3:
                        if (AdministradorDB.buscarAdministrador(idIngreso) == true)
                        {
                            FormAdministrador fra = new FormAdministrador();
                            fra.Show();
                            this.Hide();
                        }
                        else
                        {
                            txtCedula.Text = string.Empty;
                            txtCedula.Focus();
                        }
                        break;

                }
            }
        }

        public Boolean validarTxt ()
        {
            bool valid = false;
            //validacion que el campo este lleno
            string val = txtCedula.Text;
            if (!val.Equals(""))
            {
                try
                {
                    //asignamos id y verificamos que sea un int
                    idIngreso = int.Parse(txtCedula.Text);
                    return valid = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Dato ingresado en cedula no es un numero= " + e.Message);
                    txtCedula.Focus();
                    txtCedula.Text = string.Empty;
                    return valid = false; 
                }

            }
            MessageBox.Show("No ingreso la Cedula.");
            txtCedula.Focus();
            return valid;
        }
    }
}
