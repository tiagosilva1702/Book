using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BOOKS.APRESENTACAO.GERAL.Master
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InicializarComponentes();
            }
        }

        #endregion

        #region Métodos

        public void InicializarComponentes()
        {
            lblDataAtual.Text = DateTime.Now.ToLongDateString();
        }

        #endregion

        #region Propriedades

        #endregion
    }
}