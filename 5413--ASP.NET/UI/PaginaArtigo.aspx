<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PaginaArtigo.aspx.cs" Inherits="_5413__ASP.NET.UI.PaginaArtigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-5 border rounded">   
    <div class="text-center">
        <br />
        <br />
        <br />
        <asp:Label ID="L_Titulo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Titulo"></asp:Label>
        <br />
        <br /> 
        <asp:Label ID="L_SubTitulo" runat="server" Font-Bold="False" Font-Size="Medium" Text="SubTitulo"></asp:Label>
        <br />
        <asp:Label ID="L_Restrito" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Acesso Restrito a Utilizadores Registados" Visible="False"></asp:Label>    
        <br />       
    </div>
    <div id="divArtigo" class="p-5 text-justify" runat="server" style="max-width: 100%; overflow-wrap: break-word;">
    </div>     
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClientClick="window.history.back(); return false;" CssClass="btn btn-secondary mb-4 ml-5" />
        <asp:Button ID="Bt_like" runat="server" Text="Gosto" CssClass="btn btn-primary mb-4 ml-2" OnClick="Bt_like_Click"/>
        <br />
        </div>
</asp:Content>