<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="_5413__ASP.NET.UI.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


    <div class="text-center mt-5 mb-3">
        <h1>Utilizadores Não Verificados</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="listarNaoVerificados" OnPageIndexChanging="listarNaoVerificados_PageIndexChanging" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Verificado" HeaderText="Verificado" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            </Columns>
        </asp:GridView>
    </div>

        <div class="text-center mt-5 mb-3">
        <h1>Todos os Utilizadores</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="listarUtilizadores" OnPageIndexChanging="listarUtilizadores_PageIndexChanging" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Verificado" HeaderText="Verificado" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            </Columns>
        </asp:GridView>
    </div>


    </div>
</asp:Content>
