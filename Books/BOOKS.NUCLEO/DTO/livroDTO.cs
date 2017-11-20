using System.Collections.Generic;

namespace BOOKS.NUCLEO.DTO
{
    public class livroDTO
    {
        public virtual int? identificador { get; set; }

        public virtual string nome { get; set; }

        public virtual string autor { get; set; }

        public virtual bool situacao { get; set; }

        public virtual string descricao_situacao { get; set; }

        public virtual string estado { get; set; }

        public virtual int idgenero { get; set; }
        
        public virtual string isbn { get; set; }

        public virtual generoDTO generoDTO { get; set; }
    }

    public class livrosDTO
    {
        public virtual int? identificador { get; set; }

        public virtual string nome { get; set; }

        public virtual string autor { get; set; }

        public virtual bool situacao { get; set; }

        public virtual string estado { get; set; }

        public virtual int idgenero { get; set; }

        public virtual string isbn { get; set; }
    }

}
