<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageLogin.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" EnableEventValidation="false" %>

<%@ Register Assembly="Tde.Controles.RutTextBox" Namespace="Tde.Controles" TagPrefix="tde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <div id="div_login" runat="server" style="margin-top: 10%; margin-right: 25%; margin-bottom: 0%; margin-left: 30%">
         <h2 class="top">Iniciar Sesion</h2>
        <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="Ingresar" RememberMeText="" UserNameLabelText="Rut" FailureText="Usuario no Registrado" Font-Names="Tahoma" LoginButtonImageUrl="~/img/login2.png" OnAuthenticate="Login1_Authenticate" PasswordRequiredErrorMessage="Ingresar Rut" UserNameRequiredErrorMessage="Ingresar Contraseña" Style="margin-bottom: 2px" Font-Size="Large" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CssClass="form_5" Font-Bold="False" ForeColor="#0066CC" Height="178px" TextLayout="TextOnTop" Width="383px">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" CssClass="button1" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <TextBoxStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Size="0.8em" />
            <TitleTextStyle BackColor="White" CssClass="h3" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/create1.png" OnClick="ImageButton1_Click" />
    </div>
    <div id="Div_NuevoCliente" runat="server" style="margin-top: 10%; margin-right: 25%; margin-bottom: 0%; margin-left: 30%">
        <fieldset style="width: 50%">
            <br />
            <h2 class="top">Registrar Cliente</h2>
            <br />
            <table style="width: 241%;">
                <tr>
                    <td rowspan="10">
                        <asp:Image ID="Image1" runat="server" Height="94px" ImageUrl="~/img/Registrocliente.png" Width="90px" />
                    </td>
                    <td>Rut</td>
                    <td>
                        <tde:RutTextBox ID="txt_RutCliente" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></tde:RutTextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_RutCliente" ErrorMessage="Ingresar Rut"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td>
                        <asp:TextBox ID="txt_contraseCiente" runat="server" TextMode="Password" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad</td>
                    <td>
                        <asp:DropDownList ID="Drop_nombreCiudad" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre_ciud" DataValueField="nombre_ciud">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCARRITO %>" SelectCommand="SELECT [nombre_ciud] FROM [ciudades]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td>
                        <asp:TextBox ID="txt_nombreCliente" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_nombreCliente" ErrorMessage="Ingresar Nombre "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Direccion</td>
                    <td>
                        <asp:TextBox ID="txt_direccionCliente" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_direccionCliente" ErrorMessage="Ingresar Direccion "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fono</td>
                    <td>
                        <asp:TextBox ID="txt_FonoCliente" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFono" runat="server" ControlToValidate="txt_FonoCliente" Display="Dynamic" ErrorMessage="Ingresar Celular" Font-Names="Century Gothic" Font-Size="10pt" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFono" runat="server" ControlToValidate="txt_FonoCliente" Display="Dynamic" ErrorMessage="Nº no valido" Font-Names="Century Gothic" Font-Size="10pt" ForeColor="Red" ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txt_emailCliente" runat="server" TextMode="Email" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_emailCliente" ErrorMessage="Ingresar Email"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;<asp:Button ID="btn_cancelRegCliente" runat="server" CausesValidation="False" OnClick="btn_cancelRegCliente_Click" Text="Cancelar" CssClass="button1" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btx_RegistrarCliente" runat="server" OnClick="btx_RegistrarCliente_Click" Style="height: 26px" Text="Registrar" BackColor="#0066CC" CssClass="button1" ForeColor="White" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />




</asp:Content>

