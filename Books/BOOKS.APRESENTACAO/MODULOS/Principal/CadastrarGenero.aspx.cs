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
    public partial class CadastrarGenero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnCadastrarGenero(object sender, EventArgs e)
        {
            generoDTO genero = new generoDTO
            {
                descricao = txtDescricao.Text.ToUpper(),
                situacao = true
            };

            generoBLL.inserir(genero);

            Response.Redirect("CadastrarGenero.aspx");


            //var consulta = usuarioBLL.ObterUsuariosPorCpf(txtCPF.Text, txtEmail.Text);
            //if (consulta.Any())
            //{
            //    SessaoUsuarioLogado = consulta.FirstOrDefault();
            //}
        }

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

        generoBLL generoBLL = new generoBLL();
    }
}