using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class usuarioDTO
    {
        /// <summary>
        /// identificador com ? application aceita null
        /// </summary>
        public virtual int? identificador { get; set; }
        public virtual string nome { get; set; }
        public virtual string cpf { get; set; }
        public virtual string email { get; set; }
        public virtual string telefone { get; set; }
        public virtual bool situacao { get; set; }
        public virtual double? desconto { get; set; }
        public virtual double? juros { get; set; }
        public virtual double? ulltimoAlguel { get; set; }
        public virtual int idperfil { get; set; }

    }
}
