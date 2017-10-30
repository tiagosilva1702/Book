using FluentNHibernate.Mapping;
using BOOKS.NUCLEO.DTO;

namespace BOOKS.NUCLEO.MAP
{
    public class livroUsuarioMAP : ClassMap<livrousuarioDTO>
    {
        public livroUsuarioMAP()
        {
            Table("dbo.LIVRO_USUARIO");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDLIVRO_USUARIO");
            References(x => x.livroDTO).Column("IDLIVROS");
            References(x => x.usuarioDTO).Column("IDUSUARIO");
            Map(x => x.dtInicio).Column("DTINICIO");
            Map(x => x.dtFinal).Column("DTFINAL");
        }
    }
}
