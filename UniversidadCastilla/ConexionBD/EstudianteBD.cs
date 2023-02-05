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
    internal class EstudianteBD
    {
        public static Boolean buscarEstudiante(int buscarId)
        {
            Boolean result = false;
            try
            {
                //codigo para consultar el id
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("ingresoEstudiante", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEstudiante", buscarId);
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
                    MessageBox.Show("Dato ingresado incorrectamente");
                    Conexiones.cerrar();
                    return result = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Dato ingresado incorrectamente" + e.Message);
                Conexiones.cerrar();
                return result = false;
            }
        }

        public static void InsertarEstudiante(Estudiante parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("crearEstudiante", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEstudiante", parametros.IdEstudiante);
                cmd.Parameters.AddWithValue("NombreEstudiante", parametros.Nombre);
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
        public static void EliminarEstudiante(int idEstudiante)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarEstudiante", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEstudiante", idEstudiante);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante eliminado correctamente");
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

        public static void ActualizarEstudiante(Estudiante parametro)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarEstudiante", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idestudiante", parametro.IdEstudiante);
                cmd.Parameters.AddWithValue("NombreEstudiante", parametro.Nombre);
                cmd.Parameters.AddWithValue("fechaIngreso", parametro.FechaIngreso);
                cmd.Parameters.AddWithValue("codigoCarrera", parametro.CodigoCarrera);
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
        public void mostrarEsutdiantes(ref DataTable dt)
        {
            try
            {
                Conexiones.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarEstudiante", Conexiones.conectar);
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

        public void mostrarEsutdiantesPorId(ref DataTable dt, int id)
        {
            try
            {
                //consultamos los cursos a los que esta asociado el estudiante
                Conexiones.abrir();
                string cadena = "SELECT c.NombreCurso,p.NombreProfesor,m.horario,m.numeroGrupo,m.periodo FROM matricula m " +
                    "INNER JOIN curso c ON c.codigoCurso = m.codigoCurso " +
                    "INNER JOIN profesor p ON p.idProfesor = c.idProfesor " +
                    "where idEstudiante = " + id;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
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
