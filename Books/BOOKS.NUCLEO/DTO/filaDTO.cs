using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class filaDTO
    {
        public virtual int? identificador { get; set; }
        /// <summary>
        ///  relacionamentos de tabelas fk
        /// </summary>
        public virtual usuarioDTO usuarioDTO { get; set; }

        public virtual livroDTO livroDTO { get; set; }

    }
}
