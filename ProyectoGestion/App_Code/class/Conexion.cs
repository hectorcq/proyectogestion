using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    private string cn;
    private SqlConnection link;
    
    

    public Conexion() { }
    
    public SqlConnection Conectar()
	{
        // Crea una conexion a la base de datos segun el ID de la cadena de conexion
        // en el archivo web.config
        try
        {
            cn = ConfigurationManager.ConnectionStrings["SQLCARRITO"].ConnectionString;
        }
        catch
        {
            cn = null;
        }
        link = new SqlConnection(cn);
        link.Open();
        return link;
		
	}


     
    public void cerrarSQL()
    {
        // Cierra la conexion 
        link.Close();
    }


}