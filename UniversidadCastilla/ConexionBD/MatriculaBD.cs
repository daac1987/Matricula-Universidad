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
    internal class MatriculaBD
    {
        public static void GenerarMatricula(Matricula parametros)
        {

            try
            {
                //usamos los motodos para veirificar los espacios
                int cantidadEstiduantesMatriculados = cantidadCurso(parametros.CodigoCurso);
                int cantidadEstudiantesPermitidos = validarCantidadDeEstudiantesEnCuros(parametros.NumeroGrupo);
                //si es mayor la cantidad de estudiantes no se permite la matricula
                //if (cantidadEstudiantesPermitidos<cantidadEstiduantesMatriculados)
                //{
                    Conexiones.abrir();
                    SqlCommand cmd = new SqlCommand("generarMatricula", Conexiones.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idEstudiante", parametros.IdEstudiante);
                    cmd.Parameters.AddWithValue("codigoCurso", parametros.CodigoCurso);
                    cmd.Parameters.AddWithValue("fechaInicio", parametros.FechaInicio);
                    cmd.Parameters.AddWithValue("fechaFinal", parametros.FechaFinal);
                    cmd.Parameters.AddWithValue("periodo", parametros.Periodo);
                    cmd.Parameters.AddWithValue("numeroGrupo", parametros.NumeroGrupo);
                    cmd.Parameters.AddWithValue("horario", parametros.Horario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Estudiante: " + parametros.IdEstudiante + " matriculado correctamente");
               // }
                //else
               // {
                 //   MessageBox.Show("No hay campo en el grupo");
               // }
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

        public static void EliminarMatricula(int codigoMatricula)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("eliminarMatricula", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoMatricula", codigoMatricula);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Matricula eliminada correctamente");
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
        public void mostrarMatriculaPorCurso(ref DataTable dt, int numeroGrupo)
        {
            try
            {
                //consultamos los cursos a los que esta asociado el profesor
                Conexiones.abrir();
                string cadena = "SELECT m.numeroGrupo,m.codigoMatricula,e.NombreEstudiante,c.NombreCurso,m.horario,p.NombreProfesor FROM matricula m " +
                    "INNER JOIN estudiante e ON m.idEstudiante = e.idEstudiante "+
                    "INNER JOIN curso c ON m.codigoCurso = c.CodigoCurso " +
                    "INNER JOIN profesor p ON c.idProfesor = p.idProfesor";
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

        public static int validarCantidadDeEstudiantesEnCuros(int numeroGrupo)
        {
            //contamos las personas matriculadas
            int matricualdos;
            
            try
            {
                //consultamos los cursos a los que esta asociado el profesor
                Conexiones.abrir();
                string cadena = "SELECT COUNT(*) matriculados FROM matricula " +
                    "WHERE numeroGrupo = " + numeroGrupo;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return matricualdos = Convert.ToInt32(rd["matriculados"]);
                }  
                else
                {
                    return matricualdos = 0;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return matricualdos = 0;
            }
            finally
            {
                Conexiones.cerrar();
                
            }
        }

        public static int cantidadCurso(string curso) 
        {
            int cantidadCampos;
            //extraemos de la tabla el dato de cantidad de estudiantes permitidos
            try
            {
                Conexiones.abrir();
                string cadena = "SELECT cantidadEstudiantes FROM curso " +
                "WHERE codigoCurso = " + curso;
                SqlCommand cmd = new SqlCommand(cadena, Conexiones.conectar);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    //cantidadCampos = Convert.ToInt32(rdr["cantidadEstudiantes"]);
                    //cantidadCampos = rdr.GetInt32(0);
                    cantidadCampos = int.Parse(rd.GetValue(0).ToString());
                    return cantidadCampos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conexiones.cerrar();
            }
            return cantidadCampos= 0;
        }

        public static void ActualizarMatricula(Matricula parametros)
        {
            try
            {
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("actualizarMatricula", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigoMatricula", parametros.NumeroMatricula);
                cmd.Parameters.AddWithValue("idEstudiante", parametros.IdEstudiante);
                cmd.Parameters.AddWithValue("codigoCurso", parametros.CodigoCurso);
                cmd.Parameters.AddWithValue("fechaInicio", parametros.FechaInicio);
                cmd.Parameters.AddWithValue("fechaFinal", parametros.FechaFinal);
                cmd.Parameters.AddWithValue("periodo", parametros.Periodo);
                cmd.Parameters.AddWithValue("numeroGrupo", parametros.NumeroGrupo);
                cmd.Parameters.AddWithValue("horario", parametros.Horario);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Matricula actualizada correctamente");
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
