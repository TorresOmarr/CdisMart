<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta.aspx.cs" Inherits="CdisMart.Subasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

    <table>
       <tr>
        
            <td># de la subasta</td>
            <td>
                <asp:Label ID="lblIdSubasta" runat="server" Text=""></asp:Label>
            </td>
        
        </tr>
        <tr>
            <td>Nombre del producto</td>
            <td>
                
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </td>
        
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>                
                <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
            </td>
        
        </tr>
        <tr>
            <td>Fecha de inicio de la subasta</td>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text=""></asp:Label>
            </td>
        
        </tr>
        <tr>
            <td>Fecha de fin de la subasta</td>
            <td>
                <asp:Label ID="lblFechaFin" runat="server" Enabled="false"  ></asp:Label>
            </td>
        
        </tr>
        <tr>
            <td>Oferta actual mas alta</td>
            <td>                
                <asp:Textbox ID="txtOfertaActual" runat="server" Text="" DataFormatString={0:C} Enabled="false" ></asp:Textbox>
            </td>
        
        </tr>
        <tr>
            <td>Usuario que realizo la oferta actual mas alta</td>
            <td>
                <asp:Label ID="lblUsuarioOfertaAlta" runat="server" Text=""></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>Realizar Oferta</td>
            <td>
                <asp:TextBox ID="txtOferta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnOferta" runat="server" Text="Hacer Oferta" OnClick="btnOferta_Click" />
            </td>
           </tr>        
                
        
    </table>


   
    
</asp:Content>
