<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArtigosUtilizador.aspx.cs" Inherits="_5413__ASP.NET.UI.ArtigosUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <h1 id="h1Titulo" runat="server" class="text-center mb-2 font-weight-bold mt-4">Artigos do Utilizador</h1>
            <h3 id="h3NomeUtilizador" runat="server" class="text-center mb-5 "></h3>
        <div id="cardsContainer" runat="server" class="container">
            <span id="mensagemArtigos" runat="server" class="text-danger">Não há artigos para exibir</span>

<asp:Repeater ID="rptArtigos" runat="server">
    <ItemTemplate>
        <%# Container.ItemIndex % 2 == 0 ? "<div class='row'>" : "" %>
        <div class='col-md-6'>
            <div class='card mb-3'>
                <div class='card-header'><%# Eval("Titulo") %></div>
                <div class='card-body'>
                    <h5 class='card-title'><%# Eval("Subtitulo") %></h5>
                    <p class='card-text'>Publicado em: <%# Convert.ToDateTime(Eval("DataPublicacao")).ToShortDateString() %></p>
                </div>
                <div class='card-footer'>
                    <a href='PaginaArtigo.aspx?id=<%# Eval("Id") %>' class='btn btn-primary mr-2'>Ver</a>
                    <asp:Button ID="btnEliminar" runat="server" class='btn btn-danger mr-2' Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' />
                </div>
            </div>
        </div>
        <%# Container.ItemIndex % 2 == 1 || Container.ItemIndex == rptArtigos.Items.Count - 1 ? "</div>" : "" %>
    </ItemTemplate>
</asp:Repeater>
        </div>
        <a href="AdminDashboard.aspx" class="btn btn-primary m-3">Voltar para o Painel de Administração</a>
    </div>
</asp:Content>
