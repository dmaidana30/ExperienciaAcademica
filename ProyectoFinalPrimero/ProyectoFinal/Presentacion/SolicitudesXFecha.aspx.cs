using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class SolicitudesXFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            lblPaquetes.Text = "";
            gvSolicitudesXFecha.DataSource = null;
            gvSolicitudesXFecha.DataBind();
            if (clnSolicitudesFecha.SelectedDate.CompareTo(DateTime.MinValue) == 0)               
                throw new Exception("Debe seleccionar la fecha de la solicitud.");

            DateTime fechaSol = clnSolicitudesFecha.SelectedDate;

            List<SolicitudesEntrega> pListaSol = LogicaSolicitudes.ListarXFecha(fechaSol);

            if (pListaSol.Count == 0)
                throw new Exception("No hay solicitudes para la fecha");

            Session["ListaSol"] = pListaSol;

            gvSolicitudesXFecha.DataSource = pListaSol;
            gvSolicitudesXFecha.DataBind();
        }
        catch (Exception ex)
        {  lblError.Text = ex.Message; }
        

    }
    protected void gvSolicitudesXFecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SolicitudesEntrega> pListaSol = (List<SolicitudesEntrega>)Session["ListaSol"];

        SolicitudesEntrega pSol = pListaSol[gvSolicitudesXFecha.SelectedIndex];

       Paquetes paq = LogicaPaquetes.buscar(pSol.MiPaquete.RutEmpresa, pSol.MiPaquete.NumeroP);

       lblPaquetes.Text = paq.ToString();
    }
    protected void clnSolicitudesFecha_SelectionChanged(object sender, EventArgs e)
    {

    }
}