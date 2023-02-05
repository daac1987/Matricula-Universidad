using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversidadCastilla.Clases;
using DocumentFormat.OpenXml.Spreadsheet;

namespace UniversidadCastilla.ConexionBD
{
    internal class ProfesorCRUDBD
    {
        public static void InsertarProfesor(Profesor parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("crearProfesor", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfesor", parametros.IdProfesor);
                cmd.Parameters.AddWithValue("NombreProfesor", parametros.Nombre);
                cmd.Parameters.AddWithValue("fechaIngreso", parametros.FechaIngreso);
                cmd.Parameters.AddWithValue("tipoProfesor", parametros.TipoProfesor);
                cmd.Parameters.AddWithValue("idDirector", parametros.IdDirector);
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profesor: " + parametros.Nombre + " creado correctamente");
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
        public static void EliminarProfesor(int id)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarProfesor", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfesor", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profesor eliminado correctamente");
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

        public static void ActualizarEstudiante(Profesor parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarProfesor", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfesor", parametros.IdProfesor);
                cmd.Parameters.AddWithValue("NombreProfesor", parametros.Nombre);
                cmd.Parameters.AddWithValue("fechaIngreso", parametros.FechaIngreso);
                cmd.Parameters.AddWithValue("tipoProfesor", parametros.TipoProfesor);
                cmd.Parameters.AddWithValue("idDirector", parametros.IdDirector);
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profesor actualizado correctamente");
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
        public void mostrarProfesor(ref DataTable dt)
        {
            try
            {
                Conexiones.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarProfesor", Conexiones.conectar);
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
