using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class MPUsuarios : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Usuarios u = (Usuarios)Session["user"];
            if (u == null)
                Response.Redirect("Error.aspx");
            

            lblUsu.Text = u.UsuarioLogueo;
            lblNombre.Text = u.NombreCompleto;
           

        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("Default.aspx");
    }
}
