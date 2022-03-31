using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using System.Data;
using System.IO;
using System.Text;

namespace tombolaMercantil
{
    public partial class sorteos_premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblUsuario.Text = Session["usuario"].ToString();
                //btnNuevoCliente.Visible = false;
                //btnNuevoCliente.Visible = true;
                //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["OPC_DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                //            btnNuevoCliente.Visible = true;
                //    }

                //}
                MultiView1.ActiveViewIndex = 0;
                //limpiar_controles();

            } }
            

        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodSorteo.Text = "";
            lblCodSorteoDetalle.Text = "";
            txtDescripcion.Enabled = true;
            ddlTipo.DataBind();
            fuLogo.Dispose();
            lblFechaDesde.Text = "";
            lblFechaHasta.Text = "";
            lblFechaSorteo.Text = "";
            panel_logo.Visible = false;
        }
        protected void btnNuevoSorteo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar_controles();
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSorteo.Text = id;
                Clases.Sorteos cli = new Clases.Sorteos(id);
                txtDescripcion.Text = cli.PV_DESCRIPCION;
                lblFechaSorteo.Text = cli.PD_FECHA_SORTEO.ToShortDateString();
                lblFechaDesde.Text = cli.PD_FECHA_DESDE.ToShortDateString();
                lblFechaHasta.Text = cli.PD_FECHA_HASTA.ToShortDateString();
                ddlTipo.SelectedValue = cli.PV_TIPO_SORTEO;
                imgLogo.ImageUrl = cli.PV_LOGO;
                panel_logo.Visible = true;
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteo_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSorteo.Text = id;
                MultiView1.ActiveViewIndex = 2;
                    
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteo_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                if (datos[1] == "ACTIVO")
                {
                    Clases.Sorteos mcc = new Clases.Sorteos("D", datos[0], "",DateTime.Now, DateTime.Now, DateTime.Now, "","", lblUsuario.Text);
                    string resultado = mcc.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Sorteos mcc = new Clases.Sorteos("A", datos[0], "", DateTime.Now, DateTime.Now, DateTime.Now, "", "", lblUsuario.Text);
                    string resultado = mcc.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteo_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        

    

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblCodSorteo.Text == "")
                {
                    if (fuLogo.HasFile)
                    {
                        DateTime fecha_sorteo = DateTime.Parse(hfFechaSorteo.Value);
                        DateTime fecha_desde = DateTime.Parse(hfFechaDesde.Value);
                        DateTime fecha_hasta = DateTime.Parse(hfFechaHasta.Value);
                        string url_logo = "";
                        if (fuLogo.HasFile)
                        {
                            string archivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuLogo.FileName;
                            string Ruta = Server.MapPath("~/Logos_sorteo/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);


                            }

                            fuLogo.PostedFile.SaveAs(Ruta + archivo);
                            url_logo = "~/Logos_sorteo/" + archivo;
                        }
                        Clases.Sorteos cli = new Clases.Sorteos("I", "", txtDescripcion.Text, fecha_sorteo, fecha_desde, fecha_hasta, ddlTipo.SelectedValue, url_logo, lblUsuario.Text);
                        string resultado = cli.ABM();
                        string[] aux = resultado.Split('|');
                        lblAviso.Text = aux[1];
                        Repeater1.DataBind();
                        if (aux[0] != "1")
                            MultiView1.ActiveViewIndex = 0;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);
                    }
                    else
                    { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + "Debe elegir un logo para su sorteo." + "');", true); }
                           
                }
                else
                {
                    
                    
                    DateTime fecha_sorteo = DateTime.Parse(hfFechaSorteo.Value);
                    DateTime fecha_desde = DateTime.Parse(hfFechaDesde.Value);
                    DateTime fecha_hasta = DateTime.Parse(hfFechaHasta.Value);

                    if (fecha_sorteo.ToShortDateString() == DateTime.Now.ToShortDateString())
                        fecha_sorteo = DateTime.Parse(lblFechaSorteo.Text);
                    if (fecha_desde.ToShortDateString() == DateTime.Now.ToShortDateString())
                        fecha_desde = DateTime.Parse(lblFechaDesde.Text);
                    if (fecha_hasta.ToShortDateString() == DateTime.Now.ToShortDateString())
                        fecha_hasta = DateTime.Parse(lblFechaHasta.Text);
                    string url_logo = "";
                    if (fuLogo.HasFile)
                    {
                        string archivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuLogo.FileName;
                        string Ruta = Server.MapPath("~/Logos_sorteo/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);


                        }

                        fuLogo.PostedFile.SaveAs(Ruta + archivo);
                        url_logo = "~/Logos_sorteo/" + archivo;
                    }
                    else
                    {
                        url_logo = imgLogo.ImageUrl;
                    }
                    Clases.Sorteos cli = new Clases.Sorteos("U", lblCodSorteo.Text, txtDescripcion.Text, fecha_sorteo, fecha_desde, fecha_hasta, ddlTipo.SelectedValue, url_logo, lblUsuario.Text);
                    string resultado = cli.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater1.DataBind();
                    if (aux[0] != "1")
                        MultiView1.ActiveViewIndex = 0;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);

                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                //lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ddlTipo_DataBound(object sender, EventArgs e)
        {
            ddlTipo.Items.Insert(0, "SELECCIONAR");
        }
        public void limpiar_controles_detalle()
        {
            lblAviso.Text = "";
            lblCodSorteoDetalle.Text = "";
            txtDescripcionD.Text = "";
            txtNroSorteo.Text = "";
        }
        protected void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            limpiar_controles_detalle();
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnEditarD_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar_controles_detalle();
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSorteoDetalle.Text = id;
                Clases.Sorteos_detalle cli = new Clases.Sorteos_detalle(id);
                txtDescripcionD.Text = cli.PV_DESCRIPCION;
                txtNroSorteo.Text = cli.PB_NRO_SORTEO.ToString();
                MultiView1.ActiveViewIndex = 3;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteo_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnDetalleD_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarD_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                if (datos[1] == "ACTIVO")
                {
                    Clases.Sorteos_detalle mcc = new Clases.Sorteos_detalle("D", datos[0], lblCodSorteo.Text,txtDescripcionD.Text,Int64.Parse(txtNroSorteo.Text), lblUsuario.Text);
                    string resultado = mcc.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater2.DataBind();
                }
                else
                {
                    Clases.Sorteos_detalle mcc = new Clases.Sorteos_detalle("A", datos[0], lblCodSorteo.Text, txtDescripcionD.Text, Int64.Parse(txtNroSorteo.Text), lblUsuario.Text);
                    string resultado = mcc.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater2.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteo_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnGuardarD_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblCodSorteoDetalle.Text == "")
                {
                    Clases.Sorteos_detalle cli = new Clases.Sorteos_detalle("I", "", lblCodSorteo.Text,txtDescripcionD.Text, Int64.Parse(txtNroSorteo.Text), lblUsuario.Text);
                    string resultado = cli.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater2.DataBind();
                    if (aux[0] != "1")
                        MultiView1.ActiveViewIndex = 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);
                }
                else
                {
                    Clases.Sorteos_detalle cli = new Clases.Sorteos_detalle("U", lblCodSorteoDetalle.Text, lblCodSorteo.Text, txtDescripcionD.Text, Int64.Parse(txtNroSorteo.Text), lblUsuario.Text);
                    string resultado = cli.ABM();
                    string[] aux = resultado.Split('|');
                    lblAviso.Text = aux[1];
                    Repeater2.DataBind();
                    if (aux[0] == "1")
                        MultiView1.ActiveViewIndex = 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                //lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverD_Click(object sender, EventArgs e)
        {
            limpiar_controles_detalle();
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnVolverDetalle_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}