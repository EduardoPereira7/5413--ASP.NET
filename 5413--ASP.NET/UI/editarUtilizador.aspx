<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="editarUtilizador.aspx.cs" Inherits="_5413__ASP.NET.UI.editarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="text-center mt-4 mb-5">
        <h1 class="font-weight-bold">Editar Utilizador</h1>
            <p class="font-weight-bold">
                <asp:Label ID="L_Error" runat="server" Font-Bold="True" ForeColor="#CC0000" Text="Label" Visible="False"></asp:Label>
            </p>

    </div>



    <br />
    <br />
    <hr />
    <hr />
    <asp:DetailsView ID="dtv_utilizador" runat="server" Height="50px" Width="125px"
                    OnModeChanging="dtv_utilizador_ModeChanging"
                    OnItemUpdating="dtv_utilizador_ItemUpdating" DefaultMode="Edit">

        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" Width="300px" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Width="300px" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
  
    </div>
        &nbsp;
</asp:Content>
