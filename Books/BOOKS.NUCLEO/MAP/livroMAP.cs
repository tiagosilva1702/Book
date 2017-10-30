using FluentNHibernate.Mapping;
using BOOKS.NUCLEO.DTO;

namespace BOOKS.NUCLEO.MAP
{
    public class livroMAP : ClassMap<livroDTO>
    {
        public livroMAP()
        {
            Table("dbo.LIVROS");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDLIVROS");
            Map(x => x.nome).Column("NOME");
            Map(x => x.autor).Column("AUTOR");
            Map(x => x.estado).Column("ESTADO");
            Map(x => x.isbn).Column("ISBN");
            Map(x => x.idgenero).Column("IDGENERO");
            Map(x => x.situacao).Column("SITUACAO");
            References(x => x.generoDTO).Column("IDGENERO").Not.LazyLoad();
        }
    }

    public class livrosMAP : ClassMap<livrosDTO>
    {
        public livrosMAP()
        {
            Table("dbo.LIVROS");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDLIVROS");
            Map(x => x.nome).Column("NOME");
            Map(x => x.autor).Column("AUTOR");
            Map(x => x.estado).Column("ESTADO");
            Map(x => x.isbn).Column("ISBN");
            Map(x => x.idgenero).Column("IDGENERO");
            Map(x => x.situacao).Column("SITUACAO");
        }
    }
}
