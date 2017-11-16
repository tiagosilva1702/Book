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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InicializarComponentes();
            }
        }

        #region Métodos

        private void InicializarComponentes()
        {
            usuarioDTO = usuarioBLL.ObterPorId(Convert.ToInt32(SessaoUsuarioLogado.identificador));
        //    this.CarregarGrid(SessaoUsuarioLogado);
        //    this.PreencherDadosTela(SessaoUsuarioLogado);
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