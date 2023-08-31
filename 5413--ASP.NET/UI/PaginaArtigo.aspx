<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PaginaArtigo.aspx.cs" Inherits="_5413__ASP.NET.UI.PaginaArtigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <br />
        <asp:Label ID="L_Titulo" runat="server" Font-Bold="True" Font-Size="Medium" Text="Titulo"></asp:Label>
        <br />        
        <asp:Label ID="L_SubTitulo" runat="server" Font-Bold="True" Font-Size="Small" Text="SubTitulo"></asp:Label>
        <br />
        <asp:Label ID="L_Restrito" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Acesso Restrito a Utilizadores Registados" Visible="False"></asp:Label>
        
    </div>

    <div id="divArtigo" class="p-5 text-justify" runat="server">
    </div>

</asp:Content>