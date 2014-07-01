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
            Div_ActualizarPedido.Visible = false;
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
    protected void btn_editaPedido_Click(object sender, EventArgs e)
    {
        Div_ActualizarPedido.Visible = true;
        div_Pedidos.Visible = false;
        int id = gridHistorial.SelectedRow.RowIndex;
        string nombre = gridHistorial.SelectedRow.Cells[1].Text;
        string producto = gridHistorial.SelectedRow.Cells[2].Text;
        string cantidad = gridHistorial.SelectedRow.Cells[3].Text;
        string precio = gridHistorial.SelectedRow.Cells[4].Text;
        string fecha = gridHistorial.SelectedRow.Cells[5].Text;

        txt_cliente.Text = nombre;
        txt_cliente.Enabled = false;
        txt_producto.Text = producto;
        txt_producto.Enabled = false;
        txt_cantidad.Text = cantidad;
        txt_cantidad.Enabled = false;
        txt_precio.Text = precio;
        txt_precio.Enabled = false;
        txt_fecha.Text = fecha;
        txt_fecha.Enabled = false;


    }
    protected void btn_Actualizar_Click(object sender, EventArgs e)
    {

        FacadePedido actualiza = new FacadePedido();
        string estado = DropDownList1.SelectedValue;
        Response.Write("<script language=javascript>alert('" + txt_cliente.Text+ "');</script>)");
        actualiza.actualizdaEstadoPedido(txt_cliente.Text, estado, Convert.ToInt32(gridHistorial.SelectedRow.Cells[0].Text));
        Response.Write("<script language=javascript>alert('Estado Actualizado');</script>)");
        Div_ActualizarPedido.Visible = false;
        div_Pedidos.Visible = true;
        recargarTabla();
    }

}
