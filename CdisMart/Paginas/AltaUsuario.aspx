<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="CdisMart.Paginas.AltaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de usuario</title>
</head>
<body>
    <form id="formRegistro" runat="server">
        <div id="imgregistro">
            <h1>Registro de usario</h1>
            <table>
                <tr>
                    <td>Nombre Completo</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server"  ControlToValidate="txtNombre"
                            ErrorMessage="El nombre es requerido" ValidationGroup="vlg1" Display="Dynamic" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Nombre" runat="server" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-zÑñÁáÉéÍíÓóÚúÜü ]{1,50}$"
                            ValidationGroup="vlg1" ErrorMessage="Solo se permiten letras" Display="Dynamic" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Correo Electronico</td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Correo" runat="server"  ControlToValidate="txtCorreo"
                            ErrorMessage="El correo es requerido" ValidationGroup="vlg1" Display="Dynamic" ></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="rev_Correo" runat="server" ControlToValidate="txtCorreo" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                            ValidationGroup="vlg1" ErrorMessage="Introduzca un correo valido" Display="Dynamic" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Usuario</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_Usuario" runat="server"  ControlToValidate="txtUsuario"
                            ErrorMessage="El usuario es requerido" ValidationGroup="vlg1" Display="Dynamic" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Usuario" runat="server" ControlToValidate="txtUsuario" ValidationExpression="^([a-zA-Z0-9_-]){4,10}$"
                            ValidationGroup="vlg1" ErrorMessage="El usuario debe ser alfanumerico de maximo 10 digitos" Display="Dynamic" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contrasena</td>
                    <td>
                        <asp:TextBox ID="txtContrasena" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Contrasena" runat="server"  ControlToValidate="txtContrasena"
                            ErrorMessage="Introduzca una contrasena" ValidationGroup="vlg1" Display="Dynamic" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Contrasena" runat="server" ControlToValidate="txtContrasena" ValidationExpression="^([a-zA-Z0-9_-]){4,10}$"
                            ValidationGroup="vlg1" ErrorMessage="El contrasena debe ser alfanumerico de maximo 10 digitos" Display="Dynamic" ></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td>Confirmacion de contrasena</td>
                    <td>

                        <asp:TextBox ID="txtContrasenaConf" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cv_Contrasena" runat="server" ErrorMessage="Las contrasenas no son iguales" ControlToCompare="txtContrasena" ControlToValidate="txtcontrasenaConf" ValidationGroup="vlg1" ></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" ValidationGroup="vlg1" />
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
