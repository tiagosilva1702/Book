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
            References(x => x.livroDTO).Column("IDLIVROS");
            References(x => x.usuarioDTO).Column("IDUSUARIO");
        }
    }
}
