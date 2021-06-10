<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="frmABMempresas.aspx.cs" Inherits="frmABMempresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 201px;
        }
        .style5
        {
            width: 180px;
        }
        .style6
        {
            width: 855px;
            height: 23px;
        }
        .style7
        {
            width: 180px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table style="width: 43%; height: 186px;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Overline="False" 
                    Font-Underline="True" Text="ABM Empresas"></asp:Label>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Text="RUT"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRUT" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Height="25px" 
                    style="margin-left: 0px" Text="Buscar" Width="96px" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Correo Electronico"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCorreoElectronico" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style5">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Height="25px" Text="Limpiar" 
                    Width="96px" onclick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style4">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAgregar" runat="server" Height="25px" Text="Agregar" 
                    Width="96px" onclick="btnAgregar_Click" Enabled="False" />
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnModificar" runat="server" Height="25px" Text="Modificar" 
                    Width="96px" onclick="btnModificar_Click" Enabled="False" />
            </td>
            <td class="style5">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Height="25px" Text="Eliminar" 
                    Width="96px" onclick="btnEliminar_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                </td>
            <td class="style3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

