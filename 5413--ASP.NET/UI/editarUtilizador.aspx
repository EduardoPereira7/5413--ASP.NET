<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="editarUtilizador.aspx.cs" Inherits="_5413__ASP.NET.UI.editarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="text-center mt-5 mb-5">
            <h1 class="font-weight-bold">Editar Utilizador</h1>
            <p class="font-weight-bold">
                <asp:Label ID="L_Error" runat="server" Font-Bold="True" ForeColor="#CC0000" Text="Label" Visible="False"></asp:Label>
            </p>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col-md-6">
                <asp:DetailsView ID="dtv_utilizador" runat="server"
                    OnModeChanging="dtv_utilizador_ModeChanging"
                    OnItemUpdating="dtv_utilizador_ItemUpdating" DefaultMode="Edit"
                    BackColor="White" CssClass="table table-bordered" Width="100%" Height="188px">
                    <EditRowStyle BackColor="#FFFFFF" />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <PagerStyle BackColor="#FFFFFF" ForeColor="Black" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle CssClass="text-center" BackColor="#FFFFFF"/>
                    <FooterTemplate>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="btn btn-primary" CausesValidation="true" Text="Update" />
                        <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="btn btn-danger" CausesValidation="false" Text="Cancel" />
                    </FooterTemplate>
                </asp:DetailsView>
            </div>
        </div>
    </div>
    &nbsp;
</asp:Content>
