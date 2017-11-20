using System;
using System.Collections.Generic;
using BOOKS.NUCLEO.DTO;
using BOOKS.NUCLEO.BASE;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace BOOKS.NUCLEO.DAL
{
    public class filaDAL<T> : booksBase<T> where T : class
    {
        public filaDTO ObterPorId(int id)
        {
            using (ISession sessao = SessionBase.AbrirSessao())
            {
                filaDTO fila = new filaDTO();
                
                var consulta = sessao.QueryOver<filaDTO>()
                                .Where(x => x.identificador == id)
                                .Take(1)
                                .List();

                if (consulta.Any())
                {
                    fila = consulta.FirstOrDefault();
                }

                return fila;
            }
        }

        public void inserir(List<T> obj)
        {

            using (ISession sessao = SessionBase.AbrirSessao())
            {
                using (ITransaction trans = sessao.BeginTransaction())
                {
                    foreach (var item in obj)
                    {
                        sessao.Save(item);
                    }
                    trans.Commit();
                }
            }
        }




        #region Metodos da interface
        public void inserir(T obj)
        {
            throw new NotImplementedException();
        }

        public void atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public void deletar(T obj)
        {
            throw new NotImplementedException();
        }

        public void atualizar(List<T> obj)
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
