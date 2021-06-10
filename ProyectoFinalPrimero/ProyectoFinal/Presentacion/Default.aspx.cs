using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            List<SolicitudesEntrega> listaSolE = LogicaSolicitudes.ListarDepCam();
            if (listaSolE == null)
                throw new Exception("La lista esa vacia.");
            gvDefaut.DataSource = listaSolE;
            gvDefaut.DataBind();


        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}