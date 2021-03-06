﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de FacadeCategoria
/// </summary>
public class FacadeCategoria
{
    Conexion conectarBD = new Conexion();
    public FacadeCategoria()
    {

    }
    public int obtenerIDcategoria(string nombreCat )
    {

        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "getID_Categoria";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;    // Indicar que se ejecuta un Procedimiento en vez de una
        cmdBuscar.Parameters.AddWithValue("@nCategoria", nombreCat);    // Los parametros del procedimiento, si tuviera
        SqlDataReader rdr = cmdBuscar.ExecuteReader(CommandBehavior.CloseConnection);
        int nroInscritos = 0;
        rdr.Read();
        //while(rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
        // {
        nroInscritos = rdr.GetInt32(rdr.GetOrdinal("codigo_cate"));
        // }

        return nroInscritos;
    }


    public Categoria getCategoriaById(int idcat)
    {
        SqlCommand cmdBuscar = new SqlCommand();
        cmdBuscar.Connection = conectarBD.Conectar();
        cmdBuscar.CommandText = "buscar_categoriaXidcat";             // Nombre del procedimiento almacenado
        cmdBuscar.CommandType = CommandType.StoredProcedure;
        cmdBuscar.Parameters.AddWithValue("@idcat", idcat);    // Los parametros del procedimiento, si 
        SqlDataReader rdr = cmdBuscar.ExecuteReader();

        rdr.Read();
        string nombre = rdr.GetString(rdr.GetOrdinal("nombre_cate"));
        string categoria = rdr.GetString(rdr.GetOrdinal("descripcion_cate"));

        Categoria cat = new Categoria(idcat, nombre, categoria);
        conectarBD.cerrarSQL();

        return cat;

    }
}