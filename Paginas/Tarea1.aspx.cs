using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Tarea_1.Modelos;
using System.Web.UI.WebControls;

namespace Tarea_1.Paginas
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarNombres();
        }
        public void CargarNombres()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona { Nombre = "Juan", Apellido = "Pérez" });
            personas.Add(new Persona { Nombre = "Ana", Apellido = "Gómez" });
            personas.Add(new Persona { Nombre = "Luis", Apellido = "Martínez" });
            personas.Add(new Persona { Nombre = "María", Apellido = "López" });
            gvNombres.DataSource = personas;
            gvNombres.DataBind();

        }
    }
}