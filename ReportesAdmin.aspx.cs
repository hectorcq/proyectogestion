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




using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FacadePedido FC = new FacadePedido();
            DataSet dset = FC.allpedidos();
            gridHistorial.DataSource = dset;
            gridHistorial.DataBind();
        }
        
    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridHistorial, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void Tabla_Producto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridHistorial.PageIndex = e.NewPageIndex;
        recargarTabla();
    }

    public void recargarTabla(){

        FacadePedido FC = new FacadePedido();
        DataSet dset = FC.allpedidos();
        gridHistorial.DataSource = dset;
        gridHistorial.DataBind();
    
    
    }



    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        string columna = ColBuscada.SelectedValue;
        string by="";
        if (columna == "Cliente") {
            by = "busca_PedidoByNombreCliente";

        }else if(columna=="Producto"){
            by="busca_PedidoByProducto";
        
        }
        else if(columna=="Cantidad"){
            by="busca_PedidoByCantidad";
        
        }
        string txtBusca = txt_texto.Text;

        FacadePedido busca = new FacadePedido();


        DataSet dset = busca.PedidosBy(by, txtBusca);
        gridHistorial.DataSource = dset;
        gridHistorial.DataBind();

    }
    
    protected void rbtLstRating_SelectedIndexChanged(object sender, EventArgs e)
    {
        

             

    }
    protected void btn_status_Click(object sender, EventArgs e)
    {
        string status = rbtLstRating.SelectedItem.Text;
        string by = "";

        if (status == "PENDIENTE")
        {
            by = "PENDIENTE";

        }
        else if (status == "ENTREGADO")
        {
            by = "ENTREGADO";

        }
        else if (status == "ANULADO")
        {
            by = "ANULADO";


        }
        FacadePedido BUSCAR = new FacadePedido();

        DataSet dset = BUSCAR.PedidosByStatus(by); ;
        gridHistorial.DataSource = dset;
        gridHistorial.DataBind();

    }
   
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }
    protected void btn_pdf_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=ReportePedido.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.Write("<b><u>Reporte Pedido</u></b><br/> <br/>");
        gridHistorial.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        gridHistorial.AllowPaging = true;
        gridHistorial.DataBind();
    }
}
