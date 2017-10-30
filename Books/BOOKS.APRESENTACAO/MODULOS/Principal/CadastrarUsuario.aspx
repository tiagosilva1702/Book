<%@ Page Title="" Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label>Nome:</label>
    <asp:TextBox ID="txtNome" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

    <label>Email:</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

    <label>CPF:</label>
    <asp:TextBox ID="txtCPF" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

    <label>Telefone:</label>
    <asp:TextBox ID="txtTelefone" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

    <asp:DropDownList ID="DropList"
        runat="server">
        <asp:ListItem Value="1"> Administrador </asp:ListItem>
        <asp:ListItem Value="2"> Funcionario </asp:ListItem>
        <asp:ListItem Value="3"> Cliente </asp:ListItem>
    </asp:DropDownList>

    <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrar_Click" />
    <br />
</asp:Content>

