<%@ Page Title="" Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <label>Email:</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
    <label>CPF:</label>
    <asp:TextBox ID="txtCPF" runat="server" TextMode="Password" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
    <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="ACESSAR" CausesValidation="true" OnClick="btnAcessar_Click"/>
    <br />
</asp:Content>
