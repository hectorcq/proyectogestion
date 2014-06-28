using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de FacadeCliente
/// </summary>
public class FacadeProducto
{
    Conexion conectarBD = new Conexion();
    public FacadeProducto()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    //Buscar producto sin parametros 

    public DataSet buscarProductoALL()
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "LlenarTabla_productos";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;

    }
    public DataSet buscarProductoX(string txtProd,string BuscarPor) 
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = BuscarPor;             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@texto_buscar", txtProd );    // Los parametros del procedimiento, si tuviera
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar,"mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
// Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;
        
    }
  




    public void IngresarProducto(int cod_categ, string nombre_prod, string descripcion_prod, string unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod, byte imagen)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "ingresar_productos";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        int codigo_prod = getID()+1;
        cmdInsert.Parameters.AddWithValue("@codigo_prod", codigo_prod);
        cmdInsert.Parameters.AddWithValue("@codigo_cate", cod_categ);
        cmdInsert.Parameters.AddWithValue("@nombre_prod", nombre_prod);
        cmdInsert.Parameters.AddWithValue("@descripcion_prod", descripcion_prod);
        cmdInsert.Parameters.AddWithValue("@unidad_prod", unidad_prod);
        cmdInsert.Parameters.AddWithValue("@stock_prod", stock_prod);
        cmdInsert.Parameters.AddWithValue("@precioventa_prod", precioventa_prod);
        cmdInsert.Parameters.AddWithValue("@preciocompra_prod", preciocompra_prod);
        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);
        cmdInsert.ExecuteNonQuery();
        conectarBD.cerrarSQL();
        

    }
    public int getID()
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "idCod_productos";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        SqlDataReader rdr = cmdBuscar.ExecuteReader();
        int id = 0;
        rdr.Read();
        id = rdr.GetInt32(rdr.GetOrdinal("id"));  
        conectarBD.cerrarSQL();
        return id;
    }

}