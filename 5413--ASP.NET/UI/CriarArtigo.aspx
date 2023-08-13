﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CriarArtigo.aspx.cs" Inherits="_5413__ASP.NET.UI.CriarArtigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5">
        <h2>Criar Novo Artigo</h2>
        
            <div class="form-group">
                <label for="txtTitulo">Título</label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Insira o título do artigo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSubtitulo">Subtítulo</label>
                <asp:TextBox ID="txtSubtitulo" runat="server" CssClass="form-control" placeholder="Insira o subtítulo do artigo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtConteudo">Conteúdo</label>
                <asp:TextBox ID="txtConteudo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" placeholder="Insira o conteúdo do artigo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlCategoria">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">              
                </asp:DropDownList>
            </div>
        <div class="form-group">
            <asp:CheckBox ID="chkAcessibilidade" runat="server" Text="Apenas utilizadores registrados podem visualizar" />
            </div>

            <asp:Button ID="btnCriarArtigo" runat="server" Text="Criar Artigo" CssClass="btn btn-primary" OnClick="btnCriarArtigo_Click" />
    </div>
   
</asp:Content>
