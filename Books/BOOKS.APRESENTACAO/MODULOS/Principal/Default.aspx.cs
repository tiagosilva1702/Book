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
    public partial class Default : System.Web.UI.Page
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
            if (e.CommandName.Equals("Alugar"))
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(e.CommandArgument.ToString()));
                DateTime hoje = DateTime.Now;
                livroUsuario.livroDTO = livro;
                livroUsuario.usuarioDTO = SessaoUsuarioLogado;
                livroUsuario.dtInicio = string.Format("{0:dd/MM/yyyy}", hoje);
                livroUsuario.dtFinal = string.Format("{0:dd/MM/yyyy}", hoje.AddDays(5));
                LivrosAluguel.Add(livroUsuario);
                CarregarGridLivrosAlugar(LivrosAluguel);
            }
            else if (e.CommandName.Equals("Fila"))
            {
                alerta.Visible = true;
                lblMsgError.Text = "Livro já está alugado!";
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

        protected void gvdLivros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var livros = livroBLL.obterTodos().OrderBy(x => x.nome).ToList();
            gvdLivros.PageIndex = e.NewPageIndex;
            gvdLivros.DataSource = livros;
            gvdLivros.DataBind();
        }

        protected void btnConsultarLivro_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeLivros.Text))
            {
                alerta.Visible = false;
                var consulta = livroBLL.obterTodos()
                    .Where(n => n.nome.Equals(txtNomeLivros.Text))
                    .OrderBy(x => x.nome)
                    .ToList();

                if (consulta.Any())
                {
                    CarregarGridLivros(consulta);
                }
                else
                {
                    alerta.Visible = true;
                    lblMsgError.Text = txtNomeLivros.Text;
                }
            }
            else
            {
                var novaConsulta = livroBLL.obterTodos().OrderBy(x => x.nome).ToList();
                CarregarGridLivros(novaConsulta);
            }
        }

        protected void btnFinalizarAluguel_Click(object sender, EventArgs e)
        {
            if (LivrosAluguel.Any())
            {
                this.SalvarDados(LivrosAluguel);
                alerta.Visible = true;
                lblMsgError.Text = "Prezado " + SessaoUsuarioLogado.nome + " Aluguel efetuado com sucesso, dentro de 2 horas o livro(os) chegará na sua residência";
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnCancelarAluguel_Click(object sender, EventArgs e)
        {
            LivrosAluguel.Clear();
            Response.Redirect("Default.aspx");
        }

        #endregion

        #region Metodos

        private void InicializarComponentes()
        {
            usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(SessaoUsuarioLogado.identificador));
            LivrosAluguel = new List<livrousuarioDTO>();
            var livros = livroBLL.obterTodos().OrderByDescending(x => x.situacao.Equals(true)).ToList();
            this.CarregarGridLivros(livros);
            this.PreencherDadosTela(SessaoUsuarioLogado);
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

        private void CarregarGridLivrosAlugar(List<livrousuarioDTO> livros)
        {
            if (livros.Any())
            {
                gdvLivrosAluguel.DataSource = livros;
                gdvLivrosAluguel.DataBind();
            }
            else
            {
                gdvLivrosAluguel.DataBind();
            }
        }

        private void SalvarDados(List<livrousuarioDTO> livros)
        {
            try
            {
                usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(livros.First().usuarioDTO.identificador));
                livroUsuarioBLL.Salvar(livros);
                usuarioDTO.ulltimoAlguel = 5 * livros.Count();

                usuarioBLL.atualizar(usuarioDTO);

                List<livrosDTO> livro = new List<livrosDTO>();

                foreach (var item in livros)
                {
                    livro.Add(new livrosDTO
                    {
                        autor = item.livroDTO.autor,
                        estado = item.livroDTO.estado,
                        identificador = item.livroDTO.identificador,
                        idgenero = item.livroDTO.idgenero,
                        isbn = item.livroDTO.isbn,
                        nome = item.livroDTO.nome,
                        situacao = true
                    });
                }

                livroBLL.atualizar(livro);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
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

            //if (!string.IsNullOrEmpty(usuarioDTO.desconto.ToString()))
            //{
            //    lblDesconto.Text = usuarioDTO.desconto.ToString();
            //}
            //else
            //{
            //    lblDesconto.Text = "0";
            //}

            //if (!string.IsNullOrEmpty(usuarioDTO.juros.ToString()))
            //{
            //    lblMulta.Text = usuarioDTO.juros.ToString();
            //}
            //else
            //{
            //    lblMulta.Text = "0";
            //}

            //if (!string.IsNullOrEmpty(usuarioDTO.ulltimoAlguel.ToString()))
            //{
            //    lblValorUlltimoAluguel.Text = usuarioDTO.ulltimoAlguel.ToString();
            //}

            if (!string.IsNullOrEmpty(usuarioDTO.nome))
            {
                lblUsuario.Text = usuarioDTO.nome;
            }

            if (livros.Any())
            {
                lblLivrosAlugados.Text = livros.Count.ToString();
            }

        }

        #endregion

        #region Propriedades
        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
        livroUsuarioBLL livroUsuarioBLL = new livroUsuarioBLL();
        static List<livrousuarioDTO> LivrosAluguel;

        usuarioDTO usuarioDTO;
        livrousuarioDTO livroUsuario = new livrousuarioDTO();

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