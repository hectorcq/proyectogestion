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
public class FacadePedido
{
    Conexion conectarBD = new Conexion();
    public FacadePedido()
	{
		 
	}



    public DataSet PedidosBy(string por,string texto)
    {

        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = por;             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@txt", texto);
        
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;


    }

    public DataSet PedidosByStatus(string txt)
    {

        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "busca_PedidoByStatus";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@txt", txt);

        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;


    }




    public DataSet allpedidos() {

        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_allPedido";             // Nombre del procedimiento almacenado
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



    public void ingresarPedido(string rut,string estado, List<int>codProducto, List<int> precioProducto) {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "ingresar_pedido";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        int nped = getIDPedido()+1;
        cmdInsert.Parameters.AddWithValue("@numero_pedi", nped);
        cmdInsert.Parameters.AddWithValue("@rut_clie", rut);
        cmdInsert.Parameters.AddWithValue("@estado_pedi", estado);
        cmdInsert.ExecuteNonQuery();
        for (int i = 0; i < codProducto.Count;i++ ) {
            SqlCommand cmdInsertDetalles = new SqlCommand();
            cmdInsertDetalles.Connection = conectarBD.Conectar();
            cmdInsertDetalles.CommandText = "ingresar_detalle";
            cmdInsertDetalles.CommandType = CommandType.StoredProcedure;
            cmdInsertDetalles.Parameters.AddWithValue("@numero_pedi", nped);
            cmdInsertDetalles.Parameters.AddWithValue("@codigo_prod", codProducto[i]);
            cmdInsertDetalles.Parameters.AddWithValue("@cantidad_deta", 1);
            cmdInsertDetalles.Parameters.AddWithValue("@precio_deta", precioProducto[i]);
            cmdInsertDetalles.Parameters.AddWithValue("@subtotal_deta", precioProducto[i]);
            cmdInsertDetalles.ExecuteNonQuery();
        
        
        }
        conectarBD.cerrarSQL();
    
    }

    public int getIDPedido()
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "idNum_pedido";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        SqlDataReader rdr = cmdBuscar.ExecuteReader();
        int id = 0;
        rdr.Read();
        id = rdr.GetInt32(rdr.GetOrdinal("id"));
        conectarBD.cerrarSQL();
        return id;
    }

    public void actualizdaEstadoPedido(string nombre,string estado,int numeroPed) {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "ingresar_pedido";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        int nped = getIDPedido() + 1;
        string rut=getrutClient(nombre);
        cmdInsert.Parameters.AddWithValue("@txt", estado);
        cmdInsert.Parameters.AddWithValue("@rut", nped);
        cmdInsert.Parameters.AddWithValue("@num_pedido", numeroPed);
        
        conectarBD.cerrarSQL();
    
    
    }
    public string getrutClient( string nombre)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "busca_rutBynombre";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@txt", nombre);
        SqlDataReader rdr = cmdBuscar.ExecuteReader();
        string id = "";
        rdr.Read();
        id = rdr.GetString(rdr.GetOrdinal("rut_clie"));
        conectarBD.cerrarSQL();
        return id;
    }
   
}