using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Matricula
    {
        private int numeroMatricula;
        private string codigoCurso;
        private int idEstudiante;
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private string periodo;
        private int numeroGrupo;
        private string horario;

        public Matricula(int numeroMatricula, string codigoCurso, int idEstudiante,
            DateTime fechaInicio, DateTime fechaFinal, string periodo, int numeroGrupo,
            string horario)
        {
            this.numeroMatricula = numeroMatricula;
            this.codigoCurso = codigoCurso;
            this.idEstudiante = idEstudiante;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.periodo = periodo;
            this.numeroGrupo = numeroGrupo;
            this.horario = horario;
        }

        public int NumeroMatricula { get => numeroMatricula; set => numeroMatricula = value; }
        public string CodigoCurso { get => codigoCurso; set => codigoCurso = value; }
        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        public string Periodo { get => periodo; set => periodo = value; }
        public int NumeroGrupo { get => numeroGrupo; set => numeroGrupo = value; }
        public string Horario { get => horario; set => horario = value; }
    }
}
