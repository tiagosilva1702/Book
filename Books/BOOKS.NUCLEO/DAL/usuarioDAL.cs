using System;
using System.Collections.Generic;
using System.Linq;
using BOOKS.NUCLEO.DTO;
using BOOKS.NUCLEO.BASE;
using NHibernate;
using NHibernate.Linq;

namespace BOOKS.NUCLEO.DAL
{
    /// <summary>
    /// Classe de persistencia de dados SetorDAL
    /// </summary>
    /// <typeparam name="T">Classe SetorDTO</typeparam>
    public class usuarioDAL<T> : booksBase<T> where T : class
    {
        #region Metodos especificos da classe

        public IList<usuarioDTO> ObterUsuarioDevedores()
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                try
                {
                    return sessao.QueryOver<usuarioDTO>()
                        .Where(x => x.situacao == true)
                        .List();
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public IList<usuarioDTO> ObterUsuariosPorCpf(string cpf, string email)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                try
                {
                    return sessao.QueryOver<usuarioDTO>()
                        .Where(x => x.cpf == cpf && x.email == email)
                        .List();
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public usuarioDTO ObterPorId(int id)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                usuarioDTO usuario = new usuarioDTO();
                var consulta = sessao.QueryOver<usuarioDTO>()
                                .Where(x => x.identificador == id)
                                .Take(1)
                                .List();

                if (consulta.Any())
                {
                    usuario = consulta.FirstOrDefault();
                }

                return usuario;
            }
        }
        #endregion

        #region Metodos da interface
        public void inserir(T obj)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                using (ITransaction trans = sessao.BeginTransaction())
                {
                    sessao.Save(obj);
                    trans.Commit();
                }
            }
        }

        public void atualizar(T obj)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                using (ITransaction trans = sessao.BeginTransaction())
                {
                    sessao.Update(obj);
                    trans.Commit();
                }
            }
        }

        public void atualizar(List<T> obj)
        {
            throw new NotImplementedException();
        }

        public void deletar(T obj)
        {
            throw new NotImplementedException();
        }

        public T detalhar(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> obterTodos()
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                try
                {
                    return sessao.QueryOver<T>().List();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    sessao.Flush();
                }
            }
        }
        #endregion
    }
}
