using BOOKS.NUCLEO.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace BOOKS.NUCLEO.BASE
{
    public class Aplicacao
    {
        public static usuarioDTO UsuarioLogado
        {
            get
            {
                usuarioDTO usuario = null;
                if ((HttpContext.Current.Session != null) && (HttpContext.Current.Session["UsuarioLogado"] != null))
                    usuario = (usuarioDTO)HttpContext.Current.Session["UsuarioLogado"];

                return usuario;
            }
            set
            {
                HttpContext.Current.Session["UsuarioLogado"] = value;
            }
        }
    }
}
