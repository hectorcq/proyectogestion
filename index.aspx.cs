using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

using System.Web.Security;

using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["usuario"] = "false";
        }
        Div_NuevoCliente.Visible = false;

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool Autenticado = false;
        Autenticado = LoginCorrecto(Login1.UserName, Login1.Password);
        e.Authenticated = Autenticado;
        if (Login1.UserName.Equals("11.111.111-1") && Login1.Password.Equals("1"))
        {
            Response.Redirect("Productos.aspx");
        }
        else
        {
            if (Autenticado)
            {
                Session["usuario"] = Login1.UserName;
                Response.Redirect("PaginaUsuario.aspx");
            }
        }
    }

    private bool LoginCorrecto(string Usuario, string Contrasena)
    {

        // if (Usuario.Equals("1") && Contrasena.Equals("1"))
        //   return true; return false;
        bool estado = false;
        FacadeCliente buscar = new FacadeCliente();
        string b = buscar.login(Usuario, Contrasena);
        if (b.Equals("activo"))
        {
            estado = true;

        }
        else if (b.Equals("inactivo"))
        {
            Response.Write("<script language=javascript>alert('Usuario Inactivo');</script>)");
            estado = false;
        }
        else if (b.Equals("no"))
        {
            estado = false;

        }


        return estado;

    }

    protected void btx_RegistrarCliente_Click(object sender, EventArgs e)
    {
        string estado = "ACTIVO";
        FacadeCliente newCliente = new FacadeCliente();
        newCliente.IngresarCliente(txt_RutCliente.Text, txt_contraseCiente.Text, Drop_nombreCiudad.Text, txt_nombreCliente.Text, txt_direccionCliente.Text, txt_FonoCliente.Text, txt_emailCliente.Text, estado);
        Response.Write("<script language=javascript>alert('Usuario Registrado');</script>)");

    }
    protected void btn_cancelRegCliente_Click(object sender, EventArgs e)
    {
        div_login.Visible = true;
        Div_NuevoCliente.Visible = false;
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        div_login.Visible = false;
        Div_NuevoCliente.Visible = true;
    }
}
