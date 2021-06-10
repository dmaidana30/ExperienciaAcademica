using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;


public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string user = txtUsuario.Text;
            string clave = txtClave.Text;
            Usuarios u = LogicaUsuarios.Logueo(user, clave);
           
            Session["user"] = u;

            if (u is Usuarios)
                Response.Redirect("frmBienvenida.aspx");            
            else
                lblError.Text = "El usuario o la contraseña no son válidos.";

        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
}