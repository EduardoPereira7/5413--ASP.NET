<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_5413__ASP.NET.UI.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center ">
        <div class="jumbotron jumbotron-fluid m-5" style="width:60vw">
            <div class="container px-5">
                <h1 class="display-4 font-weight-bold">Blog</h1>
                <p class="lead">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
            </div>
        </div>
    </div>
   
        <h1 class="text-center mb-5 font-weight-bold">Artigos</h1>
   <div id="cardsContainer" runat="server" class="container">
        <!-- Cards aqui -->
    </div>

</asp:Content>
