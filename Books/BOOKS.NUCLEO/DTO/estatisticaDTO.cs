using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class estatisticaDTO
    {
        public virtual int? identificador { get; set; }
        public virtual string nome { get; set; }
        public virtual string autor { get; set; }
        public virtual int? maisAlugados { get; set; }


    }
}
