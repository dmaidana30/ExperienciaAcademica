using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class frmABMpaquetes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                List<Empresas> resp = LogicaEmpresas.Listar();
                foreach (Empresas p in resp)
                {                    
                    ListItem item = new ListItem(p.Nombre,p.RUT.ToString());
                    cboEmpresas.Items.Add(item);
                }
            }
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }

    private void HabilitoBuscar(bool habilitar)
    {
        cboEmpresas.Enabled = habilitar;
        txtNumeroP.Enabled = habilitar;
        btnAgregar.Enabled = habilitar;

        txtPeso.Enabled = !habilitar;
        txtDescripcion.Enabled = !habilitar;
        cboTipo.Enabled = !habilitar;

    }
    private void LimpioFormulario()
    {
        txtDescripcion.Text = "";
        txtNumeroP.Text = "";
        txtPeso.Text = "";     
        lblError.Text = "";
        cboTipo.SelectedIndex = -1;
        cboEmpresas.SelectedIndex = -1;
    }
    private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        
        btnBuscar.Enabled = true;
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int pRUT = Convert.ToInt32(cboEmpresas.SelectedItem.Value);
            int pNumero = Convert.ToInt32(txtNumeroP.Text);

            Paquetes paq = LogicaPaquetes.buscar(pRUT, pNumero);

            //LimpioFormulario();
            if (paq == null)
            {
                lblError.Text = "No existe un paquete con estos datos ";
                HabilitoBuscar(false);
                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

            else if (paq is Paquetes)
            {
                
                txtDescripcion.Text = paq.Descripcion;
                txtPeso.Text = paq.Peso.ToString();
                txtNumeroP.Text = paq.NumeroP.ToString();
                

                if (paq.TipoDePaquete == "fragil")
                    cboTipo.SelectedIndex = 0;
                else if (paq.TipoDePaquete == "comun")
                    cboTipo.SelectedIndex = 1;
                else if (paq.TipoDePaquete == "bulto")
                    cboTipo.SelectedIndex = 2;

                Session["Paquete"] = paq;

                HabilitoBuscar(false);
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                lblError.Text = "Tipo de paquete desconocido.";
            }
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            int pRUT = Convert.ToInt32(cboEmpresas.SelectedItem.Value);
            int pNumero = Convert.ToInt32(txtNumeroP.Text);
            string pDescripcion = txtDescripcion.Text;
            double pPeso = Convert.ToDouble(txtPeso.Text);
            string pTipoPaquete = cboTipo.SelectedItem.Value;

            Empresas emp = LogicaEmpresas.Buscar(pRUT);

            Paquetes paq = new Paquetes(pNumero, pPeso, pTipoPaquete, pDescripcion, emp);



            LogicaPaquetes.AgregarPaquetes(paq);


            btnLimpiar_Click(sender, e);
            lblError.Text = "Se agregó correctamente el paquete.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
   
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
        DesactivoBotones();
        HabilitoBuscar(true);
    }


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
                       
            Paquetes paq = (Paquetes)Session["Paquete"];

            paq.MiEmpresa.RUT = Convert.ToInt32(cboEmpresas.SelectedItem.Value);
            paq.NumeroP = Convert.ToInt32(txtNumeroP.Text);
            paq.Peso = Convert.ToDouble(txtPeso.Text);
            paq.TipoDePaquete = cboTipo.SelectedItem.Value;
            paq.Descripcion = txtDescripcion.Text;

            LogicaPaquetes.ModificarPaquetes(paq);


            btnLimpiar_Click(sender, e);
            lblError.Text = "Se Modifico correctamente el usuario.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Paquetes paq = (Paquetes)Session["Paquete"];
            LogicaPaquetes.EliminarPaquetes(paq);

            btnLimpiar_Click(sender, e);
            lblError.Text = "Se eliminó correctamente el paquete.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
}