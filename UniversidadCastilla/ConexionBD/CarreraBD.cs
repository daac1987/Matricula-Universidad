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
    internal class CarreraBD
    {
        public static void InsertarCarrera(Carrera parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("crearCarrera", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.Parameters.AddWithValue("NombreCarrera", parametros.Nombre);
                cmd.Parameters.AddWithValue("versionPlan", parametros.VersionDelPlan);
                cmd.Parameters.AddWithValue("sede", parametros.Sede);
                cmd.Parameters.AddWithValue("facultad", parametros.Facultad);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Carrera: " + parametros.Nombre + " creado correctamente");
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
        public static void EliminarCarrera(string codigo)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarCarrera", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCarrera", codigo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Carrera eliminado correctamente");
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

        public static void ActualizarCarrera(Carrera parametro)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarCarrera", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoCarrera", parametro.CodigoCarrera);
                cmd.Parameters.AddWithValue("NombreCarrera", parametro.Nombre);
                cmd.Parameters.AddWithValue("versionPlan", parametro.VersionDelPlan);
                cmd.Parameters.AddWithValue("sede", parametro.Sede);
                cmd.Parameters.AddWithValue("facultad", parametro.Facultad);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante actualizado correctamente");
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
        public void mostrarCarrera(ref DataTable dt)
        {
            try
            {
                Conexiones.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarCarrera", Conexiones.conectar);
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
