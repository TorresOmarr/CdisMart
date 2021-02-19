using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.Paginas
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();

            



        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/login.aspx");

        }

        public void RegistrarUsuario()
        {

            UserBLL userBLL = new UserBLL();
            User usuario = new User();

            usuario.UserName = txtUsuario.Text;
            usuario.Password = txtContrasena.Text;
            usuario.Name = txtNombre.Text;
            usuario.Email = txtCorreo.Text;

            

            try
            {
                userBLL.RegistrarUsuario(usuario);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Alumno agregado exitosamente.')", true);

            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" +ex.Message + "')");
            }

            

            Response.Redirect("~/Paginas/Login.aspx");


        }
    }
}