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
            
            string archivo = Clases.Sorteos.PR_SOR_GET_EXPORT_CUPONERIA_CSV_TXT(ddlSorteo.SelectedValue, ddlTipoArchivo.SelectedValue);
            if (archivo != "")
            {
                string nombre_reporte2 = Server.MapPath("~/ArchivosImp/"+ archivo);

                //Response.Write("<script> window.open('" + nombre_reporte2 + "','_blank'); </script>");
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo));

                Response.WriteFile(nombre_reporte2);

                Response.End();

            }
            else
            {
                lblAviso.Text = "No se pudo generar el archivo de exportacion.";
            }
            

        }

        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Repeater1.DataSource= Clases.Sorteos.PR_SOR_GET_EXPORT_CUPONERIA_PANTALLA(ddlSorteoFiltro.SelectedValue, Int64.Parse(txtNroPagina.Text), Int64.Parse(txtNroRegistros.Text));
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

        protected void ddlSorteoFiltro_DataBound(object sender, EventArgs e)
        {
            ddlSorteoFiltro.Items.Insert(0, "SELECCIONAR");
        }
    }
}