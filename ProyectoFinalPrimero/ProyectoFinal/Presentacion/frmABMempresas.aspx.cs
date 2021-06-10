using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class frmABMempresas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void HabilitoBuscar(bool habilitar)
    {
        txtRUT.Enabled = habilitar;
        btnAgregar.Enabled = habilitar;
        txtNombre.Enabled = !habilitar;
        txtCorreoElectronico.Enabled = !habilitar;
        txtTelefono.Enabled = !habilitar;
                

    }
    private void LimpioFormulario()
    {
        txtRUT.Text = "";       
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtCorreoElectronico.Text = "";
        lblError.Text = "";
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
            int pRUT = 0;
            if (!int.TryParse(txtRUT.Text, out pRUT))
                throw new Exception("El RUT no tiene formato correcto.");

            Empresas emp = LogicaEmpresas.Buscar(pRUT);            


            //LimpioFormulario();
            if (emp == null)
            {
                lblError.Text = "No existe una empresa con el RUT: " + pRUT;
                HabilitoBuscar(false);
                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

            else if (emp is Empresas)
            {
                txtRUT.Text = pRUT.ToString();
                txtNombre.Text = emp.Nombre;
                txtTelefono.Text = emp.Telefono;
                txtCorreoElectronico.Text = emp.CorreoElectronico;
                Session["Empresa"] = emp;
                

                HabilitoBuscar(false);
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                lblError.Text = "Tipo de empresa desconocida.";
            }
            
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    
    }



    protected void btnAgregar_Click(object sender, EventArgs e)
    {
       
        try
        {

            int pRUT = 0;
            if (!int.TryParse(txtRUT.Text, out pRUT))
                throw new Exception("El RUT no tiene formato correcto.");

            string pNombre = txtNombre.Text;
            string pTelefono = txtTelefono.Text;
            string pCorreoElectronico = txtCorreoElectronico.Text;


            Empresas emp = new Empresas(pRUT, pNombre, pTelefono, pCorreoElectronico);

            LogicaEmpresas.AgregarEmpresas(emp);           
           

            
            btnLimpiar_Click(sender, e);
            lblError.Text = "Se agregó correctamente la categoria.";
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

          /*  int pRUT = 0;
            if (!int.TryParse(txtRUT.Text, out pRUT))
                throw new Exception("El RUT no tiene formato correcto.");

            string pNombre = txtNombre.Text;
            string pTelefono = txtTelefono.Text;
            string pCorreoElectronico = txtCorreoElectronico.Text;


            Empresas emp = new Empresas(pRUT, pNombre, pTelefono, pCorreoElectronico);*/

            Empresas emp = (Empresas)Session["Empresa"];

            emp.Nombre = txtNombre.Text;
            emp.Telefono = txtTelefono.Text;
            emp.CorreoElectronico = txtCorreoElectronico.Text;


            LogicaEmpresas.ModificarEmpresas(emp);


            btnLimpiar_Click(sender, e);
            
            lblError.Text = "Se Modifico correctamente la empresa.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
   
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Empresas emp = (Empresas)Session["Empresa"];
            LogicaEmpresas.EliminarEmpresa(emp);

            btnLimpiar_Click(sender, e);
            lblError.Text = "Se eliminó correctamente la empresa.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
}