using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Carrera
    {
        private string codigoCarrera;
        private string nombre;
        private int versionDelPlan;
        private string sede;
        private string facultad;

        public Carrera(string codigoCarrera, string nombre, int versionDelPlan,
            string sede, string facultad)
        {
            this.codigoCarrera = codigoCarrera;
            this.nombre = nombre;
            this.versionDelPlan = versionDelPlan;
            this.sede = sede;
            this.facultad = facultad;
        }

        public string CodigoCarrera { get => codigoCarrera; set => codigoCarrera = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int VersionDelPlan { get => versionDelPlan; set => versionDelPlan = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Facultad { get => facultad; set => facultad = value; }
    }
}
