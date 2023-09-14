<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="_5413__ASP.NET.UI.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 px-5">
        <div class="d-flex justify-content-center mb-4">
            <h2 class="font-weight-bold">Register</h2>
        </div>
        <div class="form-row">
            <div class="col-md-6 mb-3">
                <label>Primeiro Nome</label>
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6 mb-3">
                <label>Último Nome</label>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-6 mb-3">
                <label for="exampleInputEmail1">Endereço de Email</label>
                <asp:TextBox runat="server" ID="txtRegisterEmail" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6 mb-3">
                <label for="exampleInputPassword1">Password</label>
                <asp:TextBox runat="server" ID="txtRegisterPassword" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="d-flex justify-content-center align-items-center flex-column mt-4">
            <asp:Label ID="lblRegisterError" runat="server" Text="Label" Visible="false" CssClass="mb-4 text-danger" style='font-weight:bold; font-size:18px;'></asp:Label>
            <asp:Button runat="server" ID="btnRegister" Text="Criar conta" CssClass="btn btn-dark w-25" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>
