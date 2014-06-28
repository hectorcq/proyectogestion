using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pedido
/// </summary>
public class Pedido
{
     string rut_clie;
      string fecha_pedi;
      string hora_pedi;
      string estado_pedi;
      string rut_vend;
	
    public Pedido()
	{
	 
	}
    public Pedido(string rut_clie,string fecha_pedi,string hora_pedi,string estado_pedi, string rut_vend)
    {
        this.rut_clie = rut_clie;
        this.fecha_pedi = fecha_pedi;
        this.hora_pedi = hora_pedi;
        this.estado_pedi = estado_pedi;
        this.rut_vend = rut_vend; 
    }
}