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
                while(premios< dtPremios1.Rows.Count)
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
                            string cupon_aux = "";
                            string cod_sorteo_detalle = drPremios["COD_SORTEO_DETALLE"].ToString();
                            while (x < 9)
                            {
                                int random_number = new Random().Next(0, 9);
                                if (x == 0)
                                {

                                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(random_number.ToString(), ddlSorteo.SelectedValue).Rows)
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
                                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(cupon + random_number.ToString(), ddlSorteo.SelectedValue).Rows)
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


                            string cuponFinal = cupon_aux.Replace("|", "");
                            if (cuponFinal.Length >= 8)
                            {
                                string[] numeros = cupon_aux.Split('|');

                                txt1.Text = numeros[0]; Image1.ImageUrl = "~/Imagenes/" + numeros[0] + ".png";
                                txt2.Text = numeros[1]; Image2.ImageUrl = "~/Imagenes/" + numeros[1] + ".png";
                                txt3.Text = numeros[2]; Image3.ImageUrl = "~/Imagenes/" + numeros[2] + ".png";
                                txt4.Text = numeros[3]; Image4.ImageUrl = "~/Imagenes/" + numeros[3] + ".png";
                                txt5.Text = numeros[4]; Image5.ImageUrl = "~/Imagenes/" + numeros[4] + ".png";
                                txt6.Text = numeros[5]; Image6.ImageUrl = "~/Imagenes/" + numeros[5] + ".png";
                                txt7.Text = numeros[6]; Image7.ImageUrl = "~/Imagenes/" + numeros[6] + ".png";
                                txt8.Text = numeros[7]; Image8.ImageUrl = "~/Imagenes/" + numeros[7] + ".png";
                                txt9.Text = numeros[8]; Image9.ImageUrl = "~/Imagenes/" + numeros[8] + ".png";
                                int cantidad = int.Parse(lblCantidad.Text);

                                if (lblCantidad.Text == "0")
                                {
                                    btnIniciar.Enabled = false;
                                }
                                else
                                {
                                    Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, cod_sorteo_detalle, cuponFinal, lblUsuario.Text);
                                    string resultado = objCupon.ABM();
                                    string[] datos = resultado.Split('|');
                                    lblAviso.Text = datos[1];
                                }
                                cantidad--;
                                lblCantidad.Text = cantidad.ToString();
                                if (lblCantidad.Text == "0")
                                {
                                    btnIniciar.Enabled = false;
                                }
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

            //if (lblTipoSorteo.Text.ToUpper() == "DIGITAL")
            //{
            //    int x;
            //    x = 0;
            //    DataTable dtPremios = new DataTable();
            //    dtPremios = Clases.Sorteos.PR_SOR_GET_SORTEO_EN_ORDEN(ddlSorteo.SelectedValue);

            //    if (dtPremios.Rows.Count > 0)
            //    {
            //        foreach (DataRow drPremios in dtPremios.Rows)
            //        {
            //            string cupon = "";
            //            string cupon_aux = "";
            //            string cod_sorteo_detalle = drPremios["COD_SORTEO_DETALLE"].ToString();
            //            while (x < 9)
            //            {
            //                int random_number = new Random().Next(0, 9);
            //                if (x == 0)
            //                {

            //                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(random_number.ToString(), ddlSorteo.SelectedValue).Rows)
            //                    {
            //                        if (dr["resultado"].ToString() == "1")
            //                        {
            //                            cupon = cupon + random_number.ToString();
            //                            cupon_aux = cupon_aux + random_number.ToString() + "|";
            //                            x++;
            //                        }

            //                    }

            //                }
            //                else
            //                {
            //                    foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(cupon + random_number.ToString(), ddlSorteo.SelectedValue).Rows)
            //                    {
            //                        if (dr["resultado"].ToString() == "1")
            //                        {
            //                            cupon = cupon + random_number.ToString();
            //                            cupon_aux = cupon_aux + random_number.ToString() + "|";
            //                            x++;
            //                        }

            //                    }
            //                }


            //            }

            //            string cuponFinal = cupon_aux.Replace("|", "");
            //            string[] numeros = cupon_aux.Split('|');

            //            txt1.Text = numeros[0];
            //            txt2.Text = numeros[1];
            //            txt3.Text = numeros[2];
            //            txt4.Text = numeros[3];
            //            txt5.Text = numeros[4];
            //            txt6.Text = numeros[5];
            //            txt7.Text = numeros[6];
            //            txt8.Text = numeros[7];
            //            txt9.Text = numeros[8];
            //            int cantidad = int.Parse(lblCantidad.Text);

            //            if (lblCantidad.Text == "0")
            //            {
            //                btnIniciar.Enabled = false;
            //            }
            //            else
            //            {
            //                Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, cod_sorteo_detalle, cuponFinal, lblUsuario.Text);
            //                string resultado = objCupon.ABM();
            //                string[] datos = resultado.Split('|');
            //                lblAviso.Text = datos[1];
            //            }
            //            cantidad--;
            //            lblCantidad.Text = cantidad.ToString();
            //            if (lblCantidad.Text == "0")
            //            {
            //                btnIniciar.Enabled = false;
            //            }

            //        }

            //    }

            //}
        }



        protected void ddlSorteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            btnIniciar.Enabled = true;
            string cod_sorteo = ddlSorteo.SelectedValue;
            Clases.Sorteos obj = new Clases.Sorteos(cod_sorteo);
            lblTipoSorteo.Text = obj.PV_DESC_TIPO_SORTEO;
            imgLogo.ImageUrl = obj.PV_LOGO;
            txt1.Text =""; Image1.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt2.Text =""; Image2.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt3.Text =""; Image3.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt4.Text =""; Image4.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt5.Text =""; Image5.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt6.Text =""; Image6.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt7.Text =""; Image7.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt8.Text =""; Image8.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txt9.Text =""; Image9.ImageUrl = "~/Imagenes/numeros digitales.gif" ;
            txtM1.Text = "";
            txtM2.Text = "";
            txtM3.Text = "";
            txtM4.Text = "";
            txtM5.Text = "";
            txtM6.Text = "";
            txtM7.Text = "";
            txtM8.Text = "";
            txtM9.Text = "";
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

            }
            else
            {
                imgLogo.Dispose();
                panel_casillas_sorteo.Visible = false;
                panel_opciones_sorteo.Visible = false;
                panel_ganador.Visible = false;
                panel_casillas_manuales.Visible = false;

            }

            //DataTable dt1 = Clases.Sorteos.PR_SOR_GET_SORTEOS_ASIGNAR_SORTEO();
            //foreach (DataRow dr in dt1.Rows)
            //{
            //    if (dr["COD_SORTEO"].ToString() == cod_sorteo)
            //    {
            //        //num_digitos(int.Parse(dr["NUM_DIGITOS"].ToString()));
            //        //num_digitos(5);
            //    }
                
            //}

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
            Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("D", ddlSorteo.SelectedValue,"","", lblUsuario.Text);
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

        //public void num_digitos(int numero)
        //{
        //    if (numero == 9)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = true;
        //        txt5.Visible = true;
        //        Image6.Visible = true;
        //        txt6.Visible = true;
        //        Image7.Visible = true;
        //        txt7.Visible = true;
        //        Image8.Visible = true;
        //        txt8.Visible = true;
        //        Image9.Visible = true;
        //        txt9.Visible = true;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = true;
        //        txtM6.Visible = true;
        //        txtM7.Visible = true;
        //        txtM8.Visible = true;
        //        txtM9.Visible = true;

        //    }
        //    if (numero == 8)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = true;
        //        txt5.Visible = true;
        //        Image6.Visible = true;
        //        txt6.Visible = true;
        //        Image7.Visible = true;
        //        txt7.Visible = true;
        //        Image8.Visible = true;
        //        txt8.Visible = true;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = true;
        //        txtM6.Visible = true;
        //        txtM7.Visible = true;
        //        txtM8.Visible = true;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 7)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = true;
        //        txt5.Visible = true;
        //        Image6.Visible = true;
        //        txt6.Visible = true;
        //        Image7.Visible = true;
        //        txt7.Visible = true;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = true;
        //        txtM6.Visible = true;
        //        txtM7.Visible = true;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 6)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = true;
        //        txt5.Visible = true;
        //        Image6.Visible = true;
        //        txt6.Visible = true;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = true;
        //        txtM6.Visible = true;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 5)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = true;
        //        txt5.Visible = true;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = true;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 4)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = true;
        //        txt4.Visible = true;
        //        Image5.Visible = false;
        //        txt5.Visible = false;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = true;
        //        txtM5.Visible = false;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 3)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = true;
        //        txt3.Visible = true;
        //        Image4.Visible = false;
        //        txt4.Visible = false;
        //        Image5.Visible = false;
        //        txt5.Visible = false;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = true;
        //        txtM4.Visible = false;
        //        txtM5.Visible = false;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 2)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = true;
        //        txt2.Visible = true;
        //        Image3.Visible = false;
        //        txt3.Visible = false;
        //        Image4.Visible = false;
        //        txt4.Visible = false;
        //        Image5.Visible = false;
        //        txt5.Visible = false;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = true;
        //        txtM3.Visible = false;
        //        txtM4.Visible = false;
        //        txtM5.Visible = false;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 1)
        //    {
        //        Image1.Visible = true;
        //        txt1.Visible = true;
        //        Image2.Visible = false;
        //        txt2.Visible = false;
        //        Image3.Visible = false;
        //        txt3.Visible = false;
        //        Image4.Visible = false;
        //        txt4.Visible = false;
        //        Image5.Visible = false;
        //        txt5.Visible = false;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = true;
        //        txtM2.Visible = false;
        //        txtM3.Visible = false;
        //        txtM4.Visible = false;
        //        txtM5.Visible = false;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }
        //    if (numero == 0)
        //    {
        //        Image1.Visible = false;
        //        txt1.Visible = false;
        //        Image2.Visible = false;
        //        txt2.Visible = false;
        //        Image3.Visible = false;
        //        txt3.Visible = false;
        //        Image4.Visible = false;
        //        txt4.Visible = false;
        //        Image5.Visible = false;
        //        txt5.Visible = false;
        //        Image6.Visible = false;
        //        txt6.Visible = false;
        //        Image7.Visible = false;
        //        txt7.Visible = false;
        //        Image8.Visible = false;
        //        txt8.Visible = false;
        //        Image9.Visible = false;
        //        txt9.Visible = false;

        //        txtM1.Visible = false;
        //        txtM2.Visible = false;
        //        txtM3.Visible = false;
        //        txtM4.Visible = false;
        //        txtM5.Visible = false;
        //        txtM6.Visible = false;
        //        txtM7.Visible = false;
        //        txtM8.Visible = false;
        //        txtM9.Visible = false;
        //    }

        //}

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
            lblCupon.Text = txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text + txtM8.Text + txtM9.Text;
            foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(txtM1.Text + txtM2.Text + txtM3.Text + txtM4.Text + txtM5.Text + txtM6.Text + txtM7.Text + txtM8.Text + txtM9.Text,
               ddlSorteo.SelectedValue).Rows)
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
            txtM1.Text = "";
            txtM2.Text = "";
            txtM3.Text = "";
            txtM4.Text = "";
            txtM5.Text = "";
            txtM6.Text = "";
            txtM7.Text = "";
            txtM8.Text = "";
            txtM9.Text = "";
            txtM1.Focus();
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

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string num_aux = txt1.Text + txt2.Text + txt3.Text + txt4.Text + txt5.Text + txt6.Text + txt7.Text + txt8.Text + txt9.Text;
            string cupon = "";
            string cupon_aux = "";
            
            int x = 0;
            while (x < 1)
            {
                int random_number = new Random().Next(0,9);
                foreach (DataRow dr in Clases.Sorteos.PR_SOR_GET_CUPONERIA_EN_SORTEO(num_aux + random_number.ToString(), ddlSorteo.SelectedValue).Rows)
                {
                    cupon_aux = num_aux + random_number + "|";
                    if (dr["resultado"].ToString() == "1")
                    {
                        lblCupon.Text = lblCupon.Text + "|"+ random_number.ToString();
                        x++;
                        lblAviso.Text = "";
                        string[] numeros = lblCupon.Text.Split('|');
                        if ((numeros.Length-1) == 1)
                        { txt1.Text = numeros[1];Image1.ImageUrl = "~/Imagenes/" + numeros[1] + ".png"; }
                        if ((numeros.Length - 1) == 2)
                        { txt2.Text = numeros[2]; Image2.ImageUrl = "~/Imagenes/" + numeros[2] + ".png"; }
                        if ((numeros.Length - 1) == 3)
                        {  txt3.Text = numeros[3]; Image3.ImageUrl = "~/Imagenes/" + numeros[3] + ".png"; }
                        if ((numeros.Length - 1) == 4)
                        {  txt4.Text = numeros[4]; Image4.ImageUrl = "~/Imagenes/" + numeros[4] + ".png"; }
                        if ((numeros.Length - 1) == 5)
                        {  txt5.Text = numeros[5]; Image5.ImageUrl = "~/Imagenes/" + numeros[5] + ".png"; }
                        if ((numeros.Length - 1) == 6)
                        {  txt6.Text = numeros[6]; Image6.ImageUrl = "~/Imagenes/" + numeros[6] + ".png"; }
                        if ((numeros.Length - 1) == 7)
                        { txt7.Text = numeros[7]; Image7.ImageUrl = "~/Imagenes/" + numeros[7] + ".png"; }
                        if ((numeros.Length - 1) == 8)
                        { txt8.Text = numeros[8]; Image8.ImageUrl = "~/Imagenes/" + numeros[8] + ".png"; }
                        if ((numeros.Length - 1) == 9)
                        {
                            txt9.Text = numeros[9];Image9.ImageUrl = "~/Imagenes/" + numeros[9] + ".png"; 
                            btnGuardarGanadorDigital.Enabled = true;
                            btnSiguiente.Enabled = false;
                        }
                        
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
                            Clases.Sorteo_detalle_sorteos objCupon = new Clases.Sorteo_detalle_sorteos("I", ddlSorteo.SelectedValue, drPremios["COD_SORTEO_DETALLE"].ToString(), lblCupon.Text.Replace("|",""), lblUsuario.Text);
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
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            Image1.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image2.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image3.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image4.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image5.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image6.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image7.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image8.ImageUrl = "~/Imagenes/numeros digitales.gif";
            Image9.ImageUrl = "~/Imagenes/numeros digitales.gif";
            lblGanador.Text = "";
            lblPremio.Text = "";
            lblCupon.Text = "";
            btnGuardarGanadorDigital.Enabled = false;
            btnSiguiente.Enabled = true;
            lblCupon.Text = "";
            btnOtroSorteoDigital.Visible = false;
        }
    }
}