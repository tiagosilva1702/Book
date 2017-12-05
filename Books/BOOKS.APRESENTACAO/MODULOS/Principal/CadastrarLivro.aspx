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
                        <tr>
                            <td>
                                <a href="Auditoria.aspx">Auditoria</a>
                            </td>
                        </tr>

                    </table>
                </fieldset>
            </td>
            <td style="width: 2%;"></td>
            <td style="width: 70%;" valign="top">

                <fieldset>
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Cadastrar</legend>
                    <div style="margin-bottom: 50px;" class="form-group">
                        <label for="inputEmail3" class="col-md-2 control-label">Nome</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">Autor</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">ISBN</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtIsbn" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">Gênero</label>
                        <div class="form-group col-sm-10">
                            <asp:DropDownList ID="DropListGenero" AppendDataBoundItems="true" Class="form-control" DataTextField="descricao" DataValueField="identificador" runat="server">
                                <asp:ListItem Value="0"> Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-offset-10">
                            <asp:Button ID="btnAcessar" runat="server" CssClass="btn btn-primary" Text="CADASTRAR" CausesValidation="true" OnClick="btnCadastrarLivro" />
                        </div>
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
                            <asp:TemplateField HeaderText="EDITAR" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEditar"  Text="E" CssClass="btn btn-info" CommandArgument='<%# Eval("Identificador")%>' CommandName="Editar" ToolTip="Editar livro" />
                                </ItemTemplate>
                                <%--OnClientClick="javascript: btnEditar();"--%>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%--<asp:Button runat="server" ID="btnDeletar"  Text="D" CssClass="btn btn-block" CommandArgument='<%# Eval("Identificador")%>' CommandName="Deletar" ToolTip="Deletar livro" />--%>
                                </ItemTemplate>
                                <%--OnClientClick="javascript: btnEditar();"--%>
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
                <fieldset >
                    <%--<p id="demo"></p>--%>
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Editar</legend>
                    <div style="margin-bottom: 50px;" class="form-group">

                        <label style="display: none;">ID:</label>
                        <asp:TextBox ID="txtEditarIdentificador" runat="server" CssClass="textarea" data-toggle="tooltip" data-trigger="manual" data-placement="right" Style="display: none;"></asp:TextBox>

                        <label for="inputEmail3" class="col-md-2 control-label">Nome</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtEditarNome" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">Autor</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtEditarAutor" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">ISBN</label>
                        <div class="form-group col-sm-10">
                            <asp:TextBox ID="txtEditarIsbn" runat="server" CssClass="form-control" data-toggle="tooltip" data-trigger="manual" data-placement="right"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-md-2 control-label">Gênero</label>
                        <div class="form-group col-sm-10">
                            <asp:DropDownList ID="DropEditarListGenero" AppendDataBoundItems="true" Class="form-control" DataTextField="descricao" DataValueField="identificador" runat="server">
                                <asp:ListItem Value="0"> Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-offset-10">
                            <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary" Text="EDITAR" CausesValidation="true" OnClick="btnEditarLivro" />
                        </div>
                    </div>
                </fieldset>
            </td>
        </tr>
    </table>


</asp:Content>


