<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master"  AutoEventWireup="true" CodeFile="Productos.aspx.cs" Inherits="index" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="all"/>
<link rel="stylesheet" href="css/layout.css" type="text/css" media="all"/>
<link rel="stylesheet" href="css/style.css" type="text/css" media="all"/>
    <div id="Div_TablaProducto" runat="server">
        <h2 class="top">Buscar Productos</h2>
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
                    <asp:Button ID="btn_buscar" runat="server" Text="Buscar productos" OnClick="btn_buscar_Click" CssClass="button1" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Por:</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ColBuscada" runat="server" Height="17px" Width="185px">
                        <asp:ListItem Value="nombre_prod">Nombre</asp:ListItem>
                        <asp:ListItem Value="descripcion_prod">Detalle</asp:ListItem>
                        <asp:ListItem Value="stock_prod">Stock</asp:ListItem>
                        <asp:ListItem Value="precioventa_prod">Precio Venta</asp:ListItem>
                        <asp:ListItem Value="preciocompra_prod">Precio Compra</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <asp:GridView ID="Tabla_prod" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server" OnRowDataBound="OnRowDataBound"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Justify" SelectedIndex="0" Width="60%" AllowPaging="True" OnPageIndexChanging="Tabla_Producto_PageIndexChanging" CellSpacing="15">

            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" ForeColor="White" Font-Bold="True"></HeaderStyle>
            <PagerSettings FirstPageImageUrl="~/img/home.png" LastPageImageUrl="~/img/steps.png" NextPageImageUrl="~/img/der.png" FirstPageText=" " LastPageText=" " Mode="NextPreviousFirstLast" PreviousPageImageUrl="~/img/izq.png" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

        <br />
        <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo Producto" OnClick="btn_nuevo_Click" CssClass="button1" />
        <asp:Button ID="btn_editar" runat="server" Text="Editar Producto" OnClick="btn_editar_Click" CausesValidation="False" CssClass="button1" />
        <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar Producto" OnClick="btn_eliminar_Click" CssClass="button1" />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div id="Div_nuevoProd" runat="server">
            <br />
    <h2 class="top">Nuevo Producto</h2>
    <br />
    <fieldset style="width: 50%">
        <table style="width: 113%;">
            <tr>
                <td>Categoria</td>
                <td>
                    <asp:DropDownList ID="txt_categoria" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre_cate" DataValueField="nombre_cate">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCARRITO %>" SelectCommand="SELECT [nombre_cate] FROM [categorias]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>nombre Producto</td>
                <td>
                    <asp:TextBox ID="txt_nombreProd" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingresar Nombre Producto" ControlToValidate="txt_nombreProd"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Unidad </td>
                <td>
                    <asp:DropDownList ID="DrList_unidad" runat="server">
                        <asp:ListItem>KG</asp:ListItem>
                        <asp:ListItem>UD</asp:ListItem>
                        <asp:ListItem>PQ</asp:ListItem>
                        <asp:ListItem>LT</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Stock</td>
                <td>
                    <asp:TextBox ID="txt_stock" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingresar Stock" ControlToValidate="txt_stock"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Precio Venta</td>
                <td>
                    <asp:TextBox ID="txt_precioV" runat="server" TextMode="Number" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingresar Precio Venta" ControlToValidate="txt_precioV"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Precio Compra</td>
                <td>
                    <asp:TextBox ID="txt_precioC" runat="server" TextMode="Number"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingresar Precio Compra" ControlToValidate="txt_precioC"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Imagen Producto</td>
                <td>
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                        <ContentTemplate>--%>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                    <%--<asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Cargar Imagen" />
                            <br />
                            <asp:Image ID="NormalImage" runat="server" Height="190px" Width="300px" ImageUrl="~/img/vacio.jpg" />--%><%--</ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="Upload" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td>Descripcion </td>
                <td>
                    <asp:TextBox ID="txt_desc" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingresar Precio Compra" ControlToValidate="txt_desc"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_cancelSaveProd" runat="server" Text="Cancelar" OnClick="btn_cancelSaveProd_Click" CausesValidation="False" CssClass="button1"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_guardarProd" runat="server" Text="Guardar" OnClick="btn_guardarProd_Click" CssClass="button1" />
                </td>
            </tr>
        </table>

    </fieldset>

        </div>
    <div id="Div_editarProducto" runat="server">
            <br />
    <h2 class="top">Editar Productos</h2>
    <br />
    <fieldset style="width: 50%">
        <table style="width: 113%;">
            <tr>
                <td>Categoria</td>
                <td>
                    <asp:DropDownList ID="DropList_cat" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre_cate" DataValueField="nombre_cate">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCARRITO %>" SelectCommand="SELECT [nombre_cate] FROM [categorias]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>nombre Producto</td>
                <td>
                    <asp:TextBox ID="txt_nombreProdEditar" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingresar Nombre Producto" ControlToValidate="txt_nombreProd"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Unidad </td>
                <td>
                    <asp:DropDownList ID="DropList_txt_nombreUnidadEditar" runat="server">
                        <asp:ListItem>KG</asp:ListItem>
                        <asp:ListItem>UD</asp:ListItem>
                        <asp:ListItem>PQ</asp:ListItem>
                        <asp:ListItem>LT</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Stock</td>
                <td>
                    <asp:TextBox ID="txt_StockEditar" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingresar Stock" ControlToValidate="txt_stock"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Precio Venta</td>
                <td>
                    <asp:TextBox ID="txt_PrecioVentaEditar" runat="server" TextMode="Number" Height="22px" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingresar Precio Venta" ControlToValidate="txt_precioV"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Precio Compra</td>
                <td>
                    <asp:TextBox ID="txt_PrecioCompraEditar" runat="server" TextMode="Number"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingresar Precio Compra" ControlToValidate="txt_precioC"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Imagen Producto</td>
                <td>
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                        <ContentTemplate>--%>
                            <asp:FileUpload ID="FileUpload2_ImagenEditar" runat="server" />
                    <%--<asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Cargar Imagen" />
                            <br />
                            <asp:Image ID="NormalImage" runat="server" Height="190px" Width="300px" ImageUrl="~/img/vacio.jpg" />--%><%--</ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="Upload" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td rowspan="2">
                    <asp:Image ID="img_producto" runat="server" Height="137px" Width="338px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Descripcion </td>
                <td>
                    <asp:TextBox ID="txt_descripcionEditar" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Ingresar Precio Compra" ControlToValidate="txt_desc"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_cancelEditar" runat="server" Text="Cancelar" OnClick="btn_cancelSaveProd_Click" CausesValidation="False" CssClass="button1"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click" style="margin-bottom: 0px" Text="Actualizar" CssClass="button1" />
                </td>
            </tr>
        </table>

    </fieldset>
        <br />
        </div>
    <br />
</asp:Content>