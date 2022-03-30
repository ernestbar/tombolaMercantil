﻿using System;
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
            if (Session["usuario"] == null)
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
                limpiar_controles();

            }

        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodSorteo.Text = "";
            lblCodSorteoDetalle.Text = "";
            txtDescripcion.Enabled = true;
            ddlTipoSorteo.DataBind();
            fuLogo.Dispose();
            lblFechaDesde.Text = "";
            lblFechaHasta.Text = "";
            lblFechaSorteo.Text = "";
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
                ddlTipoSorteo.SelectedValue = cli.PV_TIPO_SORTEO;
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

        

        protected void ddlTipoSorteo_DataBound(object sender, EventArgs e)
        {
            ddlTipoSorteo.Items.Insert(0,"SELECCIONAR");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblCodSorteo.Text == "")
                {
                    string fecha = hfFechaSorteo.Value;
                    DateTime fecha_sorteo = DateTime.Parse(hfFechaSorteo.Value);
                    //Clases.Sucursales cli = new Clases.Sucursales("I", txtCodigo.Text, txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, ddlCiudad.SelectedValue, txtLatitud.Text, txtLongitud.Text, lblUsuario.Text);
                    //string resultado = cli.ABM();
                    //string[] aux = resultado.Split('|');
                    //lblAviso.Text = aux[1];
                    //Repeater1.DataBind();
                    //MultiView1.ActiveViewIndex = 0;
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);
                }
                else
                {

                    //Clases.Sucursales cli = new Clases.Sucursales("U", lblCodSucursal.Text, txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, ddlCiudad.SelectedValue, txtLatitud.Text, txtLongitud.Text, lblUsuario.Text);
                    //string resultado = cli.ABM();
                    //string[] aux = resultado.Split('|');
                    //lblAviso.Text = aux[1];
                    //Repeater1.DataBind();
                    //MultiView1.ActiveViewIndex = 0;
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + aux[1] + "');", true);
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sorteos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 0;
        }
    }
}