using System;
using System.Collections.Generic;
using System.Linq;
using BOOKS.NUCLEO.DTO;
using BOOKS.NUCLEO.BASE;
using NHibernate;
using NHibernate.Linq;

namespace BOOKS.NUCLEO.DAL
{
    public class livroDAL<T> : booksBase<T> where T : class
    {
        public livroDTO ObterPorId(int id)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                livroDTO livro = new livroDTO();
                var consulta = sessao.QueryOver<livroDTO>()
                                .Where(x => x.identificador == id)
                                .Take(1)
                                .List();

                if (consulta.Any())
                {
                    livro = consulta.FirstOrDefault();
                }

                return livro;
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

        public void atualizar(List<livrosDTO> obj)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                using (ITransaction trans = sessao.BeginTransaction())
                {
                    foreach (var item in obj)
                    {
                        sessao.Update(item);
                    }
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
