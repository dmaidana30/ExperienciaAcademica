<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="frmABMusuarios.aspx.cs" Inherits="frmABMusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table style="width: 46%; height: 277px; margin-bottom: 0px;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" 
                    Text="ABM Usuarios"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Usuario:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" 
                    onclick="btnBuscar_Click1" />
            </td>
        </tr>
        <tr>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Nombre completo:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtNombreCompleto" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" 
                    onclick="btnLimpiar_Click1" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="100px" 
                    onclick="btnAgregar_Click" Enabled="False" />
            </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="100px" 
                    onclick="btnModificar_Click1" Enabled="False" />
            </td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="100px" 
                    onclick="btnEliminar_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

