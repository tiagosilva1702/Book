using BOOKS.NUCLEO.BASE;
using BOOKS.NUCLEO.DTO;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOOKS.NUCLEO.DAL
{
    public class generoDAL<T> : booksBase<T> where T : class
    {
        public generoDTO ObterPorId(int id)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                generoDTO genero = new generoDTO();
                var consulta = sessao.QueryOver<generoDTO>()
                                .Where(x => x.identificador == id)
                                .Take(1)
                                .List();

                if (consulta.Any())
                {
                    genero = consulta.FirstOrDefault();
                }

                return genero;
            }
        }


        public void Salvar(List<livroDTO> Livros)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                using (ITransaction trans = sessao.BeginTransaction())
                {
                    foreach (var item in Livros)
                    {
                        sessao.Save(item);
                        trans.Commit();
                    }
                }
            }
        }


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
