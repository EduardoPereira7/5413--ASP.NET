<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pesquisa.aspx.cs" Inherits="_5413__ASP.NET.UI.pesquisa1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
    .custom-card {
        width: 50vw;
        height: auto;
    }
    </style>

    <h3 class="text-center">
        <asp:TextBox ID="T_pesquisa" runat="server" Font-Size="Small" Height="23px" Width="167px"></asp:TextBox>
        <asp:Button ID="btn_PesquisarPalavra" runat="server" Font-Bold="True" Font-Size="Small" Text="PESQUISAR" CssClass="btn-primary" OnClick="btn_PesquisarPalavra_Click" />
    </h3>
    <p class="text-center">
        <asp:Label ID="L_alert" runat="server" Font-Bold="True" ForeColor="#CC0000" Text="Label" Visible="False"></asp:Label>
    </p>
    <hr />
    <hr />
    <p class="text-center">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pesquisa por data</strong></p>
    <p class="text-center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DD_Anos" runat="server" BackColor="White">
        </asp:DropDownList>
        <asp:DropDownList ID="DD_Mes" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_PesquizarData" runat="server" OnClick="btn_Pesquizar_Click" Text="PESQUISAR" Font-Bold="True" Font-Size="Small" CssClass="btn-primary" />
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    
    <div id="CardsContainer" runat="server" class="d-flex justify-content-center flex-column align-items-center">
        <!-- Artigos aqui -->
    </div>
</asp:Content>
