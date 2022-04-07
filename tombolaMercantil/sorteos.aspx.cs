using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace tombolaMercantil
{
    public partial class sorteos : System.Web.UI.Page
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

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            string cupon = "";
            string cupon_aux = "";

            int x;
            x = 0;
            while (x < 9)
            {
                int random_number = new Random().Next(0, 10);
                if (x == 1)
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
                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(cupon+random_number.ToString(), "4").Rows)
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
    }
}