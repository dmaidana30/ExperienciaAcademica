using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ObligatorioEntidadesCompartidas;
using ObligatorioLogica;

public partial class frmABMusuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void HabilitoBuscar(bool habilitar)
    {
        txtUsuario.Enabled = habilitar;
        btnAgregar.Enabled = habilitar;
        txtClave.Enabled = !habilitar;
        txtNombreCompleto.Enabled = !habilitar;

    }
    private void LimpioFormulario()
    {
        txtUsuario.Text = "";
        txtClave.Text = "";
        txtNombreCompleto.Text = "";
        lblError.Text = "";
    }
    private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;
    }
  
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {

            string pUsuarioLogueo = txtUsuario.Text;
            string pClave = txtClave.Text;
            string pNombreCompleto = txtNombreCompleto.Text;

            Usuarios usu = new Usuarios(pUsuarioLogueo, pClave, pNombreCompleto);

            LogicaUsuarios.AgregarUsuarios(usu);


            btnLimpiar_Click1(sender, e);
            lblError.Text = "Se agregó correctamente el usuario.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
   
    }

    protected void btnModificar_Click1(object sender, EventArgs e)
    {
        try
        {

            Usuarios usu = (Usuarios)Session["Usuario"];
                       
            usu.UsuarioLogueo = txtUsuario.Text;
            usu.Clave = txtClave.Text;
            usu.NombreCompleto = txtNombreCompleto.Text;


            LogicaUsuarios.ModificarUsuarios(usu);

            btnLimpiar_Click1(sender, e);
            lblError.Text = "Se Modifico correctamente el usuario.";
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
        LimpioFormulario();
        DesactivoBotones();
        HabilitoBuscar(true);
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuarios usu = (Usuarios)Session["Usuario"];

            LogicaUsuarios.EliminarUsuarios(usu);

            btnLimpiar_Click1(sender, e);
            lblError.Text = "Se eliminó correctamente la empresa.";
            
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }
    }
    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        try
        {
            string pUsuarioLogueo = txtUsuario.Text;

            Usuarios usu = LogicaUsuarios.Buscar(pUsuarioLogueo);

            //LimpioFormulario();
            if (usu == null)
            {
                lblError.Text = "No existe un usuario con el nombre: " + pUsuarioLogueo;
                HabilitoBuscar(false);
                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

            else if (usu is Usuarios)
            {
                txtUsuario.Text = pUsuarioLogueo;
                txtClave.Text = usu.Clave;
                txtNombreCompleto.Text = usu.NombreCompleto;
                Session["Usuario"] = usu;

                HabilitoBuscar(false);
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                lblError.Text = "Tipo de usuario desconocido.";
            }
        }
        catch (Exception ex)
        { lblError.Text = ex.Message; }

    }
}