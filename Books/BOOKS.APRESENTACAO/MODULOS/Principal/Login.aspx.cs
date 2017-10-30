using BOOKS.NUCLEO.BLL;
using BOOKS.NUCLEO.DTO;
using System;
using System.Linq;

namespace BOOKS.APRESENTACAO.MODULOS.Principal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcessar_Click(object sender, EventArgs e)
        {
           var consulta = usuarioBLL.ObterUsuariosPorCpf(txtCPF.Text, txtEmail.Text);
           if (consulta.Any())
           {
               SessaoUsuarioLogado = consulta.FirstOrDefault();
               Response.Redirect("Default.aspx");
           }
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


        usuarioBLL usuarioBLL = new usuarioBLL();
        
    }
}