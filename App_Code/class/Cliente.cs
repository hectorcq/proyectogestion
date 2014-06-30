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
    string  estado_clie;
    

    public Cliente()
	{
    		 
    }

    public Cliente( string rut_clie,int codigo_ciud, string nombre_clie, string direccion_clie, int fono_clie, string email_clie, string estado_clie)
    {
        this.rut_clie = rut_clie;
        this.codigo_ciud = codigo_ciud;
        this.nombre_clie = nombre_clie;
        this.direccion_clie = direccion_clie;
        this.fono_clie = fono_clie;
        this.email_clie=email_clie;
        this.estado_clie = estado_clie;
    }

    public string getRut() {
        return rut_clie;
    }
    public int getcodCiudad()
    {
        return codigo_ciud;
    }
    public string getNombre() {
        return nombre_clie;
    }
    public string getDirec()
    {
        return direccion_clie;
    }
    public int getFono()
    {
        return fono_clie;
    }
    public string getEmail()
    {
        return email_clie;
    }
    public string getEstado()
    {
        return estado_clie;

    }
}