using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace tombolaMercantil
{
    public partial class importacion_clientes : System.Web.UI.Page
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
                    //btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string Ruta = "";
                string archivo = "";
                int control = 0;
                if (fuArchivo.HasFile)
                {
                    Ruta = Server.MapPath("~/ArchivosImp/");
                    archivo = fuArchivo.FileName;
                    if (!Directory.Exists(Ruta))
                    {
                        Directory.CreateDirectory(Ruta);


                    }

                    fuArchivo.PostedFile.SaveAs(Ruta + archivo);
                    control++;
                }

                if (control == 1)
                {
                    Clases.Importacion obj = new Clases.Importacion("I", "", "", ddlTipoSorteo.SelectedValue, ddlTipoArchivo.SelectedValue, archivo, "", "", "", "", "", "", "", "", 0, lblUsuario.Text);
                    string[] resultado = obj.ABM().Split('|');
                    if (resultado[0] == "0" & resultado[2] == "")
                    {
                        lblCodImportacionDatos.Text = resultado[3];
                        control++;
                    }
                    else
                    {
                        lblAviso.Text = resultado[1];
                    }

                }
                int error = 0;
                int lineatotal = 0;
                if (control == 2)
                {
                    System.IO.StreamReader archivoImp = new System.IO.StreamReader(Ruta + archivo);

                    string linea;
                    // Si el archivo no tiene encabezado, elimina la siguiente línea
                    archivoImp.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado
                    while ((linea = archivoImp.ReadLine()) != null)
                    {
                        string[] fila = linea.Split(';');
                        lineatotal++;
                        Clases.Importacion objDet = new Clases.Importacion("ID", lblCodImportacionDatos.Text, "", ddlTipoSorteo.SelectedValue, ddlTipoArchivo.SelectedValue, archivo,
                            fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], Int64.Parse(fila[8]), lblUsuario.Text);

                        string[] resultado = objDet.ABM().Split('|');
                        if (resultado[0] == "0" & resultado[2] == "")
                        {

                        }
                        else
                        {
                            error++;
                            lblAviso.Text = resultado[1];
                            break;
                        }

                    }


                }

                if (error > 0)
                {
                    Clases.Importacion objDet = new Clases.Importacion("D", lblCodImportacionDatos.Text, "", "", "", "",
                        "", "", "", "", "", "", "", "", 0, lblUsuario.Text);
                    lblAviso.Text = "Hubo un error al importar el archivo, en la linea:" + lineatotal.ToString();
                }
                else
                {
                    control++;

                }
                if (control == 3)
                {
                    lblAviso.Text = "Importacion realizada con exito, total registros importados: " + lineatotal.ToString();
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_importacion_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
            
            


        }

        protected void btnGenerar_Click1(object sender, EventArgs e)
        {

            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                string AUX= Clases.Importacion.PR_SOR_ABM_IMPORTACION_CUPON("I", datos[0],lblUsuario.Text);
                string[] resultado = AUX.Split('|');
                lblAviso.Text = resultado[1];
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_importacion_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                Clases.Importacion objDet = new Clases.Importacion("D", datos[0], "", "", "", "",
                    "", "", "", "", "", "", "", "", 0, lblUsuario.Text);
                string[] resultado=objDet.ABM().Split('|');
                
               
                lblAviso.Text = resultado[1];
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_importacion_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void ddlTipoSorteo_DataBound(object sender, EventArgs e)
        {
            ddlTipoSorteo.Items.Insert(0, "SELECCIONAR");
        }


        protected void ddlTipoArchivo_DataBound(object sender, EventArgs e)
        {
            ddlTipoArchivo.Items.Insert(0, "SELECCIONAR");
        }
    }
}