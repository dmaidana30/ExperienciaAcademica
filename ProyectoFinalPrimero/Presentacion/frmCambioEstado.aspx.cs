using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class frmCambioEstado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<SolicitudesEntrega> list = LogicaSolicitudes.ListarDepCam();
            if (list.Count == 0)
                throw new Exception("No hay solicitudes ");
            gvSolDepCam.DataSource = list;
            gvSolDepCam.DataBind();

            Session["solicitudes"] = list;
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void gvSolDepCam_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {
             List<SolicitudesEntrega> list = (List<SolicitudesEntrega>)Session["solicitudes"];            
             SolicitudesEntrega pSol = list[gvSolDepCam.SelectedIndex];

             LogicaSolicitudes.CambiarEstado(pSol);

             Page_Load(sender, e);
        }
         catch (Exception ex)
         { lblError.Text = ex.Message; }
    }
}