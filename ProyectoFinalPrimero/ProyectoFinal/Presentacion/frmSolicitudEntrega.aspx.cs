using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class frmSolicitudEntrega : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         try
        {
        List<Paquetes> list = LogicaPaquetes.Listar();
        if (list.Count == 0)
            throw new Exception("No hay Paquetes");
        Session["Paquetes"] = list;
        gvPaquetes.DataSource = list;
        gvPaquetes.DataBind();
        }
         catch (Exception ex)
         { lblError.Text = ex.Message; }
    }
    private void HabilitoSeleccionar(bool habilitar)
    {
        txtDireccion.Enabled = habilitar;
        txtNombreDes.Enabled = habilitar;
        clnCalendario.Enabled = habilitar;
        btnAgregar.Enabled = habilitar;
    }
    protected void btnSelec_Click(object sender, EventArgs e)
    {
        try
        {
            int indice = gvPaquetes.SelectedIndex;
            List<Paquetes> Lista =  (List<Paquetes>)Session["Paquetes"];
            if(indice < 0)
                throw new Exception("No hay paquete seleccionado.");

          int pRUT = Convert.ToInt32(gvPaquetes.Rows[indice].Cells[1].Text);
            int NumeroP = Convert.ToInt32(gvPaquetes.Rows[indice].Cells[2].Text);

         /*   Paquetes paq = LogicaPaquetes.buscar(pRUT, NumeroP);*/

            Paquetes paq = Lista[gvPaquetes.SelectedIndex];

            txtRUT.Text = pRUT.ToString();
            txtPaqueteN.Text = NumeroP.ToString();
            txtPeso.Text = paq.Peso.ToString();
            txtDescripcion.Text = paq.Descripcion;

            HabilitoSeleccionar(true);
            
        }
        catch (Exception ex)
        {lblError.Text = ex.Message;}
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        
        try
        {
            int pRUT = Convert.ToInt32(txtRUT.Text);     
            int NumeroP = Convert.ToInt32(txtPaqueteN.Text);
            double pPeso =Convert.ToDouble(txtPeso.Text);
            string pDesc = txtDescripcion.Text;
            string pDire = txtDireccion.Text;
            string pNomDes = txtNombreDes.Text;
            Usuarios usu = (Usuarios)Session["user"];
            List<Paquetes> Lista = (List<Paquetes>)Session["Paquetes"];
            Paquetes paq = Lista[gvPaquetes.SelectedIndex];
            
            if (clnCalendario.SelectedDate.CompareTo(DateTime.MinValue) == 0)
                //El if de arriba hace lo mismo que el de abajo
                //if (clnFechaPrestado.SelectedDate == DateTime.MinValue)
                throw new Exception("Debe seleccionar la fecha de la solicitud.");

            DateTime pFechaSol = clnCalendario.SelectedDate;

            SolicitudesEntrega SolE = new SolicitudesEntrega(0, pFechaSol, pNomDes, pDire, "endeposito", usu, paq);

            LogicaSolicitudes.AgregarSolicitud(SolE);

            HabilitoSeleccionar(false);
            btnLimpiar_Click(sender, e);
            Page_Load(sender, e);
            lblError.Text = "Se creo correctamente la solicitud";
            
        }
        catch (Exception ex)
        {lblError.Text = ex.Message;}
    }

    protected void gvPaquetes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtDescripcion.Text = "";
        txtDireccion.Text = "";
        txtNombreDes.Text = "";
        txtPaqueteN.Text = "";
        txtPeso.Text = "";
        txtRUT.Text = "";

        HabilitoSeleccionar(false);
        
    }
}

