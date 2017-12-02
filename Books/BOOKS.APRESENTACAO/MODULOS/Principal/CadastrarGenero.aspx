<%@ Page Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarGenero.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarGenero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group col-md-6">
        <label for="inputEmail3" class="col-md-2 control-label">Descrição</label>
        <div class="form-group col-sm-10">
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        </div>
        <div class="col-lg-offset-9">
            <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrarGenero" />
        </div>
    </div>
</asp:Content>

