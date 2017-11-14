using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class filaDTO
    {
        public virtual int? identificador { get; set; } 

        public virtual usuarioDTO usuarioDTO { get; set; }

        public virtual livroDTO livroDTO { get; set; }

        public virtual DateTime dtInicio { get; set; }

        public virtual DateTime? dtFinal { get; set; }

        public virtual int? idusuario { get; set; }

        public virtual int? idlivro { get; set; }

    }

    public class filaEsperaDTO
    {
        public virtual int? identificador { get; set; }

        public virtual DateTime dtInicio { get; set; }

        public virtual DateTime? dtFinal { get; set; }

    }
}
