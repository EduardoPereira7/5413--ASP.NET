<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="editarUtilizador.aspx.cs" Inherits="_5413__ASP.NET.UI.editarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
        <h2>Editar Utilizador</h2>
        <div class="form-group">
            <label for="txtNome">Nome</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoNome" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoEmail" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoPassword" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
        </div>
    <div class="form-group">
        <label for="chkNaoAlterarSenha">Não Alterar Senha</label>
        <asp:CheckBox ID="chkNaoAlterarSenha" runat="server" AutoPostBack="true" OnCheckedChanged="chkNaoAlterarSenha_CheckedChanged"/>
    </div>
        <div class="form-group">
            <label for="chkVerificado">Verificado</label>
            <asp:CheckBox ID="chkVerificado" runat="server" />
        </div>
        <div class="form-group">
            <label for="chkAdmin">Admin</label>
            <asp:CheckBox ID="chkAdmin" runat="server" />
        </div>
        <asp:Button ID="btnEditarUtilizador" runat="server" Text="Editar Utilizador" CssClass="btn btn-primary" OnClick="btnEditarUtilizador_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
