using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    public string cadenaConn = System.Configuration.ConfigurationManager.ConnectionStrings["SQLCARRITO"].ToString();
    public SqlConnection linkSQL = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        linkSQL.ConnectionString = cadenaConn;
        linkSQL.Open();
        SqlCommand cmdLogin = new SqlCommand();
        cmdLogin.Connection = linkSQL;
        cmdLogin.CommandText = "SELECT * FROM usuarios WHERE usuario=@usuario AND clave=@clave";
        cmdLogin.Parameters.AddWithValue("@usuario", Login1.UserName);
        cmdLogin.Parameters.AddWithValue("@clave", Login1.Password);
        SqlDataReader drLogin = cmdLogin.ExecuteReader();
        if (drLogin.HasRows)
        {
            Session.Add("sesion_usuario", Login1.UserName);
            Session.Add("sesion_clave", Login1.Password);
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }

    }
}