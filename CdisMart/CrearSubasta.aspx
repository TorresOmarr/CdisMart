<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearSubasta.aspx.cs" Inherits="CdisMart.CrearSubasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        
        <tr>
            <td>Nombre del producto:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Nombre" ControlToValidate="txtNombre"  ValidationGroup="vlg1" runat="server" ErrorMessage="El nombre del producto es requerido" Display="Dynamic" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_Nombre" runat="server" ErrorMessage="debe ser un valor alfanumerico de max 50 caracteres" 
                   ValidationGroup="vlg1" ValidationExpression="^[A-Za-z0ÑñÁáÉéÍíÓóÚúÜü0-9 ]{1,50}$" ControlToValidate="txtNombre" Display="Dynamic" ></asp:RegularExpressionValidator>
            </td>            
        </tr>

        <tr>
            <td>Descripcion del producto:</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Descripcion" ControlToValidate="txtDescripcion" ValidationGroup="vlg1" runat="server" ErrorMessage="La descripcion del producto es requerida" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_Descripcion" ControlToValidate="txtDescripcion" runat="server"
                    ErrorMessage="debe ser un valor alfanumerico de max 100 caracteres" ValidationExpression="^[A-Za-zÑñÁáÉéÍíÓóÚúÜü0-9 ]{1,100}" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>Fecha de inicio:</td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_FechaInicio" Operator="DataTypeCheck" ControlToValidate="txtFechaInicio" ValidationGroup="vlg1" runat="server" ErrorMessage="La fecha de inicio es requerida"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Fecha de fin:</td>
            <td>
                <asp:TextBox ID="txtFechaFin" runat="server" ValidationGroup="vlg1" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_FechaFin" Operator="DataTypeCheck" ControlToValidate="txtFechaFin" ValidationGroup="vlg1" runat="server" ErrorMessage="La fecha de fianl es requerida"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubastar" ValidationGroup="vlg1" runat="server" Text="Subastar" OnClick="btnSubastar_Click"   />
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        
        


    </table>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#MainContent_txtFechaInicio").datepicker({
                changeMonth: true,
                changeYear: true,
                
                yearRange: "'<% DateTime.Now.ToString(); %>':2050",
                dateFormat: "dd-mm-yy",
            });

            $("#MainContent_txtFechaFin").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "'<% DateTime.Now.ToString(); %>':2050",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();
            
        });

        
    </script>
</asp:Content>
