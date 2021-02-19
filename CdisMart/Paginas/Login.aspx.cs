using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        public object New { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (UsuarioValido())
            {
                Response.Redirect("~/ListaSubastas.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert ('Usuario y/o contraseña incorrectos.')", true);
            }

        }

        public bool UsuarioValido()
        {
            bool acceso = false;

            UserBLL userBLL = new UserBLL();
            User Usuario = new User();

            Usuario = userBLL.ConsultarUsuario(txtUsuario.Text, txtContraseña.Text);

            if (Usuario != null)
            {
                Session["Usuario"] = Usuario;
                Session["Nombre"] = Usuario.Name;
                Session["UserId"] = Usuario.UserId;
                acceso = true;
            }

            return acceso;
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/AltaUsuario.aspx");
        }
    }
}