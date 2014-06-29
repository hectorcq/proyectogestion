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

            FacadeCliente Fcliente=new FacadeCliente();
            DataSet dsetCliente = Fcliente.buscarClienteAll();
            tablaCliente.DataSource = dsetCliente;
            tablaCliente.DataBind();                              // Carga los datos en la grid   

            Div_nuevoProd.Visible = false;
            Div_editarProducto.Visible = false;
            Div_TablaProducto.Visible = false;
            Div_TablaCliente.Visible = false;
            Div_NuevoCliente.Visible = false;
            Div_editarCliente.Visible = false;



            //Obtiene de productos seleccionado predeterminado
            int idProd = Convert.ToInt32(Tabla_prod.SelectedRow.Cells[0].Text);
            Producto producto = new Producto();
            producto = FC.getProductoALLClass(idProd);
            
            Categoria getCategoria = new Categoria();
            FacadeCategoria cat = new FacadeCategoria();
            
            getCategoria = cat.getCategoriaById(producto.codCategoria());
            
            Label_cat.Text = getCategoria.getNombre(); 
            Label_Desc.Text =getCategoria.getDesc();
            Label_unidad.Text = producto.unidad();
            Img_Detalles.ImageUrl = "MostrarImage.aspx?ImageID=" + idProd;


            /**ClIENTE**/



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
    protected void OnRowDataBound1(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
         
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaCliente, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                     
            }

           
        
    }
    

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
         
            //Al SELECCIONAR FILA DE TABLA SE RECARGAR DATOS PARA DETALLES
            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            //Obtiene de productos seleccionado predeterminado
            int idProd = Convert.ToInt32(Tabla_prod.SelectedRow.Cells[0].Text);
            Producto producto = new Producto();
            FacadeProducto FC = new FacadeProducto();
            producto = FC.getProductoALLClass(idProd);

            Categoria getCategoria = new Categoria();
            FacadeCategoria cat = new FacadeCategoria();

            getCategoria = cat.getCategoriaById(producto.codCategoria());

            Label_cat.Text = getCategoria.getNombre();
            Label_Desc.Text = getCategoria.getDesc();
            Label_unidad.Text = producto.unidad();
            Img_Detalles.ImageUrl = "MostrarImage.aspx?ImageID=" + idProd;
        
    }
    //PAGINACION TABLA Producto
    protected void Tabla_prod_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Tabla_prod.PageIndex = e.NewPageIndex;
        RecargarTaba();
    }  

    

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        Div_TablaProducto.Visible = false;
        Div_nuevoProd.Visible = true;




    }
    protected void btn_editar_Click(object sender, EventArgs e)
    {

        Div_TablaProducto.Visible = false;
        Div_editarProducto.Visible = true;
        //LLENA LOS CAMPOS DE FORMULARIO EDITAR 
        int idProd = Convert.ToInt32(Tabla_prod.SelectedRow.Cells[0].Text);
        int I = Tabla_prod.SelectedRow.RowIndex;
        Div_nuevoProd.Visible = false;
        Div_TablaProducto.Visible= false;
        Div_editarProducto.Visible = true;

        txt_nombreProdEditar.Text = Tabla_prod.SelectedRow.Cells[1].Text;
        txt_StockEditar.Text = Tabla_prod.SelectedRow.Cells[3].Text;
        string pV=Tabla_prod.SelectedRow.Cells[4].Text;
        txt_PrecioVentaEditar.Text ="1500";
        string pC = Convert.ToString(Tabla_prod.SelectedRow.Cells[5].Text); ;
        txt_PrecioCompraEditar.Text = "1000";
        txt_descripcionEditar.Text = Tabla_prod.SelectedRow.Cells[2].Text;

     

        img_producto.ImageUrl = "MostrarImage.aspx?ImageID="+idProd;

        
    }
    
    protected void btn_actualizar_Click(object sender, EventArgs e){
       // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" +img.ToString() + "');", true);
        //TOMA EL ID DEL PRODUCTO SELECCIONADO EN TABLA PARA ACTUALIZAR REGISTRO
        int idProd = Convert.ToInt32(Tabla_prod.SelectedRow.Cells[0].Text);
        string cat = DropList_cat.Text;
        string nombre = txt_nombreProdEditar.Text;
        string unidad = DropList_txt_nombreUnidadEditar.Text;
        int stock = Convert.ToInt32(txt_StockEditar.Text);
        int precioV = Convert.ToInt32(txt_PrecioVentaEditar.Text);
        int precioC = Convert.ToInt32(txt_PrecioCompraEditar.Text);
        string desc = txt_descripcionEditar.Text;

        FacadeProducto newProducto = new FacadeProducto();

        string imagen = FileUpload2_ImagenEditar.FileName;
        string Extension = Path.GetExtension(imagen);

        //GUARDAR PRODUCTO CON O SIN IMAGEN ASOCIADA
        if (FileUpload2_ImagenEditar.PostedFile.FileName != "")
        {
            if (ValidarExtension(Extension))
            {
                //Response.Write("<script language=javascript>alert('Guaardando...');</script>)");
                FacadeCategoria idCat = new FacadeCategoria();
                int idCategoria = idCat.obtenerIDcategoria(cat);

                byte[] imageSize = new byte
                 [FileUpload2_ImagenEditar.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = FileUpload2_ImagenEditar.PostedFile;
                uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload2_ImagenEditar.PostedFile.ContentLength);
                newProducto.ActualiarProducto(idProd, idCategoria, nombre, desc, unidad, stock, precioV, precioC, imageSize);
                Response.Write("<script language=javascript>alert('Producto Actualizado.');</script>)");
                LimpiarRegEditarProducto();

            }
            else
            {

                Response.Write("<script language=javascript>alert('Formato Incorrecto ');</script>)");

            }

        }
        else
        {

            //SI AL EDITAR NO SE SELECCIONA OTRA IMAGEN SE QUEDA CON LA MISMA
            FacadeCategoria idCat = new FacadeCategoria();
            FacadeProducto fp=new FacadeProducto();
            //Obtiene el id de categoria por nombre 
            int idCategoria = idCat.obtenerIDcategoria(cat);
           

            byte[] imageSize = fp.getImagenProducto(idProd);
            HttpPostedFile uploadedImage = FileUpload2_ImagenEditar.PostedFile;
            uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload2_ImagenEditar.PostedFile.ContentLength);

            newProducto.ActualiarProducto(idProd, idCategoria, nombre, desc, unidad, stock, precioV, precioC, imageSize);
            Response.Write("<script language=javascript>alert('Producto Actualizado.');</script>)");
            LimpiarRegEditarProducto();


        }
        RecargarTaba();
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = true;

    }
    protected void btn_eliminar_Click(object sender, EventArgs e)
    {
        int idProd = Convert.ToInt32(Tabla_prod.SelectedRow.Cells[0].Text);
        FacadeProducto fp = new FacadeProducto();
        //OBTIENE IDPRODUCTO DE TABLA PARA ELIMINAR
        string nombreProd = Tabla_prod.SelectedRow.Cells[1].Text;
        //Response.Write("<script language=javascript>alert('Producto Eliminado:'" + nombreProd + ");</script>)");
        fp.EliminarProducto(idProd);
        RecargarTaba();

    }

    protected void btn_cancelSaveProd_Click(object sender, EventArgs e)
    {
        Div_TablaProducto.Visible = true;
        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
    }
   
    protected void btn_guardarProd_Click(object sender, EventArgs e)
    {

        string cat = txt_categoria.Text;
        string nombre = txt_nombreProd.Text;
        string unidad = DrList_unidad.Text;
        int stock = Convert.ToInt32(txt_stock.Text);
        int precioV = Convert.ToInt32(txt_precioV.Text);
        int  precioC = Convert.ToInt32(txt_precioC.Text);
        string desc=txt_desc.Text;

        
        FacadeProducto newProducto = new FacadeProducto();

        string imagen = FileUpload1.FileName;
        string Extension = Path.GetExtension(imagen);
        
        //GUARDAR PRODUCTO CON O SIN IMAGEN ASOCIADA
        if (FileUpload1.PostedFile.FileName != "")
        {
            if (ValidarExtension(Extension))
            {
                //Response.Write("<script language=javascript>alert('Guaardando...');</script>)");
                FacadeCategoria idCat=new FacadeCategoria();
                int idCategoria = idCat.obtenerIDcategoria(cat);

                byte[] imageSize = new byte
                 [FileUpload1.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = FileUpload1.PostedFile;
                uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

                newProducto.IngresarProducto(idCategoria, nombre, desc, unidad, stock, precioV, precioC, imageSize);
                Response.Write("<script language=javascript>alert('Producto Guardado');</script>)");
                LimpiarRegNuevoProducto();
                
            }
            else
            {

                Response.Write("<script language=javascript>alert('Formato Incorrecto ');</script>)");

            }
           
        }
        else
        {

            FacadeCategoria idCat = new FacadeCategoria();
            int idCategoria = idCat.obtenerIDcategoria(cat);
            string imagepath = "/img/vacio.jpg";

            byte[] imageSize = new byte[imagepath.Length];
            HttpPostedFile uploadedImage = FileUpload1.PostedFile;
            uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

            newProducto.IngresarProducto(idCategoria, nombre, desc, unidad, stock, precioV, precioC, imageSize);
            Response.Write("<script language=javascript>alert('Producto Guardado');</script>)");
            LimpiarRegNuevoProducto();
        
        
        }
        Div_nuevoProd.Visible = false;
        RecargarTaba();
        Div_TablaProducto.Visible = true;
        
        



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
    private void RecargarTaba() {

        FacadeProducto FC = new FacadeProducto();
        DataSet dset = FC.buscarProductoALL();
        Tabla_prod.DataSource = dset;
        Tabla_prod.DataBind();    
    }
    private void LimpiarRegNuevoProducto() {

        txt_nombreProd.Text="";
        txt_stock.Text = "";
        txt_precioV.Text = "";
        txt_precioC.Text = "";
        txt_desc.Text = "";

    }

    private void LimpiarRegEditarProducto()
    {
        txt_nombreProdEditar.Text = "";
        txt_StockEditar.Text = "";
        txt_PrecioVentaEditar.Text = "";
        txt_PrecioCompraEditar.Text = "";
        txt_descripcionEditar.Text = "";

    }




    protected void btn_GesProducto_Click(object sender, EventArgs e)
    {
        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = true;
        Div_TablaCliente.Visible = false;
        Div_NuevoCliente.Visible = false;
        Div_editarCliente.Visible = false;
    }
    protected void btn_GesCliente_Click(object sender, EventArgs e)
    {
        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = false;
        Div_TablaCliente.Visible =true;
        Div_NuevoCliente.Visible = false;
        Div_editarCliente.Visible = false;
    }
    protected void btn_BuscaCliente_Click(object sender, EventArgs e)
    {

        string columna = DropList_columnaCliente.SelectedValue;
        
        //SELECCIONA LA FORMA DE FILLTRAR DE ACUERDO A LAS COLUMNAS
        string buscarX = "";
        if (columna == "rut")
        {
            buscarX = "buscar_ClienteXRut";

        }
        else if (columna == "nombre")
        {
            buscarX = "buscar_ClienteXNombre";

        }

        else if (columna == "direcion")
        {
            buscarX = "buscar_ClienteXDireccion";

        }

        else if (columna == "fono")
        {
            buscarX = "buscar_ClienteXFono";

        }

        else if (columna == "email")
        {
            buscarX = "buscar_ClienteXEmail";

        }
        else if (columna == "estado")
        {
            buscarX = "buscar_ClienteXEstado";
        }
        FacadeCliente FC = new FacadeCliente();
        
        //SI Se PRESIONA BOTON BUSCAR SIN TEXTO SE LLENA TABLA 

        //if (txt_texto.Text == "")
        if (txt_BuscaCliente.Text=="")
        {
            RecargarTablaCliente();

        }
        else
        {
            //Response.Write("<script language=javascript>alert('Buscar Cliente por:"+buscarX+"');</script>)");

            DataSet dset = FC.buscarClienteX(txt_BuscaCliente.Text, buscarX);
            tablaCliente.DataSource = dset;
            tablaCliente.DataBind();                              // Carga los datos en la grid   

            //SI NO SE ENCUENTRAN PRODUCTOS SE MUESTRA TABLA VACIA
            if (dset.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Rut"), new DataColumn("Nombre"), new DataColumn("Direccion"), new DataColumn("Fono"), new DataColumn("Email"), new DataColumn("Estado") });
                dt.Rows.Add(1, "NO SE ", "ENCONTRARON CLIENTES ", "", "", "");
                tablaCliente.DataSource = dt;
                tablaCliente.DataBind();

            }
        }

    }
    public void RecargarTablaCliente() {
        FacadeCliente fc = new FacadeCliente();

        DataSet dset = fc.buscarClienteAll();
        tablaCliente.DataSource = dset;
        tablaCliente.DataBind(); 
    
    
    }

    protected void btx_RegistrarCliente_Click(object sender, EventArgs e)
    {
        FacadeCliente fc = new FacadeCliente();
        int g=fc.IngresarCliente(txt_RutCliente.Text,txt_contraseCiente.Text, Drop_nombreCiudad.SelectedValue, txt_nombreCliente.Text, txt_direccionCliente.Text, txt_FonoCliente.Text, txt_emailCliente.Text, drop_estadoCliente.SelectedValue);
        if(g==1){
            Response.Write("<script language=javascript>alert('Cliente Guardado');</script>)");
            RecargarTablaCliente();
            Div_nuevoProd.Visible = false;
            Div_editarProducto.Visible = false;
            Div_TablaProducto.Visible = false;
            Div_TablaCliente.Visible = true;
            Div_NuevoCliente.Visible = false;
            Div_editarCliente.Visible = false;
        }else{
            Response.Write("<script language=javascript>alert('El Rut esta ingresado');</script>)");
        }
        
        LimpiarRegistroCliente();

    }
    public bool validarRut(string rut)
    {

        bool validacion = false;
        try
        {
            rut = rut.ToUpper();
           // rut = rut.Replace(".", "");
            //rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                validacion = true;
            }
        }
        catch (Exception)
        {
        }
        return validacion;
    }
    public void LimpiarRegistroCliente() {

        txt_RutCliente.Text="";
        txt_nombreCliente.Text="";
        txt_direccionCliente.Text="";
        txt_FonoCliente.Text="";
        txt_emailCliente.Text="";
     
    }
    //VA A FORMULARIO EDITAR DATO
    protected void btn_editaCliente_Click(object sender, EventArgs e)
    {
        Div_TablaCliente.Visible = false;
        Div_editarCliente.Visible = true;
        Div_NuevoCliente.Visible = false;
        Div_nuevoProd.Visible = false;
        Div_TablaProducto.Visible = false;

        //LLENA LOS CAMPOS DE FORMULARIO EDITAR 
        string rut = tablaCliente.SelectedRow.Cells[0].Text;
        txt_rutClienteEditar.Enabled = false;
        txt_rutClienteEditar.Text = rut;
        FacadeCliente contrasena=new FacadeCliente();
        txt_contrasenaClienteEditar.Attributes.Add("Value", contrasena.getContrasenaCliente(rut));
        txt_nombreClienteEditar.Text = tablaCliente.SelectedRow.Cells[1].Text;
        txt_dirClienteEditar.Text = tablaCliente.SelectedRow.Cells[2].Text;
        txt_fonoClienteEditar.Text = tablaCliente.SelectedRow.Cells[3].Text;
        txt_emailClienteEditar.Text = tablaCliente.SelectedRow.Cells[4].Text;
        


    }

    //ACTUALIZAR REGISTRO DE CLIENTE 
    protected void btn_actualizarCliente_Click(object sender, EventArgs e)
    {
        string rutCliente = tablaCliente.SelectedRow.Cells[0].Text;
        string ciudad = droplist_ciudadClienteEditar.SelectedValue;
        string nombre = txt_nombreClienteEditar.Text;
        string dir = txt_dirClienteEditar.Text;
        string email = txt_emailClienteEditar.Text;
        string fono = txt_fonoClienteEditar.Text;
        string estado = dropList_estadoClienteEditar.SelectedValue;
        string contrasena = txt_contrasenaClienteEditar.Text;
        
        FacadeCliente FC = new FacadeCliente();
        FC.ActualizarCliente(rutCliente, contrasena,ciudad, nombre, dir, fono, email, estado);

        Response.Write("<script language=javascript>alert('Cliente Actualizado');</script>)");
        RecargarTablaCliente();

        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = false;
        Div_TablaCliente.Visible = true;
        Div_NuevoCliente.Visible = false;
        Div_editarCliente.Visible = false;



    }

    protected void btn_EliminarCliente_Click(object sender, EventArgs e)
    {
        string rut = tablaCliente.SelectedRow.Cells[0].Text;
        FacadeCliente FC = new FacadeCliente();
        FC.EliminarCliente(rut);
        Response.Write("<script language=javascript>alert('Cliente Eliminado');</script>)");
        RecargarTablaCliente();
        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = false;
        Div_TablaCliente.Visible = true;
        Div_NuevoCliente.Visible = false;
        Div_editarCliente.Visible = false;
    }
    protected void btn_NuevoCliente_Click(object sender, EventArgs e)
    {
        Div_nuevoProd.Visible = false;
        Div_editarProducto.Visible = false;
        Div_TablaProducto.Visible = false;
        Div_TablaCliente.Visible = false;
        Div_NuevoCliente.Visible = true;
        Div_editarCliente.Visible = false;

    }
    //PAGINACION TABLA Producto
    protected void Tabla_Cliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        tablaCliente.PageIndex = e.NewPageIndex;
        RecargarTablaCliente();
    }
    protected void txt_RutCliente_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {

        bool validacion = false;
        try
        {
            string rut=args.Value;
            rut = rut.ToUpper();
           // rut = rut.Replace(".", "");
            //rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                validacion = true;
            }
        }
        catch (Exception)
        {
        }
        args.IsValid = validacion;
    }
}
