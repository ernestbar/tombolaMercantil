using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tombolaMercantil
{
    public partial class consulta_clientes : System.Web.UI.Page
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

                }
            }

        }

        protected void btnExportarCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           Repeater1.DataSource= Clases.Clientes.PR_SOR_GET_CLIENTES(txtNombreCliente.Text, txtCodCliente.Text);
            Repeater1.DataBind();

        }
    }
}