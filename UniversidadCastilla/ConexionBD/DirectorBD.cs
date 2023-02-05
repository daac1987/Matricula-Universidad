using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversidadCastilla.Clases;

namespace UniversidadCastilla.ConexionBD
{
    internal class DirectorBD
    {
        //validamos que el id sea correcto 
        public static Boolean buscarDirector (int buscarId)
        {
            Boolean result = false;
			try
			{
                //codigo para consultar el id
				Conexiones.abrir();
				SqlCommand cmd = new SqlCommand("ingresoDirector", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDirector", buscarId);
                SqlDataReader lector = cmd.ExecuteReader();
                //la base de datos devuelve un lectura, si es correcta la podemos leer
                //falsa no se lee 
                if (lector.Read())
                {
                    MessageBox.Show("Dato ingresado correctamente");
                    Conexiones.cerrar();
                    //devuelve un verdadero si se el id fue correcto
                    return result = true;
                }
                else 
                {
                    MessageBox.Show("Dato ingresado incorrectamente" );
                    Conexiones.cerrar();
                    return result = false;
                }
                
            }
			catch (Exception e)
			{
                MessageBox.Show("Dato ingresado incorrectamente"+e.Message);
                Conexiones.cerrar();
                return result = false;
            }
        }

        public static void InsertarDirector(Director parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("crearDirector", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDirector", parametros.IdDirector);
                cmd.Parameters.AddWithValue("NombreDirector", parametros.Nombre);
                cmd.Parameters.AddWithValue("fechaIngreso", parametros.FechaIngreso);
                cmd.Parameters.AddWithValue("codigoCarrera", parametros.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante: " + parametros.Nombre + " creado correctamente");
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

        public static void EliminarDirector(int idDirector)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarDirector", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDirector", idDirector);
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

        public static void ActualizarDirector(Director parametro)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarDirector", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDirector", parametro.IdDirector);
                cmd.Parameters.AddWithValue("NombreDirector", parametro.Nombre);
                cmd.Parameters.AddWithValue("fechaIngreso", parametro.FechaIngreso);
                cmd.Parameters.AddWithValue("codigoCarrera", parametro.CodigoCarrera);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Director actualizado correctamente");
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

        public void mostrarDirector(ref DataTable dt)
        {
            try
            {
                Conexiones.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarDirector", Conexiones.conectar);
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
