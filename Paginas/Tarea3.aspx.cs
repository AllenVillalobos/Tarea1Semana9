using System;
using System.Collections.Generic;
using Tarea_1.ADO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Tarea_1.Modelos;
using System.Web.UI.WebControls;

namespace Tarea_1.Paginas
{
    public partial class Tarea_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDepartamentos();
                CargarPersonas();
            }
        }

        public void CargarDepartamentos()
        {
            DepartamentoADO departamentoADO = new DepartamentoADO();
            List<Departamento> departamentos = departamentoADO.ListarDepartamento();
            ddlDepartamentos.DataSource = departamentos;
            ddlDepartamentos.DataTextField = "Nombre";
            ddlDepartamentos.DataValueField = "idDepartamento";
            ddlDepartamentos.DataBind();
            ddlDepartamentos.Items.Insert(0, new ListItem("Selecciona un Departamento", "0"));
        }

        public void CargarPersonas()
        {
            PersonaADO personaADO = new PersonaADO();
            List<Persona> personas = personaADO.ListarPersonas();
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }
        public void ddlDepartamentos_SelectedIndexChanged(object sender,EventArgs e)
        {
            int departamento =Convert.ToInt32(ddlDepartamentos.SelectedValue);
            PersonaADO personaADO = new PersonaADO();
            List<Persona> personas = personaADO.ListarPersonasPorDepartamento(departamento);
            gvPersonas.DataSource = null;
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }
    }
}