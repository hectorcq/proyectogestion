﻿using System;
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
    int unidad_prod;
    int stock_prod;
    int precioventa_prod;
    int preciocompra_prod;
    string imagen;
	public Producto()
	{
	}

    public Producto(int codigo_prod ,int cod_categ, string nombre_prod, string descripcion_prod, int unidad_prod, int stock_prod, int precioventa_prod, int preciocompra_prod,string imagen)
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

}