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
    public partial class ListaSubastas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_Subastas.DataSource = CargarSubastas();
                    grd_Subastas.DataBind();
                }
                else
                {
                    Response.Redirect("~/Paginas/Login.aspx");
                }
            }


        }

        public List<Auction> CargarSubastas()
        {
            AuctionBLL subastasBLL = new AuctionBLL();

            return subastasBLL.CargarSubastas();

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

        protected void grd_Subastas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Subasta")
            {
                Response.Redirect("~/Subasta.aspx?pProductName=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/HistorialSubasta.aspx?pProductName=" + e.CommandArgument);
            }
        }

       

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string descripcion = txtBuscar.Text;
            grd_Subastas.DataSource = filtarSubastas(descripcion);
            grd_Subastas.DataBind();
            txtBuscar.Text = "";
            
        }

        public List<Auction> filtarSubastas(string descripcion)
        {
            AuctionBLL subastaBLL = new AuctionBLL();
            List<Auction> subastasFiltradas = new List<Auction>();

            subastasFiltradas = subastaBLL.filtrarSubastas(descripcion);

            return subastasFiltradas;

        }

        public void cargarUsuariosPorSubasta()
        {
            UserBLL userBLL = new UserBLL();
            
        }
    }
}