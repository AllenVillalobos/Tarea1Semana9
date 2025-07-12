using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea_1.Modelos
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int idDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
    }
}