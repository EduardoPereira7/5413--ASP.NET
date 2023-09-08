<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="_5413__ASP.NET.UI.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="text-center mt-4 mb-5">
        <h1 class="font-weight-bold">Admin Dashboard</h1>
            <p class="font-weight-bold">
                <asp:Label ID="L_Error" runat="server" ForeColor="Red" Text="ERROR" Visible="False"></asp:Label>
            </p>
    </div>
        <div class="container d-flex mt-5">
            <div class="col-md-6">
                <asp:Button ID="criarArtigo" class="btn btn-primary btn-block" runat="server" Text="Criar Artigo" OnClick="criarArtigo_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="gerirMeusArtigos" class="btn btn-primary btn-block" runat="server" Text="Gerir os Meus Artigos" OnClick="gerirMeusArtigos_Click" />
            </div>
        </div>
    <div class="text-left mt-5 mb-3">
        <h2>Pendentes de Verificação</h2>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="listarNaoVerificados" OnPageIndexChanging="listarNaoVerificados_PageIndexChanging" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Verificado" HeaderText="Verificado" />
                <asp:BoundField DataField="admin" HeaderText="Admin" >
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ação">
                    <ItemTemplate>
                        <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" CommandArgument='<%# Eval("Id") %>' Visible='<%# !(bool)Eval("Verificado") %>' />                                  
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

        <div class="text-left mt-5 mb-3">
        <h2>Todos os Utilizadores</h2>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="listarUtilizadores" OnPageIndexChanging="listarUtilizadores_PageIndexChanging" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <%--<asp:BoundField DataField="Password" HeaderText="Password" />--%>
                <asp:BoundField DataField="Verificado" HeaderText="Verificado" />
                <asp:BoundField DataField="admin" HeaderText="Admin" />
                <asp:TemplateField HeaderText="Ação">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Editar" OnClick="btnEditar" CommandArgument='<%# Eval("Id") %>' />                
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' />
                <asp:Button ID="btnVerArtigos" runat="server" Text="Ver artigos" OnClick="btnVerArtigos_Click" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    
    </div>
</asp:Content>
