using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BOOKS.NUCLEO.DTO;
using BOOKS.NUCLEO.BLL;

namespace BOOKS.APRESENTACAO.MODULOS.Principal
{
    public partial class Devolucao : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InicializarComponentes();
            }
        }

        protected void gvdLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Devolver"))
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(e.CommandArgument.ToString()));

                List<livrosDTO> lv = new List<livrosDTO>();

                lv.Add(new livrosDTO
                {
                    autor = livro.autor,
                    estado = livro.estado,
                    identificador = livro.identificador,
                    idgenero = livro.idgenero,
                    isbn = livro.isbn,
                    nome = livro.nome,
                    situacao = false
                });

                livroBLL.atualizar(lv);
                Response.Redirect("Devolucao.aspx");
            }
        }

        #endregion



        #region Métodos

        private void InicializarComponentes()
        {
            usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(SessaoUsuarioLogado.identificador));
            this.CarregarGrid(SessaoUsuarioLogado);
            this.PreencherDadosTela(SessaoUsuarioLogado);
        }

        private void PreencherDadosTela(usuarioDTO usuarioDTO)
        {
            var livrosAlugados = livroUsuarioBLL.obterTodos().Where(x => x.usuarioDTO.identificador == usuarioDTO.identificador).ToList();

            List<livroDTO> livros = new List<livroDTO>();

            foreach (var item in livrosAlugados)
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(item.livroDTO.identificador));
                if (livro.situacao == true)
                {
                    livros.Add(livro);
                }
            }

            if (!string.IsNullOrEmpty(usuarioDTO.nome))
            {
                lblUsuario.Text = usuarioDTO.nome;
            }

            if (livros.Any())
            {
                lblLivrosAlugados.Text = livros.Count.ToString();
            }


        }

        private void CarregarGrid(usuarioDTO usuarioDTO)
        {
            var consulta = livroUsuarioBLL.obterTodos().Where(x => x.usuarioDTO.identificador == usuarioDTO.identificador).ToList();
            List<livroDTO> livros = new List<livroDTO>();

            foreach (var item in consulta)
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(item.livroDTO.identificador));
                if (livro.situacao == true)
                {
                    livros.Add(livro);
                }
            }

            var teste = livros.GroupBy(x => x.identificador).Select(c => c.First()).ToList();

            gvdLivros.DataSource = teste;
            gvdLivros.DataBind();
            lblQuantidadeAcervo.Text = teste.Count().ToString();

        }

        #endregion


        #region Propriedades
        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
        livroUsuarioBLL livroUsuarioBLL = new livroUsuarioBLL();
        usuarioDTO usuarioDTO = new usuarioDTO();

        /// <summary>
        /// Propriedade que guarda o Usuario Logado.
        /// </summary>
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
        #endregion

    }
}