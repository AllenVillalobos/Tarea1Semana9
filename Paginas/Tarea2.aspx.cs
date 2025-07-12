using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Tarea_1.Modelos;
using System.Web.UI.WebControls;

namespace Tarea_1.Paginas
{
    public partial class Tarea2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNombres();
            }
        }

        public void CargarNombres()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona { Nombre = "Juan", Apellido = "Pérez" });
            personas.Add(new Persona { Nombre = "Ana", Apellido = "Gómez" });
            personas.Add(new Persona { Nombre = "Luis", Apellido = "Martínez" });
            personas.Add(new Persona { Nombre = "María", Apellido = "López" });
            ddlNombres.DataSource = personas;  
            ddlNombres.DataTextField = "Nombre"; 
            ddlNombres.DataValueField = "Apellido";
            ddlNombres.DataBind();
            ddlNombres.Items.Insert(0,new ListItem ("Selecciona un Nombre","0"));
        }
        protected void ddlNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvNombres.DataSource = null; 
            string nombreSeleccionado = ddlNombres.SelectedItem.Text;
            string apellidoSeleccionado = ddlNombres.SelectedValue;
            List<Persona> personasSeleccionadas = new List<Persona>();
            personasSeleccionadas.Add(new Persona { Nombre = nombreSeleccionado, Apellido = apellidoSeleccionado });
            gvNombres.DataSource = personasSeleccionadas;
            gvNombres.DataBind();
        }
    }
}