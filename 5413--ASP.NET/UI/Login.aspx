<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_5413__ASP.NET.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 px-5">
        <div class="d-flex justify-content-center mb-4">
            <h2 class="font-weight-bold">Login</h2>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="d-flex justify-content-center align-items-center flex-column mt-4">
            <asp:Label ID="lblLoginError" runat="server" Text="Label" Visible="false" CssClass="mb-4 text-danger"></asp:Label>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-dark w-25" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>
