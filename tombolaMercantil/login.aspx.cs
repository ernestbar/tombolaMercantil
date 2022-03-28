using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tombolaMercantil
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    txtUsuario.Focus();
                    lblAviso.Text = "";
                }
                catch (Exception ex)
                {
                    string aux = ex.ToString();
                }

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string[] datos = Clases.Usuarios.Ingreso_usuario(txtUsuario.Text, txtPassword.Text).Split('|');
            if (datos[1] == "Login correcto")
            {
                //Clases.enviar_correo objC = new Clases.enviar_correo();
                //string resp_email = objC.enviar("ernesto.barron@gmail.com", "Confirmacion de requisitos", "Pruebas de envio de correo.", "");

                Session["usuario"] = txtUsuario.Text;
                Response.Redirect("dashboard.aspx");
                lblAviso.Text = "";

            }
            else
            { lblAviso.Text = "Usuario y contraseña incorrectas!"; txtUsuario.Focus(); }


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clases.Usuarios per = new Clases.Usuarios("R", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", txtUsuario.Text, "", "", "", DateTime.Now, DateTime.Now, "", txtUsuario.Text);
            string[] datos = per.ABM().Split('|');
            if (datos[2] == "PASSWORD CORRECTAMENTE REGISTRADO")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password se reseteo correctamente a 123');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password NO se reseteo correctamente a 123');", true);
            }
        }
    }
}