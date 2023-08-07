<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="_5413__ASP.NET.UI.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="text-center mt-4 mb-5">
        <h1 class="font-weight-bold">Admin Dashboard</h1>
    </div>

    <div class="text-left mt-5 mb-3">
        <h2>Utilizadores Não Verificados</h2>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="listarNaoVerificados" OnPageIndexChanging="listarNaoVerificados_PageIndexChanging" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <%--<asp:BoundField DataField="Password" HeaderText="Password" />--%>
                <asp:BoundField DataField="Verificado" HeaderText="Verificado" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:TemplateField HeaderText="Ação">
            <ItemTemplate>
                <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" CommandArgument='<%# Eval("Id") %>' Visible='<%# !(bool)Eval("Verificado") %>' />
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
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:CheckBox ID="esconderNaoVerificados" runat="server" AutoPostBack="true" OnCheckedChanged="esconderNaoVerificados_CheckedChanged" Text="Esconder não verificados" />


    </div>
</asp:Content>
