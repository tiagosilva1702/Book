﻿using System;
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
                livroUsuario.dtFinal = null;
                LivrosAluguel.Add(livroUsuario);
                CarregarGridLivrosAlugar(LivrosAluguel);
            }
            else if (e.CommandName.Equals("Fila"))
            {
                var livro = livroBLL.ObterPorId(Convert.ToInt32(e.CommandArgument.ToString()));
                filaDTO.livroDTO = livro;
                filaDTO.usuarioDTO = SessaoUsuarioLogado;
                filaDTO.dtInicio = DateTime.Now;
                filaDTO.dtFinal = null;
                LivrosFila.Add(filaDTO);
                CarregarGridLivrosFila(LivrosFila);
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

                var livrosAlugados = livroUsuarioBLL.obterTodos().Where(x => x.usuarioDTO.identificador == usuarioDTO.identificador && x.dtFinal is null).ToList();

                foreach (var item in livrosAlugados)
                {
                    if (item.livroDTO.identificador == livro.identificador)
                    {
                        alugar.Visible = false;
                        fila.Visible = false;
                    }
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

        protected void btnFinalizarFila(object sender, EventArgs e)
        {
            if (LivrosFila.Any())
            {
                this.SalvarFila(LivrosFila);
                alerta.Visible = true;
                lblMsgError.Text = "Prezado " + SessaoUsuarioLogado.nome + " Aluguel efetuado com sucesso, dentro de 2 horas o livro(os) chegará na sua residência";
                Response.Redirect("Default.aspx");
            }
        }
        protected void btnCancelarAluguel_Click(object sender, EventArgs e)
        {
            LivrosAluguel.Clear();
            LivrosFila.Clear();
            Response.Redirect("Default.aspx");
        }

        #endregion

        #region Metodos

        private void InicializarComponentes()
        {
            usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(SessaoUsuarioLogado.identificador));
            if (usuarioDTO.identificador is null)
            {
                Response.Redirect("Login.aspx");
            }
            LivrosAluguel = new List<livrousuarioDTO>();
            LivrosFila = new List<filaDTO>();
            var livros = livroBLL.obterTodos().OrderByDescending(x => x.situacao.Equals(true)).ToList();
            var consulta = filaBLL.obterTodos().ToList();
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

        private void CarregarGridLivrosFila(List<filaDTO> livros)
        {
            if (livros.Any())
            {
                gdvLivrosFila.DataSource = livros;
                gdvLivrosFila.DataBind();
            }
            else
            {
                gdvLivrosFila.DataBind();
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

        private void SalvarFila(List<filaDTO> livros)
        {
            try
            {
                //usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(livros.First().usuarioDTO.identificador));
                List<filaDTO> fila = new List<filaDTO>();

                foreach (var item in livros)
                {
                    fila.Add(new filaDTO
                    {
                        idlivro = item.livroDTO.identificador,
                        idusuario = item.usuarioDTO.identificador,
                        dtInicio = item.dtInicio,
                        dtFinal = null
                    });
                }

                filaBLL.inserir(fila);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
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

        #endregion

        #region Propriedades
        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
        livroUsuarioBLL livroUsuarioBLL = new livroUsuarioBLL();
        filaBLL filaBLL = new filaBLL();

        static List<livrousuarioDTO> LivrosAluguel;
        static List<filaDTO> LivrosFila;

        usuarioDTO usuarioDTO;
        livrousuarioDTO livroUsuario = new livrousuarioDTO();
        filaDTO filaDTO = new filaDTO();

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