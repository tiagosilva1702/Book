using BOOKS.NUCLEO.BLL;
using BOOKS.NUCLEO.DTO;
using System;
using System.Linq;

namespace BOOKS.APRESENTACAO.MODULOS.Principal
{
    public partial class CadastrarLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = generoBLL.obterTodos();

            DropListGenero.DataSource = list;

            DropListGenero.DataBind();
        }

        protected void btnCadastrarLivro(object sender, EventArgs e)
        {
            livroDTO livro = new livroDTO
            {
                nome = txtNome.Text,
                autor = txtAutor.Text,
                situacao = false,
                estado = DropListEstado.Text,
                isbn = txtIsbn.Text,
                idgenero = Convert.ToInt32(DropListGenero.Text)
            };

            livroBLL.inserir(livro);
            Response.Redirect("CadastrarLivro.aspx");
        }

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

        usuarioBLL usuarioBLL = new usuarioBLL();
        livroBLL livroBLL = new livroBLL();
    }
}