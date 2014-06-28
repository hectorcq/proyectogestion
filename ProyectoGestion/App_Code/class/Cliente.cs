using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Cliente
{
    string rut_clie;
    int codigo_ciud;
    string nombre_clie;
    string direccion_clie;
    int fono_clie;
    string email_clie;
    int estado_clie;
    int codigo_giro;

    public Cliente()
	{
    		 
    }

    public Cliente( string rut_clie,int codigo_ciud, string nombre_clie, string direccion_clie, int fono_clie, string email_clie, int estado_clie, int codigo_giro)
    {
        this.rut_clie = rut_clie;
        this.codigo_ciud = codigo_ciud;
        this.nombre_clie = nombre_clie;
        this.direccion_clie = direccion_clie;
        this.fono_clie = fono_clie;
        this.email_clie=email_clie;
        this.estado_clie = estado_clie;
        this.codigo_giro = codigo_giro;

    }
}