<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <br />
          <h2 class="top">Historial de Pedidos</h2>
        <br />

    <%--<asp:gridview id="gridhistorial" runat="server" height="351px" width="799px" >
          

    </asp:GridView>--%>
    <asp:GridView ID="gridHistorial" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
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


</asp:Content>

