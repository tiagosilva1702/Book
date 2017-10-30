using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BOOKS.NUCLEO.BASE
{
    /// <summary>
    /// Classe responsável pela conexao com o banco de dados sqlServer 2008 R2
    /// </summary>
    public class SessionBase
    {
        /// <summary>
        /// variavel do tipo ISessionFactory
        /// </summary>
        private static ISessionFactory sessao;

        /// <summary>
        /// Metodo responsável por criar uma sessão
        /// </summary>
        /// <returns>The session</returns>
        public static ISessionFactory CriarSessao()
        {
            try
            {
                if (sessao != null)
                {
                    return sessao;
                }

                IPersistenceConfigurer configuraDB = MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=sql.servidor.homologacao;Initial Catalog=PreventCataclysmSystems;Persist Security Info=True;User ID=tiago.santos;Password='tiago.santos123*';");
                var configMap = Fluently.Configure().Database(configuraDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<BOOKS.NUCLEO.MAP.usuarioMAP>());
                sessao = configMap.BuildSessionFactory();
                
                return sessao;
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }

        /// <summary>
        /// Metodo responsavel por abrir uma sessão
        /// </summary>
        /// <returns>The open session</returns>
        public static ISession AbrirSessao()
        {
            return CriarSessao().OpenSession();
        }
    }
}
