<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaSubastas.aspx.cs" Inherits="CdisMart.ListaSubastas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblBuscador" runat="server" Text="Buscador"></asp:Label>
    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Height="30px" Text="Buscar" OnClick="btnBuscar_Click" />
    <asp:GridView ID="grd_Subastas" AutoGenerateColumns="False" runat="server" OnRowCommand="grd_Subastas_RowCommand" Height="171px" Width="920px" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Nombre del Producto" >
                <ItemTemplate>
                    <asp:LinkButton ID="btnProducto" runat="server" Text='<%# Eval("ProductName") %>'
                        CommandName="Subasta" CommandArgument='<%# Eval("ProductName") %>' ></asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>                          
            <asp:BoundField HeaderText ="# de la subasta" DataField = "AuctionId"  />
            <asp:BoundField HeaderText ="Descripcion del producto" DataField = "Description" />
            <asp:BoundField HeaderText ="Fecha de inicio de la subasta" DataField = "StartDate" />
            <asp:BoundField HeaderText ="Fecha de fin de la subasta" DataField = "EndDate" />            
            <asp:TemplateField HeaderText="Historial">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHistorial" runat="server" Text="Historial"
                        CommandName="Historial" CommandArgument='<%# Eval("ProductName") %>' ></asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>  
           
        </Columns>


        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />


    </asp:GridView> 
           

</asp:Content>
