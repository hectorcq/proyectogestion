using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class PaginaUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sesion = Convert.ToString(Session["usuario"]);
            
                Label1.Text = "Usuario Aceptado:"+sesion;
        }
       
         
    }
    


    protected void Button1_Click(object sender, EventArgs e)
    {
        Logout();

    }
    public void Logout()
    {
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.Redirect("index.aspx");
    }
}