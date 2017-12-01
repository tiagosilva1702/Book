<%@ Page Title="" Language="C#" EnableEventValidation="true" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarLivro.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.CadastrarLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <table style="width: 100%;">
        <tr>
            <td style="width: 20%;" valign="top">
                <fieldset>
                    <legend class="lead">Menu</legend>
                    <table style="width: 100%;" class="table table-bordered">
                        <tr>
                            <td style="font-size: 20px; color: #5bc0de;">Olá,
                                <asp:Label runat="server" ID="lblUsuario" Text="José"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Default.aspx">Principal</a>
                            </td>
                        </tr>

                    </table>
                </fieldset>
            </td>
            <td style="width: 2%;"></td>
            <td style="width: 70%;" valign="top">

                <fieldset>
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Cadastrar</legend>
                    <div style="margin-bottom: 50px;">
                        <label>Nome:</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>Autor:</label>
                        <asp:TextBox ID="txtAutor" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>ISBN:</label>
                        <asp:TextBox ID="txtIsbn" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>Gênero:</label>
                        <asp:DropDownList ID="DropListGenero" AppendDataBoundItems="true" DataTextField="descricao" DataValueField="identificador" runat="server">
                            <asp:ListItem Value="0"> Selecione</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrarLivro" />
                    </div>
                </fieldset>
                <fieldset>
                    <asp:GridView runat="server" CssClass="table table-bordered" ID="gvdLivros" AutoGenerateColumns="false" AllowPaging="True"
                        OnRowCommand="gvdLivros_RowCommand" AlternatingRowStyle-CssClass="warning" OnPageIndexChanging="gvdLivros_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="NOME" DataField="nome" />
                            <asp:BoundField HeaderText="AUTOR" DataField="autor" />
                            <asp:BoundField HeaderText="ISBN" DataField="isbn" HeaderStyle-Width="5%" />
                            <asp:BoundField HeaderText="GÊNERO" DataField="generoDTO.descricao" HeaderStyle-Width="5%" />
                            <asp:TemplateField HeaderText="AÇÕES" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEditar" Text="E" CssClass="btn btn-info" CommandArgument='<%# Eval("Identificador")%>' CommandName="Editar" ToolTip="Editar livro" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                    <div style="float: right;" class="label label-default">
                        Total de
                    <asp:Label runat="server" ID="lblQuantidadeAcervo"></asp:Label>
                        registros.
                    </div>
                </fieldset>
                <br />
                <br />
                <fieldset>
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Editar</legend>
                    <div style="margin-bottom: 50px;">
                        <label style="display: none;">ID:</label>
                        <asp:TextBox ID="txtEditarIdentificador" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right" Style="display: none;"></asp:TextBox>

                        <label>Nome:</label>
                        <asp:TextBox ID="txtEditarNome" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>Autor:</label>
                        <asp:TextBox ID="txtEditarAutor" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>ISBN:</label>
                        <asp:TextBox ID="txtEditarIsbn" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>

                        <label>Gênero:</label>
                        <asp:DropDownList ID="DropEditarListGenero" AppendDataBoundItems="true" DataTextField="descricao" DataValueField="identificador" runat="server">
                            <asp:ListItem Value="0"> Selecione</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtLastName" runat="server" Style="display: none;"></asp:TextBox>

                        <asp:Button ID="btnEditar" runat="server" CssClass="btn" Text="EDITAR" CausesValidation="true" OnClick="btnEditarLivro" />
                    </div>
                </fieldset>
            </td>
        </tr>
    </table>

</asp:Content>


