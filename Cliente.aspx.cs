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

public partial class Cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
                                     // Carga los datos en la grid   

            FacadeCliente Fcliente = new FacadeCliente();
            DataSet dsetCliente = Fcliente.buscarClienteAll();
            tablaCliente.DataSource = dsetCliente;
            tablaCliente.DataBind();                              // Carga los datos en la grid   

            Div_TablaCliente.Visible = false;
            Div_NuevoCliente.Visible = false;
            Div_editarCliente.Visible = false;



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
        if (txt_BuscaCliente.Text == "")
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
    public void RecargarTablaCliente()
    {
        FacadeCliente fc = new FacadeCliente();

        DataSet dset = fc.buscarClienteAll();
        tablaCliente.DataSource = dset;
        tablaCliente.DataBind();


    }

    protected void btx_RegistrarCliente_Click(object sender, EventArgs e)
    {
        FacadeCliente fc = new FacadeCliente();
        int g = fc.IngresarCliente(txt_RutCliente.Text, txt_contraseCiente.Text, Drop_nombreCiudad.SelectedValue, txt_nombreCliente.Text, txt_direccionCliente.Text, txt_FonoCliente.Text, txt_emailCliente.Text, drop_estadoCliente.SelectedValue);
        if (g == 1)
        {
            Response.Write("<script language=javascript>alert('Cliente Guardado');</script>)");
            RecargarTablaCliente();
            Div_TablaCliente.Visible = true;
            Div_NuevoCliente.Visible = false;
            Div_editarCliente.Visible = false;
        }
        else
        {
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
    public void LimpiarRegistroCliente()
    {

        txt_RutCliente.Text = "";
        txt_nombreCliente.Text = "";
        txt_direccionCliente.Text = "";
        txt_FonoCliente.Text = "";
        txt_emailCliente.Text = "";

    }
    //VA A FORMULARIO EDITAR DATO
    protected void btn_editaCliente_Click(object sender, EventArgs e)
    {
        Div_TablaCliente.Visible = false;
        Div_editarCliente.Visible = true;
        Div_NuevoCliente.Visible = false;

        //LLENA LOS CAMPOS DE FORMULARIO EDITAR 
        string rut = tablaCliente.SelectedRow.Cells[0].Text;
        txt_rutClienteEditar.Enabled = false;
        txt_rutClienteEditar.Text = rut;
        FacadeCliente contrasena = new FacadeCliente();
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
        FC.ActualizarCliente(rutCliente, contrasena, ciudad, nombre, dir, fono, email, estado);

        Response.Write("<script language=javascript>alert('Cliente Actualizado');</script>)");
        RecargarTablaCliente();

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
        Div_TablaCliente.Visible = true;
        Div_NuevoCliente.Visible = false;
        Div_editarCliente.Visible = false;
    }
    protected void btn_NuevoCliente_Click(object sender, EventArgs e)
    {
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
            string rut = args.Value;
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