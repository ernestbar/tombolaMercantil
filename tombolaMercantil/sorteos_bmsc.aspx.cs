using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tombolaMercantil
{
    public partial class sorteos_bmsc : System.Web.UI.Page
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
                    panel_casillas_sorteo.Visible = false;
                    panel_opciones_sorteo.Visible = false;

                    panel_ganador.Visible = false;
                    MultiView1.ActiveViewIndex = 0;

                }
            }
        }



        protected void ddlSorteo_DataBound(object sender, EventArgs e)
        {
            ddlSorteo.Items.Insert(0, "Seleccionar sorteo");
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            lblCupon.Text = "";
            lblAviso.Text = "";
            if (lblTipoSorteo.Text.ToUpper() == "MASIVO")
            {

                DataTable dtPremios1 = new DataTable();
                dtPremios1 = Clases.Sorteos.PR_SOR_GET_SORTEO_EN_ORDEN(ddlSorteo.SelectedValue);

                int premios = 0;
                while (premios < dtPremios1.Rows.Count)
                {
                    int x;
                    x = 0;
                    int p;
                    p = 0;
                    DataTable dtPremios = new DataTable();
                    dtPremios = Clases.Sorteos.PR_SOR_GET_SORTEO_EN_ORDEN(ddlSorteo.SelectedValue);
                    if (dtPremios.Rows.Count > 0)
                    {

                        foreach (DataRow drPremios in dtPremios.Rows)
                        {

                            string cupon = "";
                           // string cupon_aux = "";
                            string cod_sorteo_detalle = drPremios["COD_SORTEO_DETALLE"].ToString();
                            int digitos_random = 0;
                            if (lblNroDigitos.Text == "9")
                            {
                                digitos_random = 9;
                                cupon = "";
                            }
                            if (lblNroDigitos.Text == "8")
                            {
                                digitos_random = 8;
                                cupon = "0";
                            }
                            if (lblNroDigitos.Text == "7")
                            {
                                digitos_random = 7;
                                cupon = "00";
                            }
                            if (lblNroDigitos.Text == "6")
                            {
                                digitos_random = 6;
                                cupon = "000";
                            }
                            if (lblNroDigitos.Text == "5")
                            {
                                digitos_random = 5;
                                cupon = "0000";
                            }
                            if (lblNroDigitos.Text == "4")
                            {
                                digitos_random = 4;
                                cupon = "00000";
                            }
                            if (lblNroDigitos.Text == "3")
                            {
                                digitos_random = 3;
                                cupon = "000000";
                            }
                            if (lblNroDigitos.Text == "2")
                            {
                                digitos_random = 2;
                                cupon = "0000000";
                            }
                            if (lblNroDigitos.Text == "1")
                            {
                                digitos_random = 1;
                                cupon = "00000000";
                            }
                            while (x < digitos_random)
                            {
                                int random_number = new Random().Next(0, 9);
                                if (x == 0)
                                {

                                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(random_number.ToString(), ddlSorteo.SelectedValue).Rows)
                                    {
                                        if (dr["resultado"].ToString() == "1")
                                        {
                                            cupon = cupon + random_number.ToString();
                                            //cupon_aux = cupon_aux + random_number.ToString() + "|";
                                            x++;
                                        }

                                    }

                                }
                                else
                                {
                                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(cupon + random_number.ToString(), ddlSorteo.SelectedValue).Rows)
                                    {
                                        if (dr["resultado"].ToString() == "1")
                                        {
                                            cupon = cupon + random_number.ToString();
                                            //cupon_aux = cupon_aux + random_number.ToString() + "|";
                                            x++;
                                        }

                                    }
                                }


                            }

                            x = 0;
                            string cuponFinal = cupon;
                            if (cuponFinal.Length > 0)
                            {
                                int cantidad = int.Parse(lblCantidad.Text);

                               
                                Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, cod_sorteo_detalle, cuponFinal, lblUsuario.Text);
                                string resultado = objCupon.ABM();
                                string[] datos = resultado.Split('|');
                                lblAviso.Text = datos[1];
                                cantidad--;
                                lblCantidad.Text = cantidad.ToString();
                                cuponFinal = "";
                            }

                        }

                    }
                    premios++;
                }
                lblAviso.Text = "SORTEO MASIVO CORRECTAMENTE GENERADO CON " + premios.ToString() + " GANADORES.";
                Repeater2.DataBind();
                MultiView1.ActiveViewIndex = 1;

            }
            
        }



        protected void ddlSorteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            btnIniciar.Enabled = true;
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblTipoSorteo.Text = obj.PV_DESC_TIPO_SORTEO;
            imgLogo.ImageUrl = obj.PV_LOGO;
            lblNroDigitos.Text = obj.NUM_DIGITOS.ToString();
            if (lblNroDigitos.Text == "9")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = ""; Image9.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "";
                txtM9.Focus();
            }
            if (lblNroDigitos.Text == "8")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "0";
                txtM8.Focus();
            }
            if (lblNroDigitos.Text == "7")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM7.Focus();
            }
            if (lblNroDigitos.Text == "6")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM6.Focus();
            }
            if (lblNroDigitos.Text == "5")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM5.Focus();
            }
            if (lblNroDigitos.Text == "4")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM4.Focus();
            }
            if (lblNroDigitos.Text == "3")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM3.Focus();
            }
            if (lblNroDigitos.Text == "2")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM2.Focus();
            }
            if (lblNroDigitos.Text == "1")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM1.Focus();
            }
            if (lblNroDigitos.Text == "0")
            {
                txt1.Text = "0"; Image1.ImageUrl = "~/Imagenes/0.png";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "0";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            int premio_sorteoado = 0;
            DataTable dt = Clases.Sorteos_detalle.PR_SOR_GET_SORTEOS_DETALLE(cod_sorteo);
            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = dt.Rows.Count.ToString();

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["GANADOR"].ToString() == "")
                    {

                    }
                    else
                    {
                        premio_sorteoado++;
                    }

                }
               
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["GANADOR"].ToString() == "")
                    {

                    }
                    else
                    {
                        premio_sorteoado++;
                    }

                }
                if (lblTipoSorteo.Text == "MANUAL")
                {
                    panel_opciones_sorteo.Visible = true;
                    panel_casillas_sorteo.Visible = false;
                    panel_casillas_manuales.Visible = true;
                    panel_ganador.Visible = true;
                    btnGuardarCuponManual.Enabled = true;
                    Panel_masivo_opcion.Visible = false;
                }
                if (lblTipoSorteo.Text == "MASIVO")
                {
                    panel_casillas_manuales.Visible = false;
                    panel_opciones_sorteo.Visible = true;
                    panel_casillas_sorteo.Visible = false;
                    panel_ganador.Visible = false;
                    Panel_digital.Visible = false;
                    txt1.Focus();
                    Panel_masivo_opcion.Visible = true;
                }
                if (lblTipoSorteo.Text == "DIGITAL")
                {
                    panel_casillas_manuales.Visible = false;
                    panel_opciones_sorteo.Visible = true;
                    panel_casillas_sorteo.Visible = true;
                    panel_ganador.Visible = true;
                    Panel_digital.Visible = true;
                    txt1.Focus();
                    btnGuardarGanadorDigital.Enabled = false;
                    btnSiguiente.Enabled = true;
                    Panel_masivo_opcion.Visible = false;
                }

                lblCantidad.Text = (int.Parse(lblCantidad.Text) - premio_sorteoado).ToString();
                lblCupon.Text = "";
                primer_siguiente = 1;
            }
            else
            {
                imgLogo.Dispose();
                panel_casillas_sorteo.Visible = false;
                panel_opciones_sorteo.Visible = false;
                panel_ganador.Visible = false;
                panel_casillas_manuales.Visible = false;

            }

            

        }





        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txtM1.Text = "";
            txtM2.Text = "";
            txtM3.Text = "";
            txtM4.Text = "";
            txtM5.Text = "";
            txtM6.Text = "";
            txtM7.Text = "";
            txtM8.Text = "";
            txtM9.Text = "";
            ddlSorteo.DataBind();
            ddlSorteo.SelectedIndex = 0;
            lblCantidad.Text = "";
            lblTipoSorteo.Text = "";
            btnIniciar.Enabled = true;
            lblGanador.Text = "";
            lblPremio.Text = "";
            panel_casillas_sorteo.Visible = false;
            panel_ganador.Visible = false;
            panel_opciones_sorteo.Visible = false;
            panel_casillas_manuales.Visible = false;
            btnGuardarCuponManual.Enabled = true;
            lblCupon.Text = "";
            btnGuardarGanadorDigital.Enabled = false;
            btnSiguiente.Enabled = true;
            Panel_digital.Visible = false;

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
            txtM1.Text = "";
            txtM2.Text = "";
            txtM3.Text = "";
            txtM4.Text = "";
            txtM5.Text = "";
            txtM6.Text = "";
            txtM7.Text = "";
            txtM8.Text = "";
            txtM9.Text = "";
            lblGanador.Text = "";
            lblPremio.Text = "";
            btnIniciar.Enabled = true;
            Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("D", ddlSorteo.SelectedValue, "", "", lblUsuario.Text);
            string resultado = objCupon.ABM();
            string[] datos = resultado.Split('|');
            lblAviso.Text = datos[1];
            panel_casillas_sorteo.Visible = false;
            panel_ganador.Visible = false;
            panel_opciones_sorteo.Visible = false;
            panel_casillas_manuales.Visible = false;
            btnGuardarCuponManual.Enabled = true;
            lblCantidad.Text = "";
            lblTipoSorteo.Text = "";
            ddlSorteo.DataBind();
            ddlSorteo.SelectedIndex = 0;
            lblCupon.Text = "";
            btnGuardarGanadorDigital.Enabled = false;
            btnSiguiente.Enabled = true;
            Panel_digital.Visible = false;
        }


        protected void btnListaGanadores_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            Repeater2.DataBind();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAsignarCupon_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, id, lblCupon.Text, lblUsuario.Text);
            string resultado = objCupon.ABM();
            string[] datos = resultado.Split('|');
            lblAviso.Text = datos[1];

        }

        protected void btnVolverSorteos_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
        }

        protected void txtM1_TextChanged(object sender, EventArgs e)
        {

            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text, ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM2.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM1.Text;
                }
                else
                {
                    txtM1.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM2_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text, ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM3.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM2.Text;

                }
                else
                {
                    txtM2.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM3_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM4.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM3.Text;
                }
                else
                {
                    txtM3.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM4_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM5.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM4.Text;
                }
                else
                {
                    txtM4.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM5_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM6.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM5.Text;
                }
                else
                {
                    txtM5.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM6_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM7.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM6.Text;
                }
                else
                {
                    txtM6.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM7_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM8.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM7.Text;
                }
                else
                {
                    txtM7.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM8_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text + txtM8.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    txtM9.Focus();
                    lblAviso.Text = "";
                    lblCupon.Text = lblCupon.Text + txtM8.Text;
                }
                else
                {
                    txtM8.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }

        protected void txtM9_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text + txtM8.Text + txtM9.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    lblCupon.Text = lblCupon.Text + txtM9.Text;
                    lblAviso.Text = "";
                }
                else
                {
                    txtM9.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }


        protected void btnGuardarCuponManual_Click(object sender, EventArgs e)
        {
            lblCupon.Text = txtM9.Text + txtM8.Text + txtM7.Text + txtM6.Text + txtM5.Text + txtM4.Text + txtM3.Text + txtM2.Text + txtM1.Text;
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(lblCupon.Text,ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    int cantidad = int.Parse(lblCantidad.Text);
                    int aux = 1;
                    lblCantidad.Text = cantidad.ToString();
                    if (lblCantidad.Text == "0")
                    {
                        btnIniciar.Enabled = false;
                    }
                    else
                    {
                        DataTable dtPremios = new DataTable();
                        dtPremios = Clases.Sorteos.PR_SOR_GET_SORTEO_EN_ORDEN(ddlSorteo.SelectedValue);
                        if (dtPremios.Rows.Count > 0)
                        {
                            foreach (DataRow drPremios in dtPremios.Rows)
                            {

                                if (aux == 1)
                                {
                                    Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, drPremios["COD_SORTEO_DETALLE"].ToString(), lblCupon.Text, lblUsuario.Text);
                                    string resultado = objCupon.ABM();
                                    string[] datos = resultado.Split('|');
                                    lblAviso.Text = datos[1];
                                    lblCupon.Text = "";
                                    DataTable dtPremiado = Clases.Sorteos.PR_SOR_GET_SORTEO_PREMIADO(ddlSorteo.SelectedValue, drPremios["COD_SORTEO_DETALLE"].ToString());
                                    if (dtPremiado.Rows.Count > 0)
                                    {
                                        foreach (DataRow drPermiado in dtPremiado.Rows)
                                        {
                                            lblGanador.Text = drPermiado["nombre_cliente"].ToString();
                                            lblPremio.Text = drPermiado["premio"].ToString();

                                        }
                                    }
                                }
                                aux++;
                            }
                        }
                        cantidad--;
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + "Cupon premiado, ganador: " +lblGanador.Text + "');", true);

                    }
                    lblCantidad.Text = cantidad.ToString();
                    if (lblCantidad.Text == "0")
                    {
                        btnGuardarCuponManual.Enabled = false;

                    }
                }
                else
                {
                    //txtM9.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + "No se encontraron cupones con este digito." + "');", true);
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }

        }



        protected void btnLimpiarCasillas_Click(object sender, EventArgs e)
        {
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblNroDigitos.Text = obj.NUM_DIGITOS.ToString();
            if (lblNroDigitos.Text == "9")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = ""; Image9.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "";
                txtM9.Focus();
            }
            if (lblNroDigitos.Text == "8")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "0";
                txtM8.Focus();
            }
            if (lblNroDigitos.Text == "7")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM7.Focus();
            }
            if (lblNroDigitos.Text == "6")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM6.Focus();
            }
            if (lblNroDigitos.Text == "5")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM5.Focus();
            }
            if (lblNroDigitos.Text == "4")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM4.Focus();
            }
            if (lblNroDigitos.Text == "3")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM3.Focus();
            }
            if (lblNroDigitos.Text == "2")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM2.Focus();
            }
            if (lblNroDigitos.Text == "1")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
                txtM1.Focus();
            }
            if (lblNroDigitos.Text == "0")
            {
                txt1.Text = "0"; Image1.ImageUrl = "~/Imagenes/0.png";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "0";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            lblGanador.Text = "";
            lblPremio.Text = "";
            lblAviso.Text = "";
            lblCupon.Text = "";
        }

        protected void btnVerificarCuponManual_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text + txtM8.Text + txtM9.Text,
                ddlSorteo.SelectedValue).Rows)
            {
                if (dr["resultado"].ToString() == "1")
                {
                    lblCupon.Text = lblCupon.Text + txtM9.Text;
                    lblAviso.Text = "";
                }
                else
                {
                    txtM9.Focus();
                    lblAviso.Text = "No se encontraron cupones con este digito.";
                }

            }
        }
        static int primer_siguiente = 1;
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string num_aux = txt9.Text + txt8.Text + txt7.Text + txt6.Text + txt5.Text + txt4.Text + txt3.Text + txt2.Text + txt1.Text;

            int x = 0;
            if (primer_siguiente == 1)
            {
                if (lblNroDigitos.Text == "9")
                    lblCupon.Text = "";
                if (lblNroDigitos.Text == "8")
                    lblCupon.Text = "0";
                if (lblNroDigitos.Text == "7")
                    lblCupon.Text = "0|0";
                if (lblNroDigitos.Text == "6")
                    lblCupon.Text = "0|0|0";
                if (lblNroDigitos.Text == "5")
                    lblCupon.Text = "0|0|0|0";
                if (lblNroDigitos.Text == "4")
                    lblCupon.Text = "0|0|0|0|0";
                if (lblNroDigitos.Text == "3")
                    lblCupon.Text = "0|0|0|0|0|0";
                if (lblNroDigitos.Text == "2")
                    lblCupon.Text = "0|0|0|0|0|0|0";
                if (lblNroDigitos.Text == "1")
                    lblCupon.Text = "0|0|0|0|0|0|0|0";
            }
            
            //if(lblNroDigitos.Text=="9")
            while (x < 1)
            {
                int random_number = new Random().Next(0, 9);
                foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(num_aux + random_number.ToString(), ddlSorteo.SelectedValue).Rows)
                {

                    //lblCupon.Text = lblCupon.Text + random_number + "|";
                    if (dr["resultado"].ToString() == "1")
                    {
                        primer_siguiente = 0;
                        lblCupon.Text = lblCupon.Text + "|" + random_number.ToString();
                        x++;
                        lblAviso.Text = "";
                        string[] numeros = lblCupon.Text.Split('|');
                        if ((numeros.Length) == 9)
                        {
                            txt1.Text = numeros[8]; Image1.ImageUrl = "~/Imagenes/" + numeros[8] + ".png";
                            btnGuardarGanadorDigital.Enabled = true;
                            btnSiguiente.Enabled = false;
                        }
                        if ((numeros.Length) == 8)
                        { txt2.Text = numeros[7]; Image2.ImageUrl = "~/Imagenes/" + numeros[7] + ".png"; }
                        if ((numeros.Length) == 7)
                        { txt3.Text = numeros[6]; Image3.ImageUrl = "~/Imagenes/" + numeros[6] + ".png"; }
                        if ((numeros.Length) == 6)
                        { txt4.Text = numeros[5]; Image4.ImageUrl = "~/Imagenes/" + numeros[5] + ".png"; }
                        if ((numeros.Length) == 5)
                        { txt5.Text = numeros[4]; Image5.ImageUrl = "~/Imagenes/" + numeros[4] + ".png"; }
                        if ((numeros.Length) == 4)
                        { txt6.Text = numeros[3]; Image6.ImageUrl = "~/Imagenes/" + numeros[3] + ".png"; }
                        if ((numeros.Length) == 3)
                        { txt7.Text = numeros[2]; Image7.ImageUrl = "~/Imagenes/" + numeros[2] + ".png"; }
                        if ((numeros.Length) == 2)
                        { txt8.Text = numeros[1]; Image8.ImageUrl = "~/Imagenes/" + numeros[1] + ".png"; }
                        if ((numeros.Length) == 1)
                        { txt9.Text = numeros[0]; Image9.ImageUrl = "~/Imagenes/" + numeros[0] + ".png"; }

                    }
                }

            }


        }

        protected void btnGuardarGanadorDigital_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(lblCantidad.Text);
            int aux = 1;
            lblCantidad.Text = cantidad.ToString();
            if (lblCantidad.Text == "0")
            {
                btnIniciar.Enabled = false;
            }
            else
            {
                DataTable dtPremios = new DataTable();
                dtPremios = Clases.Sorteos.PR_SOR_GET_SORTEO_EN_ORDEN(ddlSorteo.SelectedValue);
                if (dtPremios.Rows.Count > 0)
                {
                    foreach (DataRow drPremios in dtPremios.Rows)
                    {

                        if (aux == 1)
                        {
                            Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, drPremios["COD_SORTEO_DETALLE"].ToString(), lblCupon.Text.Replace("|", ""), lblUsuario.Text);
                            string resultado = objCupon.ABM();
                            string[] datos = resultado.Split('|');
                            lblAviso.Text = datos[1];
                            lblCupon.Text = "";
                            DataTable dtPremiado = Clases.Sorteos.PR_SOR_GET_SORTEO_PREMIADO(ddlSorteo.SelectedValue, drPremios["COD_SORTEO_DETALLE"].ToString());
                            if (dtPremiado.Rows.Count > 0)
                            {
                                foreach (DataRow drPermiado in dtPremiado.Rows)
                                {
                                    lblGanador.Text = drPermiado["nombre_cliente"].ToString();
                                    lblPremio.Text = drPermiado["premio"].ToString();

                                }
                            }
                        }
                        aux++;
                    }
                }
                cantidad--;
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('" + "Cupon premiado, ganador: " +lblGanador.Text + "');", true);
                btnGuardarGanadorDigital.Enabled = false;
                btnOtroSorteoDigital.Visible = true;
            }
            lblCantidad.Text = cantidad.ToString();
            if (lblCantidad.Text == "0")
            {
                btnGuardarGanadorDigital.Enabled = false;
                btnOtroSorteoDigital.Visible = false;
            }
        }

        protected void btnOtroSorteoDigital_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblNroDigitos.Text = obj.NUM_DIGITOS.ToString();
            if (lblNroDigitos.Text == "9")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = ""; Image9.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "";
            }
            if (lblNroDigitos.Text == "8")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = ""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "7")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = ""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "6")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = ""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "5")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = ""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "4")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = ""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "3")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = ""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "2")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = ""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "1")
            {
                txt1.Text = ""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            if (lblNroDigitos.Text == "0")
            {
                txt1.Text = "0"; Image1.ImageUrl = "~/Imagenes/0.png";
                txt2.Text = "0"; Image2.ImageUrl = "~/Imagenes/0.png";
                txt3.Text = "0"; Image3.ImageUrl = "~/Imagenes/0.png";
                txt4.Text = "0"; Image4.ImageUrl = "~/Imagenes/0.png";
                txt5.Text = "0"; Image5.ImageUrl = "~/Imagenes/0.png";
                txt6.Text = "0"; Image6.ImageUrl = "~/Imagenes/0.png";
                txt7.Text = "0"; Image7.ImageUrl = "~/Imagenes/0.png";
                txt8.Text = "0"; Image8.ImageUrl = "~/Imagenes/0.png";
                txt9.Text = "0"; Image9.ImageUrl = "~/Imagenes/0.png";
                txtM1.Text = "0";
                txtM2.Text = "0";
                txtM3.Text = "0";
                txtM4.Text = "0";
                txtM5.Text = "0";
                txtM6.Text = "0";
                txtM7.Text = "0";
                txtM8.Text = "0";
                txtM9.Text = "0";
            }
            lblGanador.Text = "";
            lblPremio.Text = "";
            lblCupon.Text = "";
            btnGuardarGanadorDigital.Enabled = false;
            btnSiguiente.Enabled = true;
            lblCupon.Text = "";
            btnOtroSorteoDigital.Visible = false;
        }

        protected void btnVolverAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}