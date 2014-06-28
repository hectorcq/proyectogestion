using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

using System.Web.Security;

using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            FacadeProducto FC = new FacadeProducto();
            DataSet dset = FC.buscarProductoALL();
            Tabla_prod.DataSource = dset;
            Tabla_prod.DataBind();                              // Carga los datos en la grid   


            Div_nuevoProd.Visible = false;
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
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('vacio');", true);
            FacadeProducto pf = new FacadeProducto();
            DataSet dset = pf.buscarProductoALL();
            Tabla_prod.DataSource = dset;
            Tabla_prod.DataBind();

        }
        else
        {

            DataSet dset = FC.buscarProductoX(txt_texto.Text, buscarX); // Asigna el origen de los datos
            Tabla_prod.DataSource = dset;
            Tabla_prod.DataBind();                              // Carga los datos en la grid   

            //SI NO SE ENCUENTRAN PRODUCTOS SE MUESTRA TABLA VACIA
            if (dset.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("ID"), new DataColumn("Nombre"), new DataColumn("Detalles"), new DataColumn("Stock"), new DataColumn("Precio Venta"), new DataColumn("Precio Compra") });
                dt.Rows.Add(1, "NO SE ", "ENCONTRARON PRODUCTOS ", "", "", "");
                Tabla_prod.DataSource = dt;
                Tabla_prod.DataBind();

            }
        }


    }

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Tabla_prod, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Tabla_prod.SelectedRow.RowIndex;
        string name = Tabla_prod.SelectedRow.Cells[0].Text;
        string country = Tabla_prod.SelectedRow.Cells[1].Text;
        string message = "Row Index: " + index + "\\nName: " + name + "\\nCountry: " + country;
        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
    }

    //protected void btn_buscar_Click(object sender, EventArgs e)
    //{
    //    FacadeProducto FC = new FacadeProducto();
    //    DataSet dset = FC.buscarProducto(txt_texto.Text); // Asigna el origen de los datos
    //    GridView2.DataSource = dset;
    //    GridView2.DataBind();                              // Carga los datos en la grid   


    //    //GridView1.Columns[0].


    //    //int id= FC.getID()+1;
    //    //txt_texto.Text =id.ToString();


    //        //Response.Wri  te("<script language=javascript>alert('" + FC.buscarProducto(txt_texto.Text).Count() + "');</script>)");
    //    if (dset.Tables[0].Rows.Count != 0)
    //    {
    //       Response.Write("<h1>" + dset.Tables[0].Rows[0][0].ToString() + "</h1>)");



    //      // GridView1.Rows[1].Cells["Column1"].Value = "new value";

    //    }
    //    //FC.IngresarProducto(1, "otronuevo", "descripcion", 1, 23, 21, 2323, "");

    //}

    //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
    //        e.Row.Attributes["style"] = "cursor:pointer";
    //    }
    //}

    //protected void OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int index = GridView2.SelectedRow.RowIndex;
    //    string name = GridView2.SelectedRow.Cells[0].Text;
    //    string country = GridView2.SelectedRow.Cells[1].Text;
    //    string message = "Row Index: " + index + "\\nName: " + name + "\\nCountry: " + country;
    //    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
    //    Response.Write("<script language=javascript>alert('" +message + "');</script>)");
    //}

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        Div_TablaProducto.Visible = false;
        Div_nuevoProd.Visible = true;


    }
    protected void btn_editar_Click(object sender, EventArgs e)
    {

    }
    protected void btn_eliminar_Click(object sender, EventArgs e)
    {

    }

    protected void btn_cancelSaveProd_Click(object sender, EventArgs e)
    {
        Div_TablaProducto.Visible = true;
        Div_nuevoProd.Visible = false;
    }
    protected void btn_guardarProd_Click(object sender, EventArgs e)
    {

        string cat = txt_categoria.Text;
        string nombre = txt_nombreProd.Text;
        string unidad = DrList_unidad.Text;
        int stock = Convert.ToInt32(txt_stock.Text);
        int precioV = Convert.ToInt32(txt_precioC.Text);
        int  precioC = Convert.ToInt32(txt_precioC.Text);
        string desc=txt_desc.Text;

        
        FacadeProducto newProducto = new FacadeProducto();

        string imagen = FileUpload1.FileName;
        string Extension = Path.GetExtension(imagen);
        if (FileUpload1.PostedFile.FileName != "")
        {
            if (ValidarExtension(Extension))
            {
                //Response.Write("<script language=javascript>alert('Guaardando...');</script>)");
                FacadeCategoria idCat=new FacadeCategoria();
                int idCategoria = idCat.obtenerIDcategoria(cat);
                newProducto.IngresarProducto(idCategoria,nombre,desc,unidad,stock,precioV,precioC,FileUpload1.FileBytes
                Response.Write("<script language=javascript>alert('"+cat+"-id:"+idCategoria+"');</script>)");

            }
            else
            {

                Response.Write("<script language=javascript>alert('Formato Incorrecto ');</script>)");

            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('Sin imagen.... guardando..... ');</script>)");
            
        
        
        }



    }
    private Boolean ValidarExtension(string sExtension)
    {
        Boolean verif = false;
        switch (sExtension)
        {
            case ".jpg":
            case ".jpeg":
            case ".png":
            case ".gif":
            case ".bmp":
                verif = true;
                break;
            default:
                verif = false;
                break;
        }
        return verif;
    }
    //protected void Upload_Click(object sender, EventArgs e)
    //{
    //    if (this.IsPostBack)
    //    {

    //            FileUpload1.SaveAs(MapPath("~/img/" + FileUpload1.FileName));
    //            System.Drawing.Image img1 = System.Drawing.Image.FromFile(MapPath("~/img/") + FileUpload1.FileName);
    //            NormalImage.ImageUrl = "~/img/" + FileUpload1.FileName;


    //    }
    //}

}