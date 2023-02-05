using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadCastilla.Clases
{
    internal class Curso
    {
        private string codigoCurso;
        private string nombre;
        private int cantidadEstudiantes;
        private int idProfesor;
        private string codigoCarrera;

        public Curso(string codigoCurso, string nombre, int cantidadEstudiantes, int idProfesor, 
            string codigoCarrera)
        {
            this.codigoCurso = codigoCurso;
            this.nombre = nombre;
            this.cantidadEstudiantes = cantidadEstudiantes;
            this.idProfesor = idProfesor;
            this.codigoCarrera = codigoCarrera;
        }

        public string CodigoCurso { get => codigoCurso; set => codigoCurso = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int CantidadEstudiantes { get => cantidadEstudiantes; set => cantidadEstudiantes = value; }
        public int IdProfesor { get => idProfesor; set => idProfesor = value; }
        public string CodigoCarrera { get => codigoCarrera; set => codigoCarrera = value; }
    }

}
