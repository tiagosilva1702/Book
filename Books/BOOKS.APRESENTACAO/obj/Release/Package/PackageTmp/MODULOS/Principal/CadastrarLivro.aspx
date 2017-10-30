<%@ Page Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarLivro.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <label>Nome:</label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

        <label>Autor:</label>
        <asp:TextBox ID="txtAutor" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

        <label>Estado:</label>
        <asp:DropDownList ID="DropListEstado" runat="server">
            <asp:ListItem Value="Novo">Novo</asp:ListItem>
            <asp:ListItem Value="Usado">Usado</asp:ListItem>
        </asp:DropDownList>

        <label>ISBN:</label>
        <asp:TextBox ID="txtIsbn" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

        <label>Gênero:</label>
        <asp:DropDownList ID="DropListGenero" AppendDataBoundItems ="true" DataTextField="descricao" DataValueField="identificador" runat="server">
            <asp:ListItem Value="0"> Selecione</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrarLivro" />
    </div>




</asp:Content>

