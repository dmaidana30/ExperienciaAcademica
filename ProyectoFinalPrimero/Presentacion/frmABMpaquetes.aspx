<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="frmABMpaquetes.aspx.cs" Inherits="frmABMpaquetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 143px;
        }
        .style7
        {
            height: 23px;
            width: 143px;
        }
        .style8
        {
            width: 144px;
        }
        .style9
        {
            height: 23px;
            width: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table style="width: 49%; height: 204px;">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" 
                    Text="ABM Paquetes"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Text="RUT"></asp:Label>
            </td>
            <td class="style8">
                <asp:DropDownList ID="cboEmpresas" runat="server" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label4" runat="server" Text="Numero ID:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtNumeroP" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label5" runat="server" Text="Peso:"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtPeso" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label7" runat="server" Text="Tipo De Paquete:"></asp:Label>
            </td>
            <td class="style8">
                <asp:DropDownList ID="cboTipo" runat="server" Enabled="False">
                    <asp:ListItem>fragil</asp:ListItem>
                    <asp:ListItem>comun</asp:ListItem>
                    <asp:ListItem>bulto</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                    onclick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label6" runat="server" Text="Descripcion"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Button ID="btnAgregar" runat="server" Enabled="False" Text="Agregar" 
                    onclick="btnAgregar_Click" />
            </td>
            <td class="style8">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click" />
            </td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    onclick="btnEliminar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

