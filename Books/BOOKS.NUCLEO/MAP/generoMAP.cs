using FluentNHibernate.Mapping;
using BOOKS.NUCLEO.DTO;

namespace BOOKS.NUCLEO.MAP
{
    public class generoMAP : ClassMap<generoDTO>
    {
        public generoMAP()
        {
            Table("dbo.GENERO");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDGENERO");
            Map(x => x.descricao).Column("DESCRICAO");
            Map(x => x.situacao).Column("SITUACAO");
        }

    }
}
