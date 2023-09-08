<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PaginaArtigo.aspx.cs" Inherits="_5413__ASP.NET.UI.PaginaArtigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 border rounded">   
    <div class="text-center">
        <br />
        <asp:Label ID="L_Titulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Titulo"></asp:Label>
        <br /> 
        <asp:Label ID="L_SubTitulo" runat="server" Font-Bold="False" Font-Size="Medium" Text="SubTitulo"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="L_Restrito" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Acesso Restrito a Utilizadores Registados" Visible="False"></asp:Label>
        
        <br />
        
    </div>

    <div id="divArtigo" class="p-5 text-justify" runat="server">
    </div>
        
        <br />
        
        <asp:Button ID="Bt_like" runat="server" Text="I LIKE IT" CssClass="btn-primary" OnClick="Bt_like_Click" />
        <br />
        <br />
        <br />
        </div>

</asp:Content>