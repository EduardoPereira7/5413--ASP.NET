<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pesquisa.aspx.cs" Inherits="_5413__ASP.NET.UI.pesquisa1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center">
        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Small" Height="23px" Width="167px"></asp:TextBox>
        <asp:Button ID="btn_PesquisarPalavra" runat="server" Font-Bold="True" Font-Size="Small" Text="PESQUISAR" />
    </h3>
    <hr />
    <hr />
    <p class="text-center">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pesquisa por data</strong></p>
    <p class="text-center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DD_Anos" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DD_Mes" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_PesquizarData" runat="server" OnClick="btn_Pesquizar_Click" Text="PESQUISAR" Font-Bold="True" Font-Size="Small" />
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="List_ResultadosPesquisa" runat="server" Height="372px" Width="556px"></asp:ListBox>
    </p>
</asp:Content>
