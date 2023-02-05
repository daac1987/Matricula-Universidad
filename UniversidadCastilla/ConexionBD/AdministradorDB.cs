using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.ConexionBD
{
    internal class AdministradorDB
    {
        public static Boolean buscarAdministrador(int buscarId)
        {
            Boolean result = false;
            try
            {
                //codigo para consultar el id
                Conexiones.abrir();
                SqlCommand cmd = new SqlCommand("ingresoAdministrador", Conexiones.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idAdministrador", buscarId);
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
    }
}
