using BOOKS.NUCLEO.BLL;
using BOOKS.NUCLEO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BOOKS.APRESENTACAO.MODULOS.Principal
{
    public partial class CadastrarLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = generoBLL.obterTodos();

            DropListGenero.DataSource = list;

            DropListGenero.DataBind();

            LivrosAluguel = new List<livrousuarioDTO>();
            LivrosFila = new List<filaDTO>();

        }

        protected void btnCadastrarLivro(object sender, EventArgs e)
        {
            livrosDTO livro = new livrosDTO
            {
                nome = txtNome.Text,
                autor = txtAutor.Text,
                situacao = false,
                estado = "Novo",
                isbn = txtIsbn.Text,
                idgenero = Convert.ToInt32(DropListGenero.Text)
            };

            livroBLL.inserir(livro);
            Response.Redirect("CadastrarLivro.aspx");
        }

        protected void gvdLivros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var livros = livroBLL.obterTodos().OrderBy(x => x.nome).ToList();
            gvdLivros.PageIndex = e.NewPageIndex;
            gvdLivros.DataSource = livros;
            gvdLivros.DataBind();
        }

        private void CarregarGridLivros(List<livroDTO> livros)
        {
            if (livros.Any())
            {
                gvdLivros.DataSource = livros;
                gvdLivros.DataBind();
                lblQuantidadeAcervo.Text = livros.Count().ToString();
            }
            else
            {
                gvdLivros.DataBind();
            }
        }

        protected void gvdLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alugar"))
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(e.CommandArgument.ToString()));
                DateTime hoje = DateTime.Now;
                livroUsuario.livroDTO = livro;
                livroUsuario.usuarioDTO = SessaoUsuarioLogado;
                livroUsuario.dtInicio = string.Format("{0:dd/MM/yyyy}", hoje);
                livroUsuario.dtFinal = null;
                LivrosAluguel.Add(livroUsuario);
            }
        }

        protected void gvdLivros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button alugar = (Button)e.Row.FindControl("btnAlugar");
                Button fila = (Button)e.Row.FindControl("btnFila");

                var livro = (livroDTO)e.Row.DataItem;

                if (livro.situacao == true)
                {
                    e.Row.Cells[4].Text = "Alugado";
                    alugar.Visible = false;
                    fila.Visible = true;
                }
                else if (livro.situacao == false)
                {
                    e.Row.Cells[4].Text = "Disponível";
                    alugar.Visible = true;
                    fila.Visible = false;
                }
            }
        }

        private usuarioDTO SessaoUsuarioLogado
        {
            get
            {
                if (Session["usuario"] == null || !(Session["usuario"] is usuarioDTO))
                {
                    Session["usuario"] = new usuarioDTO();
                }

                return (usuarioDTO)Session["usuario"];
            }

            set
            {
                Session["usuario"] = value;
            }
        }

        generoBLL generoBLL = new generoBLL();

        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
        livrousuarioDTO livroUsuario = new livrousuarioDTO();

        static List<livrousuarioDTO> LivrosAluguel;
        static List<filaDTO> LivrosFila;


    }
}