<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArtigosUtilizador.aspx.cs" Inherits="_5413__ASP.NET.UI.ArtigosUtilizador" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mb-5">
        <h1 id="h1Titulo" runat="server" class="text-center mb-2 font-weight-bold mt-4">Artigos do Utilizador</h1>
            <h3 id="h3NomeUtilizador" runat="server" class="text-center mb-5 "></h3>
            <div class="d-flex justify-content-center text-center flex-column mb-4">
            <asp:Label ID="feedbackTop" runat="server" Visible="false" style='font-weight:bold; font-size:18px;'></asp:Label>
            <span id="mensagemArtigos" runat="server" class="text-danger font-weight-bold" style='font-size:18px;'>Não há artigos para exibir</span>
                </div>
        <div id="cardsContainer" runat="server" class="container">
<a href="AdminDashboard.aspx" class="btn btn-primary mb-4">Voltar para o Painel de Administração</a>
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
            <div class="d-flex justify-content-center">
            <asp:Button ID="btnAnterior" runat="server" Text="Anterior" OnClick="btnAnterior_Click" CssClass="btn btn-primary mx-1 mt-2" />
            <asp:Button ID="btnProximo" runat="server" Text="Próximo" OnClick="btnProximo_Click"  CssClass="btn btn-primary mx-1 mt-2" />
        </div>
        
    </div>
</asp:Content>
