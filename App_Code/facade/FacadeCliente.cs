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
public class FacadeCliente
{
    Conexion conectarBD = new Conexion();
    public FacadeCliente()
    {

    }

    public DataSet HistorialCliente(string Rut)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_historialPedi";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@rut", Rut);    // Los parametros del procedimiento, si tuviera
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;

    }



    public DataSet buscarClienteX(string txtCliente, string BuscarPor)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = BuscarPor;             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una Query
        cmdBuscar.Parameters.AddWithValue("@texto_buscar", txtCliente);    // Los parametros del procedimiento, si tuviera
        SqlDataAdapter daBuscar = new SqlDataAdapter(cmdBuscar);

        DataSet dsBuscar = new DataSet();                       // DataSet para cargar los datos
        daBuscar.Fill(dsBuscar, "mitabla");                      // Llena el DataSet con el resultado y lo nombra con un alias "mitabla"
        // Libera los objetos, memoria y cierra la conexion
        daBuscar.Dispose();
        dsBuscar.Dispose();
        conectarBD.cerrarSQL();

        return dsBuscar;

    }

    public DataSet buscarClienteAll()
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_ClienteAll";             // Nombre del procedimiento almacenado
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
    public int IngresarCliente(string rut_clie, string contrasena, string nombre_ciud, string nombre_clie, string direccion_clie, string fono_clie, string email_clie, string estado_clie)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "ingresar_cliente";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        FacadeCiudad fc = new FacadeCiudad();
        int codigo_ciudad = fc.getidCiudadByNombre(nombre_ciud);
        cmdInsert.Parameters.AddWithValue("@rut_clie", rut_clie);
        cmdInsert.Parameters.AddWithValue("@contrasena_clie", contrasena);
        cmdInsert.Parameters.AddWithValue("@codigo_ciud", codigo_ciudad);
        cmdInsert.Parameters.AddWithValue("@nombre_clie", nombre_clie);
        cmdInsert.Parameters.AddWithValue("@direccion_clie", direccion_clie);
        cmdInsert.Parameters.AddWithValue("@fono_clie", fono_clie);
        cmdInsert.Parameters.AddWithValue("@email_clie", email_clie);
        cmdInsert.Parameters.AddWithValue("@estado_clie", estado_clie);
        int registrosInsertados = cmdInsert.ExecuteNonQuery();
        if (registrosInsertados == 1)
        { return 1; }
        else
        { return 0; }

        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);

        conectarBD.cerrarSQL();


    }

    public void ActualizarCliente(string rut_clie, string contrasena, string nombre_ciud, string nombre_clie, string direccion_clie, string fono_clie, string email_clie, string estado_clie)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "actualizar_cliente";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        FacadeCiudad fc = new FacadeCiudad();
        int codigo_ciudad = fc.getidCiudadByNombre(nombre_ciud);
        cmdInsert.Parameters.AddWithValue("@rut_clie", rut_clie);
        cmdInsert.Parameters.AddWithValue("@contrasena_clie", contrasena);
        cmdInsert.Parameters.AddWithValue("@codigo_ciud", codigo_ciudad);
        cmdInsert.Parameters.AddWithValue("@nombre_clie", nombre_clie);
        cmdInsert.Parameters.AddWithValue("@direccion_clie", direccion_clie);
        cmdInsert.Parameters.AddWithValue("@fono_clie", fono_clie);
        cmdInsert.Parameters.AddWithValue("@email_clie", email_clie);
        cmdInsert.Parameters.AddWithValue("@estado_clie", estado_clie);
        cmdInsert.ExecuteNonQuery();
        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);

        conectarBD.cerrarSQL();


    }
    public void EliminarCliente(string rut_clie)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "eliminar_cliente";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        cmdInsert.Parameters.AddWithValue("@rutCliente", rut_clie);

        cmdInsert.ExecuteNonQuery();
        //        cmdInsert.Parameters.AddWithValue("@imagen_prod", imagen);

        conectarBD.cerrarSQL();


    }
    public string getContrasenaCliente(string rut_clie)
    {

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "buscarContrasenacliente";
        cmdInsert.CommandType = CommandType.StoredProcedure;
        cmdInsert.Parameters.AddWithValue("@rut_clie", rut_clie);

        SqlDataReader rdr = cmdInsert.ExecuteReader();
        string id = "";
        rdr.Read();
        id = rdr.GetString(rdr.GetOrdinal("contrasena"));
        conectarBD.cerrarSQL();
        return id;

    }
    public string login(string rut, string contrasena)
    {
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = conectarBD.Conectar();
        cmdInsert.CommandText = "buscar_ClienteLogin";
        cmdInsert.CommandType = CommandType.StoredProcedure;
      

        SqlDataReader rdr = cmdInsert.ExecuteReader();
         
        string mensaje = "no";
        while (rdr.Read())
        {
            //rdr.Read();
            string rutObtenido = rdr.GetString(rdr.GetOrdinal("rut_clie"));
            string contr = rdr.GetString(rdr.GetOrdinal("contrasena"));
            string estado = rdr.GetString(rdr.GetOrdinal("estado_clie"));
            
            if (rutObtenido.Equals(rut) && contr.Equals(contrasena) && estado.Equals("ACTIVO"))
            {
            //    encontrado = "si";
                mensaje = "activo";
            }
            else if (rutObtenido.Equals(rut) && contr.Equals(contrasena) && estado.Equals("INACTIVO"))
            {
                mensaje = "inactivo";

            }
            //else if (!rutObtenido.Equals(rut) && !contr.Equals(contrasena))
            //{
            //    mensaje = "no";
            
            //}
            
        }
        conectarBD.cerrarSQL();
        //return encontrado;
        return mensaje;

    }




}