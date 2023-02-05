using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Estudiante
    {
        private int idEstudiante;
        private string nombre;
        private DateTime fechaIngreso;
        private string codigoCarrera;

        public Estudiante(int idEstudiante, string nombre, DateTime fechaIngreso, string codigoCarrera)
        {
            this.idEstudiante = idEstudiante;
            this.nombre = nombre;
            this.fechaIngreso = fechaIngreso;
            this.codigoCarrera = codigoCarrera;
        }

        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string CodigoCarrera { get => codigoCarrera; set => codigoCarrera = value; }
    }
}
