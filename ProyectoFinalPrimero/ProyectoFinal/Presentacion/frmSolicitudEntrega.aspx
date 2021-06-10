<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="frmSolicitudEntrega.aspx.cs" Inherits="frmSolicitudEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 296px;
        }
        .style6
        {
            width: 109px;
        }
        .style7
        {
            height: 23px;
            width: 109px;
        }
        .style8
        {
            width: 553px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                <asp:GridView ID="gvPaquetes" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="gvPaquetes_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField HeaderText="Seleccione:" ShowSelectButton="True" />
                        <asp:BoundField DataField="RutEmpresa" HeaderText="RUT" />
                        <asp:BoundField DataField="NumeroP" HeaderText="N Paquete" />
                        <asp:BoundField DataField="Peso" HeaderText="Peso" />
                        <asp:BoundField DataField="TipoDePaquete" HeaderText="Tipo Paquete" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    </Columns>
                    <SelectedRowStyle BackColor="#00CCFF" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSelec" runat="server" onclick="btnSelec_Click" 
                    Text="Seleccionar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label2" runat="server" Text="RUT:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtRUT" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Text="Nº Paquete:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtPaqueteN" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label4" runat="server" Text="Peso:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtPeso" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label5" runat="server" Text="Descripcion:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style8">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style8">
                <asp:Calendar ID="clnCalendario" runat="server" Enabled="False"></asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label7" runat="server" Text="Nombre destinatario:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtNombreDes" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label8" runat="server" Text="Direccion:"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtDireccion" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                <asp:Button ID="btnAgregar" runat="server" Text="Crear" Enabled="False" 
                    onclick="btnAgregar_Click" />
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                    onclick="btnLimpiar_Click" />
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
</asp:Content>

