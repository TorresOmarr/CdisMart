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
    public partial class HistorialSubasta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    string nombreProducto = (Request.QueryString["pProductName"]);
                    cargarNombreDescripcionTabla(nombreProducto);                    
                    grd_Subasta.DataSource = cargarHistorialesPorProductoGrd(nombreProducto);
                    grd_Subasta.DataBind();
                    cargarUsuariosSubasta();

                }
                else
                {
                    Response.Redirect("~/Paginas/Login.aspx");
                }
            }
            


        }

        public void cargarNombreDescripcionTabla(string ProductName)
        {            
            AuctionBLL historial = new AuctionBLL();
            Auction hisProducto = new Auction();
            hisProducto = historial.CargarSubasta(ProductName);


            lblNombre.Text = hisProducto.ProductName;
            lblDescripcion.Text = hisProducto.Description;
        }

        public List<Object> cargarHistorialesPorProductoGrd(string ProductName)
        {
            AuctionRecordBLL historial = new AuctionRecordBLL();
            return historial.cargarHistorialesPorProducto(ProductName);

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

        public void cargarUsuariosSubasta()
        {
            string nombreProducto = (Request.QueryString["pProductName"]);
            UserBLL usuarioBLL = new UserBLL();
            List<Object> usuarios = usuarioBLL.usuariosSubasta(nombreProducto);

            ddlUsuario.DataSource = usuarios;
            ddlUsuario.DataTextField = "Nombre" ;
            ddlUsuario.DataValueField = "idUsuario";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("---Seleccione Usuario---", "0"));


        }
        
        
        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex != 0)
            {
                string nombreProducto = (Request.QueryString["pProductName"]);
                int idUsuario = int.Parse(ddlUsuario.SelectedValue);
                AuctionRecordBLL historialBLL = new AuctionRecordBLL();
                List<Object> ofertasUsuario = historialBLL.cargarOfertasdeUsuario(nombreProducto, idUsuario);

                grd_Subasta.DataSource = ofertasUsuario ;
                grd_Subasta.DataBind();

            }
            else
            {
                string nombreProducto = (Request.QueryString["pProductName"]);
                grd_Subasta.DataSource = cargarHistorialesPorProductoGrd(nombreProducto);
                grd_Subasta.DataBind();
            }
        }


    }
}