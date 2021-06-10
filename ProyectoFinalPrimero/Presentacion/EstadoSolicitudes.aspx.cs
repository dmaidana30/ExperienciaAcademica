using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class EstadoSolicitudes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                List<Empresas> resp = LogicaEmpresas.Listar();
                if (resp.Count == 0)                    
                    throw new Exception("La lista de empresas esta vacia");
                Session["lista"] = resp;
                foreach (Empresas p in resp)
                {
                    ListItem item = new ListItem(p.Nombre, p.RUT.ToString());
                    cboEmpresas.Items.Add(item);
                }
            }
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void cboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
                lblError.Text = "";
                lblSolicitudes.Text = "";
                List<Empresas> lista = (List<Empresas>)Session["lista"];
                if (lista == null)
                    throw new Exception("La lista de empresas esta vacia");
                
                Empresas emp = lista[cboEmpresas.SelectedIndex];

                msgEmp.Text =emp.ToString();

                List<Paquetes> listP = LogicaPaquetes.ListarXEmp(emp.RUT);
                Session["listaPaq"] = listP;

                if (listP == null)
                {
                    throw new Exception("No hay paquetes para mostrar");
                }
                gvPaquetes.DataSource = listP;
                gvPaquetes.DataBind();
            



            
            
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void gvPaquetes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            lblSolicitudes.Text = "";
            List<Paquetes> listaPaq = ( List<Paquetes>)Session["listaPaq"];
            Paquetes paq = listaPaq[gvPaquetes.SelectedIndex];

            SolicitudesEntrega solE = LogicaSolicitudes.buscar(paq);
            if (solE == null)
                throw new Exception("No hay solicitudes con ese paquete");
            lblSolicitudes.Text = solE.ToString();

        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
}