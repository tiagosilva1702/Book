using BOOKS.NUCLEO.BLL;
using BOOKS.NUCLEO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BOOKS.APRESENTACAO.MODULOS.Principal
{
    public partial class FiladeEspera : System.Web.UI.Page
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
        }

        protected void gvdLivros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button alugar = (Button)e.Row.FindControl("btnAlugar");

                var livro = (livroDTO)e.Row.DataItem;

                if (livro.situacao == true)
                {
                    alugar.Visible = false;
                }
                else if (livro.situacao == false)
                {
                    alugar.Visible = true;
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



        #endregion



        #region Métodos

        private void InicializarComponentes()
        {
            usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(SessaoUsuarioLogado.identificador));
            LivrosAluguel = new List<livrousuarioDTO>();
            LivrosFila = new List<filaDTO>();

            this.CarregarGrid(SessaoUsuarioLogado);
            this.PreencherDadosTela(SessaoUsuarioLogado);
        }

        private void PreencherDadosTela(usuarioDTO usuarioDTO)
        {
            var livrosAlugados = livroUsuarioBLL.obterTodos().Where(x => x.usuarioDTO.identificador == usuarioDTO.identificador && x.dtFinal is null).ToList();

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

        private void CarregarGrid(usuarioDTO usuarioDTO)
        {
            var consulta = filaBLL.obterTodos().ToList();

            List<livroDTO> livros = new List<livroDTO>();

            foreach (var item in consulta)
            {
                if (item.idusuario == usuarioDTO.identificador && !item.dtFinal.HasValue)
                {
                    var book = livroBLL.ObterPorId(Convert.ToInt32(item.idlivro));
                    switch (book.situacao)
                    {
                        case true:
                            book.descricao_situacao = "Alugado";
                            break;
                        case false:
                            book.descricao_situacao = "Disponível";
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                    livros.Add(book);
                }
            }


            gvdLivros.DataSource = livros.GroupBy(x => x.identificador).Select(c => c.First()).ToList();
            gvdLivros.DataBind();
            lblQuantidadeAcervo.Text = livros.Count().ToString();

        }

        protected void btnFinalizarAluguel_Click(object sender, EventArgs e)
        {
            if (LivrosAluguel.Any())
            {
                this.SalvarDados(LivrosAluguel);
                //alerta.Visible = true;
                //lblMsgError.Text = "Prezado " + SessaoUsuarioLogado.nome + " Aluguel efetuado com sucesso, dentro de 2 horas o livro(os) chegará na sua residência";
                Response.Redirect("FiladeEspera.aspx");
            }
        }

        protected void btnCancelarAluguel_Click(object sender, EventArgs e)
        {
            LivrosAluguel.Clear();
            LivrosFila.Clear();
            Response.Redirect("Default.aspx");
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
                List<filaDTO> fila = new List<filaDTO>();

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

                    //DateTime hoje = DateTime.Now;
                    var listfila = filaBLL.obterTodos().Where(x => x.idlivro == item.livroDTO.identificador &&
                        x.idusuario == item.usuarioDTO.identificador).ToList();

                    foreach (var itemfila in listfila)
                    {
                        fila.Add(new filaDTO
                        {
                            identificador = itemfila.identificador,
                            idlivro = item.livroDTO.identificador,
                            idusuario = item.usuarioDTO.identificador,
                            dtInicio = itemfila.dtInicio,
                            dtFinal = DateTime.Now
                        });

                    }

                }

                livroBLL.atualizar(livro);

                filaBLL.atualizar(fila);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }


        #endregion


        #region Propriedades
        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
        livroUsuarioBLL livroUsuarioBLL = new livroUsuarioBLL();
        filaBLL filaBLL = new filaBLL();

        usuarioDTO usuarioDTO = new usuarioDTO();

        static List<livrousuarioDTO> LivrosAluguel;
        static List<filaDTO> LivrosFila;

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