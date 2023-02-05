using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Director
    {
        private int idDirector;
        private string nombre;
        private DateTime fechaIngreso;
        private string codigoCarrera;

        public Director(int idDirector, string nombre, DateTime fechaIngreso, string codigoCarrera)
        {
            this.idDirector = idDirector;
            this.nombre = nombre;
            this.fechaIngreso = fechaIngreso;
            this.codigoCarrera = codigoCarrera;
        }

        public int IdDirector { get => idDirector; set => idDirector = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string CodigoCarrera { get => codigoCarrera; set => codigoCarrera = value; }
    }
}
