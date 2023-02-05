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
    internal class ProfesorBD
    {
        public static Boolean buscarProfesor(int buscarId)
        {
            Boolean result = false;
            try
            {
                //codigo para consultar el id
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("ingresoProfesor", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfesor", buscarId);
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

        public void mostrarCursoProfesor(ref DataTable dt,int idProfesor)
        {
            try
            {
                //consultamos los cursos a los que esta asociado el profesor
                Conexiones.abrir();
                string cadena = "SELECT DISTINCT m.numeroGrupo,c.NombreCurso,m.Horario FROM curso c " +
                    "INNER JOIN matricula m ON m.codigoCurso = c.codigoCurso " +
                    " where c.idProfesor =" + idProfesor;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd= cmd.ExecuteReader();
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

        public void mostrarGrupo (ref DataTable dt,int Grupo)
        {
            try
            {
                //consultamos los cursos a los que esta asociado el profesor
                Conexiones.abrir();
                string cadena = "SELECT m.idEstudiante,e.NombreEstudiante,c.NombreCurso,m.horario,m.codigoMatricula FROM matricula m " +
                    "INNER JOIN curso c ON m.codigoCurso = c.codigoCurso " +
                    "INNER JOIN estudiante e ON e.idEstudiante = m.idEstudiante " +
                    " where m.numeroGrupo = " + Grupo;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void ingresarAsistencia(Asistencia parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("ingresarAsistencia", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoMatricula", parametros.NumeroMatricula);
                cmd.Parameters.AddWithValue("fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("estadoAsistencia", parametros.EstadoAsistencia);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Asistencia ingresada creado correctamente");
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

        public void mostrarAsistenciaPorGrupo(ref DataTable dt, int Grupo)
        {
            try
            {
                //consultamos los cursos a los que esta asociado el profesor
                Conexiones.abrir();
                string cadena = "SELECT m.idEstudiante,e.NombreEstudiante,c.NombreCurso,a.fecha,a.estadoAsistencia FROM matricula m " +
                    "INNER JOIN curso c ON m.codigoCurso = c.codigoCurso " +
                    "INNER JOIN estudiante e ON e.idEstudiante = m.idEstudiante " +
                    "INNER JOIN asistencia a ON a.codigoMatricula = m.codigoMatricula" +
                    " where m.numeroGrupo = " + Grupo;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
