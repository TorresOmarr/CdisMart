<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialSubasta.aspx.cs" Inherits="CdisMart.HistorialSubasta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>

                <tr>
                    <td>Nombre del producto: </td>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>Descripcion: </td>
                    <td>
                        <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>Usuario: </td>
                    <td>
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="lista" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>


            </table>



            <asp:GridView ID="grd_Subasta" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="385px">
                <Columns>
                    <asp:BoundField HeaderText="Usuario" DataField="Name" />
                    <asp:BoundField HeaderText="Monto oferta" DataField="Amount" DataFormatString="{0:C}" />
                    <asp:BoundField HeaderText="Fecha de la oferta" DataField="BidDate" />

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {

            $("#MainContent_txtFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();

        });
    </script>
</asp:Content>
