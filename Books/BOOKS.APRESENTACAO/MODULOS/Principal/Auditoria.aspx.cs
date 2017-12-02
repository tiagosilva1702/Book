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
            //Carregar livros para serem editados
            var auditoria = auditoriaBLL.obterTodos().ToList();
            foreach (var item in auditoria)
            {
                var genero = generoBLL.ObterPorId(item.idgenero);
                item.GeneroDTO = genero;

            }

            this.CarregarGridLivros(auditoria);

            ListAuditoria = new List<auditoriaDTO>();
        }

        private void CarregarGridLivros(List<auditoriaDTO> auditoria)
        {
            if (auditoria.Any())
            {
                gvdLivros.DataSource = auditoria;
                gvdLivros.DataBind();
                lblQuantidadeAcervo.Text = auditoria.Count().ToString();
            }
            else
            {
                gvdLivros.DataBind();
            }
        }

        generoBLL generoBLL = new generoBLL();
        livroBLL livroBLL = new livroBLL();
        auditoriaBLL auditoriaBLL = new auditoriaBLL();
        static List<auditoriaDTO> ListAuditoria;

    }
}