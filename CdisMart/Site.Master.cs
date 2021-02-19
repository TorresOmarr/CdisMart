using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;

namespace CdisMart
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sesionIniciada();
        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                lblNombre.Text = (string)Session["Nombre"];
                return true;
            }
            else
            {
                return false;
            }
        }

        


    }
}