using FluentNHibernate.Mapping;
using BOOKS.NUCLEO.DTO;

namespace BOOKS.NUCLEO.MAP
{
    public class usuarioMAP : ClassMap<usuarioDTO>
    {
        public usuarioMAP()
        {
            Table("dbo.USUARIO");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDUSUARIO");
            Map(x => x.nome).Column("NOME");
            Map(x => x.cpf).Column("CPF");
            Map(x => x.email).Column("EMAIL");
            Map(x => x.telefone).Column("TELEFONE");
            Map(x => x.situacao).Column("SITUACAO");
            Map(x => x.desconto).Column("DESCONTO");
            Map(x => x.juros).Column("JUROS");
            Map(x => x.ulltimoAlguel).Column("ULTIMO_ALUGUEL");
            Map(x => x.idperfil).Column("IDPERFIL");
        }
    }
}
