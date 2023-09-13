<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarArtigo.aspx.cs" Inherits="_5413__ASP.NET.UI.EditarArtigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
            <h2>Editar Artigo</h2>
    <div class="form-group">
        <label for="txtTitulo">Título</label>
        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblAvisoTitulo" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtSubtitulo">Subtítulo</label>
        <asp:TextBox ID="txtSubtitulo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblAvisoSubTitulo" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtConteudo">Conteúdo</label>
        <asp:TextBox ID="txtConteudo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
    </div>
         <asp:Label ID="lblAvisoConteudo" runat="server" CssClass="text-danger font-weight-bold" Text="Deve preencher todos os campos" Visible="false"></asp:Label>
    <div class="form-group">
        <label for="ddlCategoria">Categoria</label>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="chkAcessibilidade" runat="server" Text="Apenas utilizadores registados podem visualizar" />
    </div>
         <asp:Button ID="btnEditarArtigo" runat="server" Text="Editar Artigo" CssClass="btn btn-primary" OnClick="btnEditarArtigo_Click" />
         <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
