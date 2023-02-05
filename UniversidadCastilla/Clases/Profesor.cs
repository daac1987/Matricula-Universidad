using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Profesor
    {
        private int idProfesor;
        private string nombre;
        private DateTime fechaIngreso;
        private string tipoProfesor;
        private int idDirector;
        private string codigoCarrera;

        public Profesor(int idProfesor, string nombre, DateTime fechaIngreso,
            string tipoProfesor, int idDirector, string codigoCarrera)
        {
            this.idProfesor = idProfesor;
            this.nombre = nombre;
            this.fechaIngreso = fechaIngreso;
            this.tipoProfesor = tipoProfesor;
            this.idDirector = idDirector;
            this.codigoCarrera = codigoCarrera;
        }

        public int IdProfesor { get => idProfesor; set => idProfesor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string TipoProfesor { get => tipoProfesor; set => tipoProfesor = value; }
        public int IdDirector { get => idDirector; set => idDirector = value; }
        public string CodigoCarrera { get => codigoCarrera; set => codigoCarrera = value; }
    }
}
