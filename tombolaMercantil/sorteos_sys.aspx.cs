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
                    
                    MultiView1.ActiveViewIndex = 0;

                }
            }
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            if (lblTipoSorteo.Text.ToUpper() == "DIGITAL")
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
                int cantidad = int.Parse(lblCantidad.Text);
                cantidad--;
                lblCantidad.Text = cantidad.ToString();
                if (lblCantidad.Text == "0")
                    btnIniciar.Enabled = false;
            }
            
        }



        protected void ddlSorteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnIniciar.Enabled = true;
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblTipoSorteo.Text = obj.PV_DESC_TIPO_SORTEO;
            imgLogo.ImageUrl = obj.PV_LOGO;
            panel_opciones_sorteo.Visible = true;
            panel_casillas_sorteo.Visible = true;
            panel_ganador.Visible = true;
            DataTable dt = Clases.Sorteos_detalle.PR_SOR_GET_SORTEOS_DETALLE(cod_sorteo);
            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = dt.Rows.Count.ToString();


            }
            else
            {
                panel_casillas_sorteo.Visible = false;
                panel_opciones_sorteo.Visible = false;
            }

            DataTable dt1 = Clases.Sorteos.PR_SOR_GET_SORTEOS_ASIGNAR_SORTEO();
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["COD_SORTEO"].ToString() == cod_sorteo)
                {
                    num_digitos(int.Parse(dr["NUM_DIGITOS"].ToString()));
                    //num_digitos(5);
                }
                
            }

        }

       

        protected void ddlSorteo_DataBound(object sender, EventArgs e)
        {
            ddlSorteo.Items.Insert(0, "Seleccionar sorteo");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            ddlSorteo.SelectedIndex = 0;
            lblCantidad.Text = "";
            lblTipoSorteo.Text = "";
            btnIniciar.Enabled = true;
            lblGanador.Text = "";
            lblPremio.Text = "";
            panel_casillas_sorteo.Visible = false;
            panel_ganador.Visible = false;

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            btnIniciar.Enabled = true;
        }

        public void num_digitos(int numero)
        {
            if (numero == 9)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = true;
                txt5.Visible = true;
                Image6.Visible = true;
                txt6.Visible = true;
                Image7.Visible = true;
                txt7.Visible = true;
                Image8.Visible = true;
                txt8.Visible = true;
                Image9.Visible = true;
                txt9.Visible = true;
            }
            if (numero == 8)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = true;
                txt5.Visible = true;
                Image6.Visible = true;
                txt6.Visible = true;
                Image7.Visible = true;
                txt7.Visible = true;
                Image8.Visible = true;
                txt8.Visible = true;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 7)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = true;
                txt5.Visible = true;
                Image6.Visible = true;
                txt6.Visible = true;
                Image7.Visible = true;
                txt7.Visible = true;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 6)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = true;
                txt5.Visible = true;
                Image6.Visible = true;
                txt6.Visible = true;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 5)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = true;
                txt5.Visible = true;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 4)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = true;
                txt4.Visible = true;
                Image5.Visible = false;
                txt5.Visible = false;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 3)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = true;
                txt3.Visible = true;
                Image4.Visible = false;
                txt4.Visible = false;
                Image5.Visible = false;
                txt5.Visible = false;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 2)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = true;
                txt2.Visible = true;
                Image3.Visible = false;
                txt3.Visible = false;
                Image4.Visible = false;
                txt4.Visible = false;
                Image5.Visible = false;
                txt5.Visible = false;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 1)
            {
                Image1.Visible = true;
                txt1.Visible = true;
                Image2.Visible = false;
                txt2.Visible = false;
                Image3.Visible = false;
                txt3.Visible = false;
                Image4.Visible = false;
                txt4.Visible = false;
                Image5.Visible = false;
                txt5.Visible = false;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }
            if (numero == 0)
            {
                Image1.Visible = false;
                txt1.Visible = false;
                Image2.Visible = false;
                txt2.Visible = false;
                Image3.Visible = false;
                txt3.Visible = false;
                Image4.Visible = false;
                txt4.Visible = false;
                Image5.Visible = false;
                txt5.Visible = false;
                Image6.Visible = false;
                txt6.Visible = false;
                Image7.Visible = false;
                txt7.Visible = false;
                Image8.Visible = false;
                txt8.Visible = false;
                Image9.Visible = false;
                txt9.Visible = false;
            }

        }

        protected void btnListaGanadores_Click(object sender, EventArgs e)
        {

        }
    }
}