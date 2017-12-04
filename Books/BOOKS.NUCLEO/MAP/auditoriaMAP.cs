using BOOKS.NUCLEO.DTO;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.MAP
{
    class auditoriaMAP : ClassMap<auditoriaDTO>
    {
        public auditoriaMAP()
        {
            Table("dbo.AUDITORIA");
            Id(x => x.identificador).GeneratedBy.Native().Column("IDAUDITORIA");
            Map(x => x.dataalteracao).Column("DATAALTERACAO");
            Map(x => x.idlivro).Column("IDLIVRO");
            Map(x => x.nome).Column("NOME");
            Map(x => x.autor).Column("AUTOR");
            Map(x => x.situacao).Column("SITUACAO");
            Map(x => x.estado).Column("ESTADO");
            Map(x => x.isbn).Column("ISBN");
            Map(x => x.idgenero).Column("IDGENERO");
            References(x => x.GeneroDTO).Column("IDGENERO");
            Map(x => x.instrucao).Column("INSTRUCAO");
        }
    }
}
