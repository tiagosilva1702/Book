using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DTO
{
    public class auditoriaDTO
    {
        public virtual int? identificador { get; set; }
        public virtual DateTime dataalteracao { get; set; }
        public virtual int idlivro { get; set; }
        public virtual string nome { get; set; }
        public virtual string autor { get; set; }
        public virtual bool situacao { get; set; }
        public virtual string estado { get; set; }
        public virtual string isbn { get; set; }
        public virtual int idgenero { get; set; }
        public virtual string instrucao { get; set; }
        public virtual generoDTO GeneroDTO { get; set; }
    }
}
