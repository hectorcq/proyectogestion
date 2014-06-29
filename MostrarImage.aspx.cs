using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class MostrarImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ImageID"] != null)
        {
            int idProducto = Convert.ToInt32(Request.QueryString["ImageID"]);
            Conexion conectarBD = new Conexion();
            SqlCommand cmdBuscar = new SqlCommand();
            cmdBuscar.Connection = conectarBD.Conectar();
            cmdBuscar.CommandText = "getImagen_Producto";             // Nombre del procedimiento almacenado
            cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
            cmdBuscar.Parameters.AddWithValue("@idProducto", idProducto);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmdBuscar;
            sda.Fill(dt);
            if (dt != null)
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["imagen_prod"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=") ;//+ dt.Rows[0]["Name"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }




        }

         
    }
}