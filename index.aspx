<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" EnableEventValidation="false" %>

<%@ Register Assembly="Tde.Controles.RutTextBox" Namespace="Tde.Controles" TagPrefix="tde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
    <table style="width: 100%;" align="center">
        <tr>
            <td align="center">
                <asp:Button ID="btn_GesProducto" runat="server" Text="Gestionar Productos" OnClick="btn_GesProducto_Click" CausesValidation="False"/></td>
            <td align="center">
                <asp:Button ID="btn_GesCliente" runat="server" Text="Gestionar Clientes" OnClick="btn_GesCliente_Click" CausesValidation="False" /></td>
         
        </tr>
                
    </table>


    <div id="Div_TablaProducto" runat="server">
        <h3>Gestionar&nbsp; productos</h3>
        <table border="0" cellpadding="2">
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
                </td>
            </tr>
        </table>

        <asp:GridView ID="Tabla_prod" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Justify" SelectedIndex="0" Width="50%" AllowPaging="True" OnPageIndexChanging="Tabla_prod_PageIndexChanging" CellSpacing="15">

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
        <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo Producto" OnClick="btn_nuevo_Click" />
        <asp:Button ID="btn_editar" runat="server" Text="Editar Producto" OnClick="btn_editar_Click" CausesValidation="False" />
        <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar Producto" OnClick="btn_eliminar_Click" />


        <br />
        <br />
        <br />
        <br />

        <div id="Detalle Producto"  >


        <table style="width: 50%;">
            <tr>
                <td rowspan="3" align="center">
                    <asp:Image ID="Img_Detalles" runat="server" Height="143px" Width="195px" />
                </td>
                <td>Categoria</td>
                <td>
                    <asp:Label ID="Label_cat" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Descripcion</td>
                <td>
                    <asp:Label ID="Label_Desc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Unidad Medida</td>
                <td>
                    <asp:Label ID="Label_unidad" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </table>


    </div>


    </div>
    



    <div id="Div_nuevoProd" runat="server">
    <fieldset style="width: 50%">
        <legend><b>Nuevo Producto</b></legend>
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
                    <asp:Button ID="btn_cancelSaveProd" runat="server" Text="Cancelar" OnClick="btn_cancelSaveProd_Click" CausesValidation="False"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_guardarProd" runat="server" Text="Guardar" OnClick="btn_guardarProd_Click" />
                </td>
            </tr>
        </table>

    </fieldset>

        </div>


    <div id="Div_editarProducto" runat="server">
    <fieldset style="width: 50%">
        <legend><b>Editar Producto</b></legend>
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
                    <asp:Button ID="btn_cancelEditar" runat="server" Text="Cancelar" OnClick="btn_cancelSaveProd_Click" CausesValidation="False"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click" style="margin-bottom: 0px" Text="Actualizar" />
                </td>
            </tr>
        </table>

    </fieldset>

        <br />
        <br />
        <br />
    </div>
        <div id="Div_TablaCliente" runat="server">
               <h3>Gestionar Clientes</h3>
        <table border="0" cellpadding="2">
            <tr>
                <td>Cliente</td>
                <td>
                    <asp:TextBox ID="txt_BuscaCliente" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btn_BuscaCliente" runat="server" Text="Buscar Clientes" OnClick="btn_BuscaCliente_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Por:</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="DropList_columnaCliente" runat="server">
                        <asp:ListItem Value="rut">Rut</asp:ListItem>
                        <asp:ListItem Value="nombre">Nombre</asp:ListItem>
                        <asp:ListItem Value="direcion">Direccion</asp:ListItem>
                        <asp:ListItem Value="fono">Fono</asp:ListItem>
                        <asp:ListItem Value="email">Email</asp:ListItem>
                        <asp:ListItem Value="estado">Estado</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <asp:GridView ID="tablaCliente" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server" OnRowDataBound="OnRowDataBound1"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Justify" SelectedIndex="0" Width="50%" AllowPaging="True" OnPageIndexChanging="Tabla_Cliente_PageIndexChanging" CellSpacing="15">

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
        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>

        <br />
        <asp:Button ID="btn_NuevoCliente" runat="server" Text="Nuevo Cliente" OnClick="btn_NuevoCliente_Click" />
        <asp:Button ID="btn_editaCliente" runat="server" Text="Editar Cliente"  CausesValidation="False" OnClick="btn_editaCliente_Click" />
        <asp:Button ID="btn_EliminarCliente" runat="server" Text="Eliminar Cliente" OnClick="btn_EliminarCliente_Click"  />


            </div>

    <div id="Div_NuevoCliente" runat="server">
      <fieldset style="width: 50%">
        <legend><b>Registrar Cliente</b></legend>
        <table style="width:50%;">
            <tr>
                <td rowspan="11">
                    <asp:Image ID="Image1" runat="server" Height="94px" ImageUrl="~/img/Registrocliente.png" Width="90px" />
                </td>
                <td>Rut</td>
                <td>
                    <tde:RutTextBox ID="txt_RutCliente" runat="server"></tde:RutTextBox>
                    
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ingresar Rut" ControlToValidate="txt_RutCliente"></asp:RequiredFieldValidator>
                   <%-- <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txt_RutCliente" runat="server" ErrorMessage="Rut incorrecto"
                        OnServerValidate="CustomValidator1_ServerValidate"
                        ></asp:CustomValidator>--%>

                </td>
            </tr>
            <tr>
                <td>Contrasena</td>
                <td>
                    <asp:TextBox ID="txt_contraseCiente" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Ingresar Contraseña" ControlToValidate="txt_contraseCiente"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                
                <td>
                   
                    Ciudad</td>
                <td>
                    <asp:DropDownList ID="Drop_nombreCiudad" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre_ciud" DataValueField="nombre_ciud">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCARRITO %>" SelectCommand="SELECT [nombre_ciud] FROM [ciudades]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txt_nombreCliente" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Ingresar Nombre " ControlToValidate="txt_nombreCliente"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Direccion</td>
                <td>
                    <asp:TextBox ID="txt_direccionCliente" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Ingresar Direccion " ControlToValidate="txt_direccionCliente"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Fono</td>
                <td>
                     
                    <asp:TextBox ID="txt_FonoCliente" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFono" runat="server" Display="Dynamic" ControlToValidate="txt_FonoCliente"
                            ErrorMessage="Ingresar Celular" ForeColor="Red" Font-Size="10pt" 
                                         Font-Names="Century Gothic" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFono" runat="server" Display="Dynamic" ControlToValidate="txt_FonoCliente"
                            ErrorMessage="Nº no valido" ValidationExpression="\d{8}" 
                            ForeColor="Red" Font-Size="10pt" Font-Names="Century Gothic"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txt_emailCliente" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Ingresar Email" ControlToValidate="txt_emailCliente"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td>Estado</td>
                <td>
                    <asp:DropDownList ID="drop_estadoCliente" runat="server">
                      <asp:ListItem Value="ACTIVO">ACTIVO</asp:ListItem>
                        <asp:ListItem Value="INACTIVO">INACTIVO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="btn_cancelRegCliente" runat="server" Text="Cancelar" CausesValidation="False"/>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btx_RegistrarCliente" runat="server" Text="Registrar" OnClick="btx_RegistrarCliente_Click" style="height: 26px" />
                </td>
            </tr>
        </table>
          </fieldset>
    </div>
    <div id="Div_editarCliente" runat="server">
        <fieldset style="width: 50%">
        <legend><b>Editar Cliente</b></legend>
        <table style="width:50%;">
            <tr>
                <td rowspan="10">
                    <asp:Image ID="Image2" runat="server" Height="94px" ImageUrl="~/img/Registrocliente.png" Width="90px" />
                </td>
                <td>Rut</td>
                <td>
                    <asp:TextBox ID="txt_rutClienteEditar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contrasena</td>
                <td>
                     
                    <asp:TextBox ID="txt_contrasenaClienteEditar" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Ingresar Contraseña" ControlToValidate="txt_contrasenaClienteEditar"></asp:RequiredFieldValidator>
                     
                </td>
            </tr>
            <tr>
                
                <td>
                   
                    Ciudad</td>
                <td>
                    <asp:DropDownList ID="droplist_ciudadClienteEditar" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre_ciud" DataValueField="nombre_ciud">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCARRITO %>" SelectCommand="SELECT [nombre_ciud] FROM [ciudades]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txt_nombreClienteEditar" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Ingresar Nombre " ControlToValidate="txt_nombreClienteEditar"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Direccion</td>
                <td>
                    <asp:TextBox ID="txt_dirClienteEditar" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Ingresar Direccion " ControlToValidate="txt_dirClienteEditar"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Fono</td>
                <td>
                    <asp:TextBox ID="txt_fonoClienteEditar" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Ingresar Fono" ControlToValidate="txt_fonoClienteEditar"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txt_emailClienteEditar" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Ingresar Email" ControlToValidate="txt_emailClienteEditar"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td>Estado</td>
                <td>
                    <asp:DropDownList ID="dropList_estadoClienteEditar" runat="server">
                      <asp:ListItem Value="ACTIVO">ACTIVO</asp:ListItem>
                        <asp:ListItem Value="INACTIVO">INACTIVO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="btn_cancelarEditar" runat="server" Text="Cancelar" CausesValidation="False"/>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_actualizarCliente" runat="server" Text="Actualiar" OnClick="btn_actualizarCliente_Click"   />
                </td>
            </tr>
        </table>
          </fieldset>

        </div>
</asp:Content>

