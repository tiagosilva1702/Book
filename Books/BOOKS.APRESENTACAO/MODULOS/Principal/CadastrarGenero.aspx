<%@ Page Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarGenero.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarGenero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <label>Descrição:</label>
        <asp:TextBox ID="txtDescricao" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrarGenero" />
    </div>
</asp:Content>

