<%@ Page Title="" Language="C#" MasterPageFile="~/GERAL/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Estatistica.aspx.cs" Inherits="BOOKS.APRESENTACAO.MODULOS.Principal.Estatistica" %>

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
                                <asp:Label runat="server" ID="lblUsuario"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Total de
                                <asp:Label runat="server" ID="lblLivrosAlugados"></asp:Label>
                                livros alugados.
                            </td>
                        </tr>
                        <tr>
                            <td>Ainda pode alugar
                                <asp:Label runat="server" ID="lblQtdLivroPraAlugar"></asp:Label>
                                livros.
                            </td>
                        </tr>
                        <tr>
                            <td>Seu ulltimo aluguel foi de R$<asp:Label runat="server" ID="lblValorUlltimoAluguel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Você tem R$<asp:Label runat="server" ID="lblDesconto"></asp:Label>
                                de desconto no próximo aluguel.
                            </td>
                        </tr>
                        <tr>
                            <td>Você tem R$<asp:Label runat="server" ID="lblMulta"></asp:Label>
                                de multa.
                            </td>
                        </tr>
                        <tr>
                            <td>Fila de Espera
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Devolucao.aspx">Devoluções</a>
                            </td>
                        </tr>
                        <tr>
                            <td>Histórico de Leitura
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Default.aspx">Principal</a>
                            </td>
                        </tr><tr>
                            <td>
                                <a href="Login.aspx">Login</a>
                            </td>
                        </tr>
                    </table>

                    <br />
                </fieldset>
            </td>
            <td style="width: 2%;"></td>
            <td style="width: 70%;" valign="top">
                <fieldset>
                    <legend class="lead" style="text-align: right;"><i class="genericon genericon-book" style="line-height: 30px;"></i>Acervo da Biblioteca</legend>
                    

                    <asp:GridView runat="server" CssClass="table table-bordered" ID="gvdEstatistica" AutoGenerateColumns="false" AllowPaging="True">
                        <Columns>
                            <asp:BoundField HeaderText="NOME" DataField="nome" />
                            <asp:BoundField HeaderText="AUTOR" DataField="autor" />
                            <asp:BoundField HeaderText="NÚMERO DE VEZES ALUGADOS" DataField="maisAlugados" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
