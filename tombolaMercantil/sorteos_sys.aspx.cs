using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tombolaMercantil
{
    public partial class sorteos_sys : System.Web.UI.Page
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
                    //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
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

        protected void ddlSorteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblTipoSorteo.Text = obj.PV_DESC_TIPO_SORTEO;
            imgLogo.ImageUrl = obj.PV_LOGO;
            DataTable dt = Clases.Sorteos_detalle.PR_SOR_GET_SORTEOS_DETALLE(cod_sorteo);
            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = dt.Rows.Count.ToString();
            }

        }

        protected void ddlSorteo_DataBound(object sender, EventArgs e)
        {
            ddlSorteo.Items.Insert(0, "Seleccionar sorteo");
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string cupon = "";
            string cupon_aux = "";

            int x;
            x = 0;
            while (x < 9)
            {
                int random_number = new Random().Next(0, 10);
                if (x == 0)
                {

                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(random_number.ToString(), "4").Rows)
                    {
                        if (dr["resultado"].ToString() == "1")
                        {
                            cupon = cupon + random_number.ToString();
                            cupon_aux = cupon_aux + random_number.ToString() + "|";
                            x++;
                        }

                    }

                }
                else
                {
                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(cupon + random_number.ToString(), "4").Rows)
                    {
                        if (dr["resultado"].ToString() == "1")
                        {
                            cupon = cupon + random_number.ToString();
                            cupon_aux = cupon_aux + random_number.ToString() + "|";
                            x++;
                        }

                    }
                }


            }
            lblAviso.Text = cupon;

            string[] numeros = cupon_aux.Split('|');

            txt1.Text = numeros[0];
            txt2.Text = numeros[1];
            txt3.Text = numeros[2];
            txt4.Text = numeros[3];
            txt5.Text = numeros[4];
            txt6.Text = numeros[5];
            txt7.Text = numeros[6];
            txt8.Text = numeros[7];
            txt9.Text = numeros[8];
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}