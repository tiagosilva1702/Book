using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class livrousuarioDTO
    {
        public virtual int? identificador { get; set; }

        public virtual usuarioDTO usuarioDTO { get; set; }

        public virtual livroDTO livroDTO { get; set; }

        public virtual string dtInicio { get; set; }

        public virtual string dtFinal { get; set; }
    }
}
