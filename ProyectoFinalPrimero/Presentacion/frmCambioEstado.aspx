<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="frmCambioEstado.aspx.cs" Inherits="frmCambioEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 270px;
        }
        .style5
        {
            width: 263px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:GridView ID="gvSolDepCam" runat="server" AutoGenerateColumns="False" 
                    Height="129px" onselectedindexchanged="gvSolDepCam_SelectedIndexChanged" 
                    Width="252px">
                    <Columns>
                        <asp:CommandField HeaderText="Seleccione la deseada:" ShowSelectButton="True" />
                        <asp:BoundField DataField="NumeroInterno" HeaderText="Numero Interno" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="NombreDes" HeaderText="Nombre Destinatario" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="EstadoActual" HeaderText="Estado Actual" />
                    </Columns>
                </asp:GridView>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

