<%@ Page Title="" Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group col-md-5">
        <label for="inputEmail3" class="col-md-2 control-label">Nome:</label>
        <div class="form-group col-sm-10">
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        </div>
        <label for="inputEmail3" class="col-md-2 control-label">Email:</label>
        <div class="form-group col-sm-10">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        </div>
        <label for="inputEmail3" class="col-md-2 control-label">CPF:</label>
        <div class="form-group col-sm-10">
            <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        </div>
        <label for="inputEmail3" class="col-md-2 control-label">Telefone:</label>
        <div class="form-group col-sm-10">
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
        </div>
        <label for="inputEmail3" class="col-md-2 control-label">Perfil:</label>
        <div class="form-group col-sm-10">
            <asp:DropDownList ID="DropList" class="form-control"
                runat="server">
                <asp:ListItem Value="1"> Administrador </asp:ListItem>
                <asp:ListItem Value="2"> Funcionario </asp:ListItem>
                <asp:ListItem Value="3"> Cliente </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-offset-8">
            <asp:Button ID="btnAcessar" runat="server" CssClass="btn btn-primary" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrar_Click" />
        </div>
    </div>
</asp:Content>

