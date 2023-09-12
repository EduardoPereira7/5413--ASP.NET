<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="_5413__ASP.NET.UI.UserDashboard" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-5">
    <div class="container">
        <div class="text-center mt-4 mb-5">
        <h1 class="font-weight-bold">Dashboard</h1>
        <asp:Label ID="feedbackTop" runat="server" Visible="false" style='font-weight:bold; font-size:18px;'></asp:Label>
    </div>
        </div>
    <div class="container d-flex mt-5">

            <div id="divCriarArtigo" runat="server">
                <asp:Button ID="criarArtigo" class="btn btn-primary btn-block" runat="server" Text="Criar Artigo" OnClick="criarArtigo_Click" />
            </div>
            <div id="divAdminDashboard" runat="server" class="col-md-6" Visible="false">
                <asp:Button ID="btnAdminDashboard" class="btn btn-primary btn-block" runat="server" Text="Dashboard de Administrador" Visible="false" OnClick="btnAdminDashboard_Click"/>
            </div>
        </div>
    <div class="container mt-5">

    <div id="secaoArtigos" runat="server" visible="false">
            <h2>Os Meus Artigos</h2>
            <h3 id="feedback" class="text-center" visible="false" runat="server">Ainda não publicou nenhum artigo!</h3>
            <div class="row">
                <asp:Repeater ID="RepeaterArtigos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-12 mb-4">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title"><%# Eval("Titulo") %></h4>
                                    <h5 class="card-text"><%# Eval("Subtitulo") %></h5>
                                    <p class="card-text"><strong>Data de Publicação:</strong> <%# Eval("DataPublicacao", "{0:dd/MM/yyyy}") %></p>
                                    <p class="card-text"><strong>Categoria:</strong> <%# Eval("NomeCategoria") %></p>
                                    <asp:Button ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click" CommandArgument='<%# Eval("Id") %>' />
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("Id") %>' />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </div>
</div>
</asp:Content>
