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

using System.Net.Mail;

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
            FacadeProducto FC = new FacadeProducto();
            DataSet dset = FC.buscarProductoPedido();
            gvAll.DataSource = dset;
            gvAll.DataBind();                              // Carga los datos en la grid   

            div_CrearPedido.Visible = true;
            div_detallePedido.Visible = false;

        }


    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        FacadeProducto FC = new FacadeProducto();
        //OBTENER VALOR DE droplist para filtrar por esa columna
        string columna = ColBuscada.SelectedValue;

        //SELECCIONA LA FORMA DE FILLTRAR DE ACUERDO A LAS COLUMNAS
        string buscarX = "";
        if (columna == "nombre_prod")
        {
            buscarX = "buscar_productosXnombre";

        }
        else if (columna == "descripcion_prod")
        {
            buscarX = "buscar_productosXdescripcion";

        }

        else if (columna == "stock_prod")
        {
            buscarX = "buscar_productosXStock";

        }

        else if (columna == "precioventa_prod")
        {
            buscarX = "buscar_productosXPrecioVenta";

        }

        else if (columna == "preciocompra_prod")
        {
            buscarX = "buscar_productosXPrecioCompra";

        }

        //SI Se PRESIONA BOTON BUSCAR SIN TEXTO SE LLENA TABLA 

        //if (txt_texto.Text == "")
        if (string.IsNullOrEmpty(txt_texto.Text))
        {
            RecargarTaba();

        }
        else
        {

            DataSet dset = FC.buscarProductoX(txt_texto.Text, buscarX); // Asigna el origen de los datos
            gvAll.DataSource = dset;
            gvAll.DataBind();                              // Carga los datos en la grid   

            //SI NO SE ENCUENTRAN PRODUCTOS SE MUESTRA TABLA VACIA
            if (dset.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("ID"), new DataColumn("Nombre"), new DataColumn("Detalles"), new DataColumn("Stock"), new DataColumn("PrecioVenta"), new DataColumn("PrecioCompra") });
                dt.Rows.Add(1, "NO SE ENCONTRARON PRODUCTOS  ", "", "", "", "");
                gvAll.DataSource = dt;
                gvAll.DataBind();

            }
        }


    }
    public void RecargarTaba()
    {

        FacadeProducto FC = new FacadeProducto();
        DataSet dset = FC.buscarProductoPedido();
        gvAll.DataSource = dset;
        gvAll.DataBind();                              // Carga los datos en la grid   


    }


    
    private void BindPrimaryGrid()
    {
        FacadeProducto FC = new FacadeProducto();
        DataSet dset = FC.buscarProductoALL();
        gvAll.DataSource = dset;
        gvAll.DataBind();                              // Carga los datos en la grid   



    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GetData();
        gvAll.PageIndex = e.NewPageIndex;
        BindPrimaryGrid();
        SetData();
    }

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvAll.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvAll.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvAll.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("ID = '" + gvAll.Rows[i].Cells[1].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Stock");
        dt.Columns.Add("Precio");
        dt.Columns.Add("Estado");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ID"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Nombre"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Stock"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Precio"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Estado"] = gvRow.Cells[5].Text;
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
    }

    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvSelected.DataSource = dt;
        gvSelected.DataBind();
    }

    protected void btn_crearPedido_Click(object sender, EventArgs e)
    {
        string sesion = Convert.ToString(Session["usuario"]);
        int nPedido = gvSelected.Rows.Count;
        if (nPedido > 5)
        {
            Response.Write("<script language=javascript>alert('Solo puede elegir 5 productos.');</script>)");

        }
        else if (nPedido == 0)
        {
            Response.Write("<script language=javascript>alert('Elegir producto para hacer pedido.');</script>)");

        }
        else
        {

            List<int> codProducto = new List<int>();
            List<int> preProducto = new List<int>();

            string id = gvSelected.Rows[0].Cells[0].Text;


            string estado = gvSelected.Rows[0].Cells[4].Text;


            for (int i = 0; i < nPedido; i++)
            {

                codProducto.Add(Convert.ToInt32(gvSelected.Rows[i].Cells[0].Text));
                preProducto.Add(Convert.ToInt32(Convert.ToDecimal(gvSelected.Rows[i].Cells[3].Text)));

            }
            FacadePedido newpedido = new FacadePedido();
            newpedido.ingresarPedido(sesion, "PENDIENTE", codProducto, preProducto);
            Response.Write("<script language=javascript>alert('Pedido Ingresado correctamente.');</script>)");

            div_CrearPedido.Visible = false;
            div_detallePedido.Visible = true;


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { 
                            new DataColumn("ID", typeof(int)),  
                            new DataColumn("Nombre", typeof(string)),  
                            new DataColumn("Stock",typeof(string)) ,  
                            new DataColumn("Precio",typeof(string)) ,  
                           new DataColumn("Estado",typeof(string)) });
            int total = 0;
            for (int i = 0; i < nPedido; i++)
            {

                codProducto.Add(Convert.ToInt32(gvSelected.Rows[i].Cells[0].Text));
                preProducto.Add(Convert.ToInt32(Convert.ToDecimal(gvSelected.Rows[i].Cells[3].Text)));
                string stock = gvSelected.Rows[i].Cells[2].Text;
                string nombre = gvSelected.Rows[i].Cells[1].Text;
                int precio = Convert.ToInt32(Convert.ToDecimal(gvSelected.Rows[i].Cells[3].Text));
                total = total + precio;
                dt.Rows.Add(i, codProducto[i], nombre, stock, preProducto[i]);
            }

            dt.Rows.Add(nPedido, "", "", "Subtotal", total);
            gridDetalles.DataSource = dt;
            gridDetalles.DataBind();

        }

    }
    protected void btn_AtrasPedido_Click(object sender, EventArgs e)
    {
        div_detallePedido.Visible = false;
        div_CrearPedido.Visible = true;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }
    protected void btn_generarPDF_Click(object sender, EventArgs e)
    {
        //string sesion = Convert.ToString(Session["usuario"]);
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=ReportePedido.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //hw.Write("<b><u>Reporte Pedido</u></b><br/> <br/>");
        //hw.Write("<br/>Rut Usuario:" + sesion + "<br/>");
        //gvAll.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();
        //gvAll.AllowPaging = true;
        //gvAll.DataBind();

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                gridDetalles.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                    MailMessage mm = new MailMessage("hcayul2011@alu.uct.cl", "hcayul2011@alu.uct.cl");
                    mm.Subject = "GridView Exported PDF";
                    mm.Body = "GridView Exported PDF Attachment";
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "GridViewPDF.pdf"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "hcayul2011@alu.uct.cl";
                    NetworkCred.Password = "hc9078ul";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }
        Response.Write("<script language=javascript>alert('PDF Generado y enviado a Email);</script>)");
    }
}