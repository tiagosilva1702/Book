using FluentNHibernate.Mapping;
using BOOKS.NUCLEO.DTO;


namespace BOOKS.NUCLEO.MAP
{
    public class filaMAP:ClassMap<filaDTO>
    {
        public filaMAP()
        {
            Table("dbo.FILA_LIVRO_USUARIO");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDFILA_LIVRO_USUARIO");
            Map(x => x.idlivro).Column("IDLIVROS");
            Map(x => x.idusuario).Column("IDUSUARIO");
            Map(x => x.dtInicio).Column("DTINICIO");
            Map(x => x.dtFinal).Column("DTFINAL");
        }
    }
}
