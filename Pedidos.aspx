<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageUser.master"  AutoEventWireup="true" CodeFile="Pedidos.aspx.cs" Inherits="index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Pedidos</h3>
    <script type = "text/javascript">
<!--
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    inputList[i].checked = true;
                }
                else {
                    if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
    //-->
</script>



    <br />
    &nbsp;
    <div id="div_CrearPedido" runat="server">
    <table border="0">
        <tr>
            <td>Producto</td>
            <td>
                <asp:TextBox ID="txt_texto" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_buscar" runat="server" Text="Buscar productos" OnClick="btn_buscar_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Por:</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ColBuscada" runat="server">
                    <asp:ListItem Value="nombre_prod">Nombre</asp:ListItem>
                    <asp:ListItem Value="descripcion_prod">Detalle</asp:ListItem>
                    <asp:ListItem Value="stock_prod">Stock</asp:ListItem>
                    <asp:ListItem Value="precioventa_prod">Precio Venta</asp:ListItem>
                    <asp:ListItem Value="preciocompra_prod">Precio Compra</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
    </table>
    <div>
        

        <asp:GridView ID="gvAll" runat="server"
            AutoGenerateColumns="false" Font-Names="Arial"
            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
            HeaderStyle-BackColor="green" AllowPaging="true"
            OnPageIndexChanging="OnPaging" PageSize="10" Width="60%">
             <PagerSettings FirstPageImageUrl="~/img/home.png" LastPageImageUrl="~/img/steps.png" NextPageImageUrl="~/img/der.png" FirstPageText=" " LastPageText=" " Mode="NextPreviousFirstLast" PreviousPageImageUrl="~/img/izq.png" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                            AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                            AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText=" ID"
                    HtmlEncode="false" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"
                    HtmlEncode="false" />
                
                <asp:BoundField DataField="Stock" HeaderText="Stock"
                    HtmlEncode="false" />
                <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta"
                    HtmlEncode="false" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra"
                    HtmlEncode="false" />
            </Columns>
            <AlternatingRowStyle BackColor="#C2D69B" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Carrito de Pedido" Font-Size="20"></asp:Label>

        <br />
        <br />
        <br />
        <asp:GridView ID="gvSelected" runat="server"
            AutoGenerateColumns="false" Font-Names="Arial"
            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
            HeaderStyle-BackColor="green" EmptyDataText="No se ha elegido productos " Width="60%">
              
            <Columns>
                <asp:BoundField DataField="ID" HeaderText=" ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" value="PENDIENTE"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
    </div>

    <asp:Button ID="btn_crearPedido" runat="server" Height="31px" OnClick="btn_crearPedido_Click" Text="Ingresar Pedido" Width="110px" />

    </div>
    <div id="div_detallePedido" runat="server">

        <asp:GridView ID="gridDetalles" runat="server"
            AutoGenerateColumns="false" Font-Names="Arial"
            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
            HeaderStyle-BackColor="green" EmptyDataText="No se ha elegido productos " Width="60%">
              
            <Columns>
                <asp:BoundField DataField="ID" HeaderText=" ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                
            </Columns>
        </asp:GridView>

        <br />
        <br />
        <asp:Button ID="btn_AtrasPedido" runat="server" Text="Atras" OnClick="btn_AtrasPedido_Click" />
        <asp:Button ID="btn_generarPDF" runat="server" Text="Generar PDF pedido" OnClick="btn_generarPDF_Click" />
    </div>
</asp:Content>

