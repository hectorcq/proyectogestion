<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Cliente.aspx.cs" Inherits="Cliente" EnableEventValidation="false" %>

<%@ Register Assembly="Tde.Controles.RutTextBox" Namespace="Tde.Controles" TagPrefix="tde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
        <div id="Div_TablaCliente" runat="server">
               <h2 class="top">Gestionar Clientes</h2>
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
                    <asp:Button ID="btn_BuscaCliente" runat="server" Text="Buscar Clientes" OnClick="btn_BuscaCliente_Click" CausesValidation="False" CssClass="button1" />
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
            runat="server" OnRowDataBound="OnRowDataBound1"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Justify" SelectedIndex="0" Width="60%" AllowPaging="True" OnPageIndexChanging="Tabla_Cliente_PageIndexChanging" CellSpacing="15">

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
        <asp:Button ID="btn_NuevoCliente" runat="server" Text="Nuevo Cliente" OnClick="btn_NuevoCliente_Click" CssClass="button1" />
        <asp:Button ID="btn_editaCliente" runat="server" Text="Editar Cliente"  CausesValidation="False" OnClick="btn_editaCliente_Click" CssClass="button1" />
        <asp:Button ID="btn_EliminarCliente" runat="server" Text="Eliminar Cliente" OnClick="btn_EliminarCliente_Click" CssClass="button1"  />


            </div>

    <div id="Div_NuevoCliente" runat="server">
      <fieldset style="width: 50%">
        <br />
          <h2 class="top">Registrar Cliente</h2>
        <br />
        <table style="width:100%;">
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
                    &nbsp;<asp:Button ID="btn_cancelRegCliente" runat="server" Text="Cancelar" CausesValidation="False" CssClass="button1"/>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btx_RegistrarCliente" runat="server" Text="Registrar" OnClick="btx_RegistrarCliente_Click" style="height: 26px" CssClass="button1" />
                </td>
            </tr>
        </table>
          </fieldset>
    </div>
    <div id="Div_editarCliente" runat="server">
        <fieldset style="width: 50%">
        <br />
          <h2 class="top">Editar Cliente</h2>
        <br />
        <table style="width:100%;">
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
                    &nbsp;<asp:Button ID="btn_cancelarEditar" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btn_cancelarEditar_Click" CssClass="button1"/>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_actualizarCliente" runat="server" Text="Actualiar" OnClick="btn_actualizarCliente_Click" CssClass="button1"   />
                </td>
            </tr>
        </table>
          </fieldset>

        </div>

</asp:Content>

