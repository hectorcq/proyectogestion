using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Producto
/// </summary>
public class Producto
{
    int codigo_prod;
    int cod_categ;
    string nombre_prod;
    string descripcion_prod;
    string unidad_prod;
    int stock_prod;
    int precioventa_prod;
    int preciocompra_prod;
    string imagen;

	public Producto()
	{
	}
  
    public Producto(int codigo_prod, int cod_categ, string nombre_prod, string descripcion_prod, string unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod)
    {
        this.codigo_prod = codigo_prod;
        this.cod_categ = cod_categ;
        this.nombre_prod = nombre_prod;
        this.descripcion_prod = descripcion_prod;
        this.unidad_prod = unidad_prod;
        this.stock_prod = stock_prod;
        this.precioventa_prod = precioventa_prod;
        this.preciocompra_prod = preciocompra_prod;
        
    }
    public Producto(int codigo_prod ,int cod_categ, string nombre_prod, string descripcion_prod, string unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod,string imagen)
    {
        this.codigo_prod = codigo_prod;
        this.cod_categ = cod_categ;
        this.nombre_prod = nombre_prod;
        this.descripcion_prod = descripcion_prod;
        this.unidad_prod = unidad_prod;
        this.stock_prod= stock_prod;
        this.precioventa_prod = precioventa_prod;
        this.preciocompra_prod = preciocompra_prod;
        this.imagen = imagen; 
    }

    public int  id(){
        return codigo_prod;
    }
    public int codCategoria()
    {
        return cod_categ;
    }
    public string nombre()
    {
        return nombre_prod;
    }
    public string Getdescripcion()
    {
        return descripcion_prod;
    }
    public string unidad()
    {
        return unidad_prod;
    }
    public int stock()
    {
        return stock_prod;
    }
    public int precionVenta()
    {
        return precioventa_prod;
    }
     public int precioCompra()
    {
        return preciocompra_prod;
    }

}