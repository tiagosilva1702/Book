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
    public partial class Auditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InicializarComponentes();
            }

        }

        private void InicializarComponentes()
        {
            // Carregar DropList genero
            var list = generoBLL.obterTodos();

            //Carregar livros para serem editados
            var livros = livroBLL.obterTodos().OrderByDescending(x => x.situacao.Equals(true)).ToList();
            this.CarregarGridLivros(livros);

            LivrosAluguel = new List<livrousuarioDTO>();
            LivrosFila = new List<filaDTO>();
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

        generoBLL generoBLL = new generoBLL();
        livroBLL livroBLL = new livroBLL();
        static List<livrousuarioDTO> LivrosAluguel;
        static List<filaDTO> LivrosFila;

    }
}