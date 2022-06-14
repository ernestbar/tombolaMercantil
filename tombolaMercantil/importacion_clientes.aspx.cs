﻿using System;
using System.Collections.Generic;
using System.Data;
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
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string Ruta = "";
                string archivo = "";
                int control = 0;
                if (fuArchivo.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(fuArchivo.PostedFile.FileName);
                    if (ext.Replace(".","").ToUpper() == ddlTipoArchivo.SelectedValue)
                    {

                        Ruta = Server.MapPath("~/ArchivosImp/");
                        archivo = fuArchivo.FileName;
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);


                        }
                        //DirectoryInfo di = new DirectoryInfo(Ruta);
                        //FileInfo[] files = di.GetFiles();
                        //foreach (FileInfo file in files)
                        //{
                        //    file.Delete();
                        //}
                        fuArchivo.PostedFile.SaveAs(Ruta + archivo);
                        control++;
                    }
                    else
                    {
                        lblAviso.Text = "Tipo de archivo incorrecto, se seleccionó ."+ddlTipoArchivo.SelectedValue;
                    }
                    
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
                if (control == 2)
                {
                    Clases.Importacion objDet = new Clases.Importacion("ID", lblCodImportacionDatos.Text, "", ddlTipoSorteo.SelectedValue, ddlTipoArchivo.SelectedValue, archivo,
                        "", "", "", "", "", "", "", "", 0, lblUsuario.Text);
                    string[] resultado = objDet.ABM().Split('|');
                    lblAviso.Text = resultado[1];
                   


                }
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

        protected void btnGenerar_Click1(object sender, EventArgs e)
        {

            try
            {
                Clases.Importacion.limpiar();
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                string AUX = Clases.Importacion.PR_SOR_ABM_IMPORTACION_CUPON("I", datos[0], lblUsuario.Text);
                string[] resultado = AUX.Split('|');
                lblAviso.Text = resultado[1];
                ddlTipoSorteo.DataBind();
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
                ddlTipoSorteo.DataBind();
               
                lblAviso.Text = resultado[1];
                Repeater1.DataBind();
                Clases.Importacion.limpiar();
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

        protected void btnGenerar2_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();

            string path = Server.MapPath("~/Cuponeria/" + id + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt");
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    DataTable dt = new DataTable();
                    dt = Clases.Importacion.PR_SOR_GET_IMPORTACION_DATOS_DETALLE(id);
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < int.Parse(dr["CUPONES_FINAL"].ToString()); i++)
                        {
                            int num_rand= new Random().Next(0, 65000000);
                            string linea = dr["COD_IMPORTACION_DATOS_DETALLE"].ToString() + ","+ num_rand + "," + DateTime.Now.ToString() + "," + lblUsuario.Text + "," + id + "," + "";
                            sw.WriteLine(linea);
                        }

                    }
                    
                }
                
            }
           
        }
    }
}