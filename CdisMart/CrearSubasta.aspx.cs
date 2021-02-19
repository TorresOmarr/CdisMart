using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart
{
    public partial class CrearSubasta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {

                    
                }
                else
                {
                    Response.Redirect("~/Paginas/Login.aspx");
                }
            }

        }

        public void crearSubasta()
        {
            Auction subasta = new Auction();
            AuctionBLL subastaBLL = new AuctionBLL();

            subasta.ProductName = txtNombre.Text;
            subasta.Description = txtDescripcion.Text;
            subasta.StartDate = Convert.ToDateTime(txtFechaInicio.Text);
            subasta.EndDate = Convert.ToDateTime(txtFechaFin.Text);
            subasta.UserId = (int)Session["UserId"];

            try
            {
                subastaBLL.CrearSubasta(subasta);
            }catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('" + ex.Message + "')", true);
            }
            

            
        }

        public void limpiarCarmpos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSubastar_Click(object sender, EventArgs e)
        {
            crearSubasta();
            limpiarCarmpos();
        }
    }
}