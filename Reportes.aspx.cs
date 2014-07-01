using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sesion = Convert.ToString(Session["usuario"]);

            
            FacadeCliente FC = new FacadeCliente();
            DataSet dset = FC.HistorialCliente(sesion);
            gridHistorial.DataSource = dset;
            gridHistorial.DataBind();                              // Carga los datos en la grid   


        }
    }
    protected void Tabla_Producto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridHistorial.PageIndex = e.NewPageIndex;
        RecargarTaba();
    }
    public void RecargarTaba(){

        string sesion = Convert.ToString(Session["usuario"]);
            FacadeCliente FC = new FacadeCliente();
            DataSet dset = FC.HistorialCliente(sesion);
            gridHistorial.DataSource = dset;
            gridHistorial.DataBind(); 
    
    
    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridHistorial, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {

        
    }

    
     


}
