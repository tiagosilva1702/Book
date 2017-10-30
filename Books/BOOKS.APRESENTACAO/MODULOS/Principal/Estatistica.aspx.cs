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
    public partial class Estatistica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InicializarComponentes();
        }

        #region Metodos

        private void InicializarComponentes()
        {
            var estatistica = estatisticabll.obterTodos().OrderBy(x => x.identificador).ToList();
            this.CarregarGrid(estatistica);
            this.PreencherDadosTela(SessaoUsuarioLogado);
        }

        private void CarregarGrid(List<estatisticaDTO> lstEstatistica)
        {
            gvdEstatistica.DataSource = lstEstatistica;
            gvdEstatistica.DataBind();
            
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

            if (!string.IsNullOrEmpty(usuarioDTO.desconto.ToString()))
            {
                lblDesconto.Text = usuarioDTO.desconto.ToString();
            }
            else
            {
                lblDesconto.Text = "0";
            }

            if (!string.IsNullOrEmpty(usuarioDTO.juros.ToString()))
            {
                lblMulta.Text = usuarioDTO.juros.ToString();
            }
            else
            {
                lblMulta.Text = "0";
            }

            if (!string.IsNullOrEmpty(usuarioDTO.ulltimoAlguel.ToString()))
            {
                lblValorUlltimoAluguel.Text = usuarioDTO.ulltimoAlguel.ToString();
            }

            if (!string.IsNullOrEmpty(usuarioDTO.nome))
            {
                lblUsuario.Text = usuarioDTO.nome;
            }

            if (livros.Any())
            {
                lblLivrosAlugados.Text = livros.Count.ToString();

                if (livros.Count < 5)
                {
                    int valor = 5 - livros.Count;
                    lblQtdLivroPraAlugar.Text = valor.ToString();
                }
                else
                {
                    lblQtdLivroPraAlugar.Text = "0";
                }
            }

        }

        #endregion  

         
        #region Propriedades
        estatisticaDTO estatisticaDTO = new estatisticaDTO();
        estatisticaBLL estatisticabll = new estatisticaBLL();

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