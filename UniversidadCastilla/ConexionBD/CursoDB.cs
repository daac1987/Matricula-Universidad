using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversidadCastilla.Clases;

namespace UniversidadCastilla.ConexionBD
{
    internal class CursoDB
    {
        public static void InsertarCurso(Curso parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("crearCurso", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCurso", parametros.CodigoCurso);
                cmd.Parameters.AddWithValue("NombreCurso", parametros.Nombre);
                cmd.Parameters.AddWithValue("cantidadEstudiantes", parametros.CantidadEstudiantes);
                cmd.Parameters.AddWithValue("idProfesor", parametros.IdProfesor);
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso: " + parametros.Nombre + " creado correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conexiones.cerrar();
            }
        }

        public static void EliminarCurso(string codigoCurso)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarCurso", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCurso", codigoCurso);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Director eliminado correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conexiones.cerrar();
            }
        }

        public static void ActualizarCurso(Curso parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarCurso", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCurso", parametros.CodigoCurso);
                cmd.Parameters.AddWithValue("NombreCurso", parametros.Nombre);
                cmd.Parameters.AddWithValue("cantidadEstudiantes", parametros.CantidadEstudiantes);
                cmd.Parameters.AddWithValue("idProfesor", parametros.IdProfesor);
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso actualizado correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conexiones.cerrar();
            }
        }

        public void mostrarCurso(ref DataTable dt)
        {
            try
            {
                Conexiones.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarCurso", Conexiones.conectar);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conexiones.cerrar();
            }
        }
    }
}
