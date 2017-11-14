<%@ Page Title="" Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Devolucao.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.Devolucao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
                            <td>Total de
                                <asp:Label runat="server" ID="lblLivrosAlugados"></asp:Label>
                                livros alugados.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="FiladeEspera.aspx">Fila de Espera</a>
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
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Aluguéis</legend>
                    <asp:GridView runat="server" CssClass="table table-bordered" ID="gvdLivros" AutoGenerateColumns="false" AllowPaging="True"
                        AlternatingRowStyle-CssClass="warning" OnRowCommand="gvdLivros_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="NOME" DataField="nome" />
                            <asp:BoundField HeaderText="AUTOR" DataField="autor" />
                            <asp:BoundField HeaderText="ISBN" DataField="isbn" HeaderStyle-Width="5%" />
                            <asp:BoundField HeaderText="GÊNERO" DataField="generoDTO.descricao" HeaderStyle-Width="5%" />
                            <asp:BoundField HeaderText="SITUAÇÃO" DataField="situacao" HeaderStyle-Width="5%" />
                            <asp:TemplateField HeaderText="AÇÕES" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDevolver" Text="X" CssClass="btn btn-danger" CommandArgument='<%# Eval("Identificador")%>' CommandName="Devolver" ToolTip="Devolver Livro" />
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
            </td>
        </tr>
    </table>


</asp:Content>
