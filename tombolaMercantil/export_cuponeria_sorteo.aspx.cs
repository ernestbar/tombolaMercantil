using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
            string failure = string.Empty;
            Stream stream = null;
            int bytesToRead = 10000;
            string archivo = Clases.Sorteos.PR_SOR_GET_EXPORT_CUPONERIA_CSV_TXT(ddlSorteo.SelectedValue,ddlTipoArchivo.Text);

            long LengthToRead;
            try
            {

                var path = Server.MapPath("~/ArchivosImp/"+archivo);
                FileWebRequest fileRequest = (FileWebRequest)FileWebRequest.Create(path);
                FileWebResponse fileResponse = (FileWebResponse)fileRequest.GetResponse();

                if (fileRequest.ContentLength > 0)
                    fileResponse.ContentLength = fileRequest.ContentLength;

                //Get the Stream returned from the response
                stream = fileResponse.GetResponseStream();

                LengthToRead = stream.Length;

                //Indicate the type of data being sent
                Response.ContentType = "application/octet-stream";

                //Name the file 
                Response.AddHeader("Content-Disposition", "attachment; filename=SolutionWizardDesktopClient.zip");
                Response.AddHeader("Content-Length", fileResponse.ContentLength.ToString());

                int length;
                do
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        byte[] buffer = new Byte[bytesToRead];

                        // Read data into the buffer.
                        length = stream.Read(buffer, 0, bytesToRead);

                        // and write it out to the response's output stream
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data
                        Response.Flush();

                        //Clear the buffer
                        LengthToRead = LengthToRead - length;
                    }
                    else
                    {
                        // cancel the download if client has disconnected
                        LengthToRead = -1;
                    }
                } while (LengthToRead > 0); //Repeat until no data is read

            }
            finally
            {
                if (stream != null)
                {
                    //Close the input stream                   
                    stream.Close();
                }
                Response.End();
                Response.Close();
            }
            


        }

        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblNroPaginas.Text = " en " + int.Parse((int.Parse(lblTotalRegistros.Text) / int.Parse(txtNroRegistros.Text)).ToString()).ToString() + " paginas de " + txtNroRegistros.Text + " registros.";
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

        protected void ddlSorteoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSorteoFiltro.SelectedValue == "SELECCIONAR")
                lblTotalRegistros.Text = "0";
            else
            {
                DataTable dt = new DataTable();
                dt=Clases.Sorteos.PR_SOR_GET_CANT_CUPONES(ddlSorteoFiltro.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblTotalRegistros.Text = dr[0].ToString();
                        txtNroPagina.Text = "1";
                        txtNroRegistros.Text = "10";
                        lblNroPaginas.Text = " en " + int.Parse((int.Parse(lblTotalRegistros.Text) / int.Parse(txtNroRegistros.Text)).ToString()).ToString() + " paginas de " + txtNroRegistros.Text + " registros.";
                        Repeater1.DataSource = Clases.Sorteos.PR_SOR_GET_EXPORT_CUPONERIA_PANTALLA(ddlSorteoFiltro.SelectedValue, Int64.Parse(txtNroPagina.Text), Int64.Parse(txtNroRegistros.Text));
                        Repeater1.DataBind();
                    }
                }
                else
                {
                    lblTotalRegistros.Text = "0";
                    txtNroPagina.Text = "1";
                    txtNroRegistros.Text = "10";
                    lblNroPaginas.Text = "";

                }
            }
        }
    }
}