using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Categoria
/// </summary>
public class Categoria
{

    int codigo_cate;
    string nombre_cate;
    string descripcion_cate;
	public Categoria()
	{
	 
	}
    public Categoria(int codigo_cate, string nombre_cate,string descripcion_cate)
    {
        this.codigo_cate=codigo_cate;
        this.nombre_cate = nombre_cate;
        this.descripcion_cate = descripcion_cate;

    }
    public int getId() {
        return codigo_cate;
    }
    public string getNombre()
    {
        return nombre_cate;
    }
    public string getDesc()
    {
        return descripcion_cate;
    }
}