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
    public partial class Subasta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    string nombreProducto = (Request.QueryString["pProductName"]);
                    CargarSubasta(nombreProducto);
                }
                else
                {
                    Response.Redirect("~/Paginas/Login.aspx");
                }
            }
            

        }


        public void CargarSubasta(string nombreProducto)
        {
            string oferta, nombre;
            AuctionBLL subastaBLL = new AuctionBLL();
            Auction subasta = new Auction();
            AuctionRecord historialSubasta = new AuctionRecord();
            AuctionRecordBLL historialSubastaBLL = new AuctionRecordBLL();

            historialSubasta = historialSubastaBLL.cargarHistorialPorProducto(nombreProducto);
            subasta = subastaBLL.CargarSubasta(nombreProducto);

            if(historialSubasta is null) 
            {
                oferta = "00.00";
                nombre = "Sin ofertante";

            }
            else
            {
                oferta = historialSubasta.Amount.ToString();
                nombre = historialSubasta.User.Name;
            }                


            lblIdSubasta.Text = subasta.AuctionId.ToString();
            lblNombre.Text = subasta.ProductName;
            lblDescripcion.Text = subasta.Description;
            lblFechaInicio.Text = subasta.StartDate.ToString();
            lblFechaFin.Text = subasta.EndDate.ToString();
            txtOfertaActual.Text = oferta;
            lblUsuarioOfertaAlta.Text = nombre;

        }

        public void HacerOferta()
        {
            AuctionRecord ofertaParam = new AuctionRecord();
            AuctionRecordBLL ofertaBLL = new AuctionRecordBLL();

            ofertaParam.AuctionId = int.Parse(lblIdSubasta.Text);
            ofertaParam.UserId = (int)Session["UserId"];
            ofertaParam.Amount = Convert.ToDecimal(txtOferta.Text);
            ofertaParam.BidDate = DateTime.Now;

            try
            {
                ofertaBLL.OfertaMasAlta(ofertaParam);
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('" + ex.Message + "')", true);
            }
            

            
        }



        protected void btnOferta_Click(object sender, EventArgs e)
        {

            HacerOferta();
            limpiarCampos();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Oferta hecha exitosamente.')", true);

        }

        public void limpiarCampos()
        {
            txtOferta.Text = "";
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
    }
}