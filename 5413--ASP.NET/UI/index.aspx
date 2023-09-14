<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_5413__ASP.NET.UI.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center ">
    <div class="jumbotron jumbotron-fluid m-5 col-md-8" style="width:60vw">
        <div class="container px-5">
            <h1 class="display-4 font-weight-bold">Blog</h1>
            <p class="lead">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
        </div>
    </div>
</div>
    <div id="cardsContainer" runat="server" class="d-flex justify-content-center flex-column align-items-center">
        <asp:Label ID="lblSemArtigos" runat="server" Text="Nenhum artigo para mostrar" Visible="false" Font-Bold="true" Font-Size="Large"/>
    </div>
    <div class="d-flex justify-content-center pagination mt-3">
        <asp:Button ID="btnPrev" runat="server" Text="Anterior" OnClick="btnPrev_Click" CssClass="btn btn-primary mx-2 mb-5" />
        <asp:Button ID="btnNext" runat="server" Text="Próximo" OnClick="btnNext_Click" CssClass="btn btn-primary mx-2 mb-5" />
    </div>
</asp:Content>
