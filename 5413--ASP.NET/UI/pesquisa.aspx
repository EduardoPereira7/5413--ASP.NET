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

<div class="container mt-4 mb-5 border rounded">
        <h1 class="text-center mb-4">Pesquisa</h1>
        <div class="row">
            <div class="col-md-6">
                <h4 class="text-center">Por Palavra</h4>
                <asp:TextBox ID="T_pesquisa" runat="server" Font-Size="Small" CssClass="form-control mb-2" placeholder="Insira a palavra-chave"></asp:TextBox>
                <asp:Button ID="btn_PesquisarPalavra" runat="server" Font-Bold="True" Font-Size="Small" Text="PESQUISAR" CssClass="btn btn-primary btn-block" OnClick="btn_PesquisarPalavra_Click" />
            </div>
            <div class="col-md-6">
                <h4 class="text-center">Por Data</h4>
                <asp:DropDownList ID="DD_Anos" runat="server" CssClass="form-control mb-2">
                </asp:DropDownList>
                <asp:DropDownList ID="DD_Mes" runat="server" CssClass="form-control mb-2">
                </asp:DropDownList>
                <asp:Button ID="btn_PesquizarData" runat="server" OnClick="btn_Pesquizar_Click" Text="PESQUISAR" Font-Bold="True" Font-Size="Small" CssClass="btn btn-primary btn-block" />
            </div>
        </div>
        <hr />
        <p class="text-center">
            <asp:Label ID="L_alert" runat="server" Font-Bold="True" ForeColor="#CC0000" Text="Label" Visible="False"></asp:Label>
        </p>
        <div id="CardsContainer" runat="server" class="d-flex justify-content-center flex-column align-items-center mt-5">
            <!-- Artigos aqui -->
        </div>
    </div>
</asp:Content>