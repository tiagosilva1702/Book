using BOOKS.NUCLEO.DTO;
using FluentNHibernate.Mapping;

namespace BOOKS.NUCLEO.MAP
{
    public class estatisticaMAP : ClassMap<estatisticaDTO>
    {
        public estatisticaMAP()
        {
            Table("dbo.VIEW_ESTATISTICA");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDLIVROS");
            Map(x => x.nome).Column("NOME");
            Map(x => x.autor).Column("AUTOR");
            Map(x => x.maisAlugados).Column("MAISALUGADOS");
        }
    }
}
