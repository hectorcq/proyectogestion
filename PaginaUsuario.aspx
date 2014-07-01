<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="PaginaUsuario.aspx.cs" Inherits="PaginaUsuario" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    
    <br />
    <br />
    <br />
    <h2 class="top">BIENVENIDO USUARIO!</h2><br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <br />
&nbsp;<asp:Button ID="Button1" runat="server" Text="Cerrar Sesion" OnClick="Button1_Click" CssClass="button1" />
    <br />
    <br />

 </asp:Content>