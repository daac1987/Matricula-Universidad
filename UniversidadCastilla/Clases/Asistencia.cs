using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Asistencia
    {
        private int numeroMatricula;
        private DateTime fecha;
        private string estadoAsistencia;

        public Asistencia(int numeroMatricula, DateTime fecha, string estadoAsistencia)
        {
            this.numeroMatricula = numeroMatricula;
            this.fecha = fecha;
            this.estadoAsistencia = estadoAsistencia;
        }

        public int NumeroMatricula { get => numeroMatricula; set => numeroMatricula = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string EstadoAsistencia { get => estadoAsistencia; set => estadoAsistencia = value; }
    }
}
