<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ReportesAdmin.aspx.cs" Inherits="index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 187px;
        }

        .auto-style2 {
            height: 22px;
        }

        .auto-style3 {
            width: 187px;
            height: 22px;
        }

        .auto-style4 {
            height: 13px;
        }

        .auto-style5 {
            width: 187px;
            height: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Reportes</h3>
    <div id="div_Pedidos" runat="server">
    <table border="0">
        <tr>
            <td class="auto-style2">Producto</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_texto" runat="server" Width="350px"></asp:TextBox>
            </td>
            <td class="auto-style3">Estado Pedido</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_buscar" runat="server" Text="Buscar productos" OnClick="btn_buscar_Click" />
            </td>
            <td class="auto-style1">
                <asp:RadioButtonList ID="rbtLstRating" runat="server"
                    RepeatDirection="Horizontal" RepeatLayout="Table" OnSelectedIndexChanged="rbtLstRating_SelectedIndexChanged">
                    <asp:ListItem Text="PENDIENTE" Value="PENDIENTE" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="ENTREGADO" Value="ENTREGADO"></asp:ListItem>
                    <asp:ListItem Text="ANULADO" Value="ANULADO"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style4">Por:</td>
            <td class="auto-style5">
                <asp:Button ID="btn_status" runat="server" Text="Status" OnClick="btn_status_Click" />
            </td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ColBuscada" runat="server">
                    <asp:ListItem Value="Cliente">Cliente</asp:ListItem>
                    <asp:ListItem Value="Producto">Producto</asp:ListItem>
                    <asp:ListItem Value="Cantidad">Cantidad</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>




    <asp:GridView ID="gridHistorial" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
        runat="server" OnRowDataBound="OnRowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Justify" SelectedIndex="0" Width="40%" AllowPaging="True" OnPageIndexChanging="Tabla_Producto_PageIndexChanging" CellSpacing="15" EmptyDataText="Sin resultados ">

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


    <br />
    <asp:Button ID="btn_editaPedido" runat="server" Text="Editar" OnClick="btn_editaPedido_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_pdf" runat="server" Text="Generar PDF" OnClick="btn_pdf_Click" Height="23px" />
    <br />
    <br />
    <br />
    <br />
      </div>

    <div id="Div_ActualizarPedido" runat="server">
        <fieldset>
            <legend>Editar estado de Pedido</legend>


            <table style="width: 50%;">
                <tr>
                    <td>Cliente</td>
                    <td>
                        <asp:TextBox ID="txt_cliente" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Producto</td>
                    <td>
                        <asp:TextBox ID="txt_producto" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Cantidad</td>
                    <td>
                        <asp:TextBox ID="txt_cantidad" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox ID="txt_precio" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha</td>
                    <td>
                        <asp:TextBox ID="txt_fecha" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>ENTREGADO</asp:ListItem>
                            <asp:ListItem>PENDIENTE</asp:ListItem>
                            <asp:ListItem>ANULADO</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancelar" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_Actualizar" runat="server" Style="margin-left: 0px" Text="Actualizar" OnClick="btn_Actualizar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </fieldset>



    </div>


</asp:Content>

