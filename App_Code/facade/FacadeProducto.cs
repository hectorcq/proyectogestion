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
    public Producto getProductoALLClass(int idprod)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_productosXidprod";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;
        cmdBuscar.Parameters.AddWithValue("@idprod", idprod);    // Los parametros del procedimiento, si 
        SqlDataReader rdr = cmdBuscar.ExecuteReader();
       
        rdr.Read();
         int id = rdr.GetInt32(rdr.GetOrdinal("ID"));
        string nombre = rdr.GetString(rdr.GetOrdinal("Nombre"));
        int categoria = rdr.GetInt32(rdr.GetOrdinal("categoria"));
        //string desc = rdr.GetString(rdr.GetOrdinal("Detalle"));
        string desc = "No Hay Descripcion";
        string unidad = rdr.GetString(rdr.GetOrdinal("unidad"));
        int stock = rdr.GetInt32(rdr.GetOrdinal("Stock"));
        int precioV = Convert.ToInt32(rdr.GetDecimal(rdr.GetOrdinal("PrecioVenta")));
        int precioC = Convert.ToInt32(rdr.GetDecimal(rdr.GetOrdinal("PrecioCompra")));
        Producto producto = new Producto(id,categoria, nombre, desc,unidad, stock, precioV, precioC);
        conectarBD.cerrarSQL();

        return producto;

    }
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
    public DataSet buscarProductoX(string txtProd, string BuscarPor)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = BuscarPor;             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@texto_buscar", txtProd);    // Los parametros del procedimiento, si tuviera
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;

    }





    public void IngresarProducto(int cod_categ, string nombre_prod, string descripcion_prod, string unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod, byte[] imageSize)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "ingresar_productos";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        int codigo_prod = getID() + 1;
        cmdInsert.Parameters.AddWithValue("@codigo_prod", codigo_prod);
        cmdInsert.Parameters.AddWithValue("@codigo_cate", cod_categ);
        cmdInsert.Parameters.AddWithValue("@nombre_prod", nombre_prod);
        cmdInsert.Parameters.AddWithValue("@descripcion_prod", descripcion_prod);
        cmdInsert.Parameters.AddWithValue("@unidad_prod", unidad_prod);
        cmdInsert.Parameters.AddWithValue("@stock_prod", stock_prod);
        cmdInsert.Parameters.AddWithValue("@precioventa_prod", precioventa_prod);
        cmdInsert.Parameters.AddWithValue("@preciocompra_prod", preciocompra_prod);

        SqlParameter UploadedImage = new SqlParameter
               ("@imagen_prod", SqlDbType.Image, imageSize.Length);
        UploadedImage.Value = imageSize;
        cmdInsert.Parameters.Add(UploadedImage);

        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);
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
    public byte[] getImagenProducto(int idProducto)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "getImagen_Producto";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@idProducto", idProducto);

        byte[] imgBytes = (byte[])cmdBuscar.ExecuteScalar();
        //SqlDataReader rdr = cmdBuscar.ExecuteReader();
        //string id = "";
        //rdr.Read();
        //id = rdr.GetString(rdr.GetOrdinal("imagen_prod"));

        conectarBD.cerrarSQL();
        return imgBytes;

    }
    public void ActualiarProducto(int idProd ,int cod_categ, string nombre_prod, string descripcion_prod, string unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod, byte[] imageSize)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "actualizar_productos";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        cmdInsert.Parameters.AddWithValue("@codigo_prod", idProd);
        cmdInsert.Parameters.AddWithValue("@codigo_cate", cod_categ);
        cmdInsert.Parameters.AddWithValue("@nombre_prod", nombre_prod);
        cmdInsert.Parameters.AddWithValue("@descripcion_prod", descripcion_prod);
        cmdInsert.Parameters.AddWithValue("@unidad_prod", unidad_prod);
        cmdInsert.Parameters.AddWithValue("@stock_prod", stock_prod);
        cmdInsert.Parameters.AddWithValue("@precioventa_prod", precioventa_prod);
        cmdInsert.Parameters.AddWithValue("@preciocompra_prod", preciocompra_prod);
        cmdInsert.Parameters.AddWithValue("@imagen_prod", imageSize);

      

        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);
        cmdInsert.ExecuteNonQuery();
        conectarBD.cerrarSQL();
    }
    public void EliminarProducto(int idProd)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "eliminar_Producto";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        cmdInsert.Parameters.AddWithValue("@idProducto", idProd);
        
        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);
        cmdInsert.ExecuteNonQuery();
        conectarBD.cerrarSQL();
    }


}