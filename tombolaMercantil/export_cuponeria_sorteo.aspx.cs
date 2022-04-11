using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tombolaMercantil
{
    public partial class export_cuponeria_sorteo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();

                    MultiView1.ActiveViewIndex = 0;

                }
            }
        }

        protected void btnExportarCupones_Click(object sender, EventArgs e)
        {

        }

        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Repeater1.DataSource= Clases.Sorteos.PR_SOR_GET_EXPORT_CUPONERIA_PANTALLA(ddlSorteo.SelectedValue, Int64.Parse(txtNroPagina.Text), Int64.Parse(txtNroRegistros.Text));
            Repeater1.DataBind();
        }

        protected void ddlSorteo_DataBound1(object sender, EventArgs e)
        {
            ddlSorteo.Items.Insert(0,"SELECCIONAR");
        }

        protected void ddlTipoArchivo_DataBound(object sender, EventArgs e)
        {
            ddlTipoArchivo.Items.Insert(0, "SELECCIONAR");
        }
    }
}