using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// <summary>
/// Descripción breve de FacadeCiudad
/// </summary>
public class FacadeCiudad
{

    Conexion conectarBD = new Conexion();
	public FacadeCiudad()
	{
		 
	}
    public int getidCiudadByNombre(string nombreciudad) {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_ciudadByNombre";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query

        cmdBuscar.Parameters.AddWithValue("@nombreCiudad", nombreciudad);    // Los parametros del procedimiento, si tuviera
        SqlDataReader rdr = cmdBuscar.ExecuteReader();
        int id = 0;
        rdr.Read();
        id = rdr.GetInt32(rdr.GetOrdinal("codigo_ciud"));
        conectarBD.cerrarSQL();
        return id;
    }



}