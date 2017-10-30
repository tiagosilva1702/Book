﻿using System;
using System.Collections.Generic;
using BOOKS.NUCLEO.DTO;
using BOOKS.NUCLEO.BASE;
using NHibernate;
using NHibernate.Linq;

namespace BOOKS.NUCLEO.DAL
{
    public class estatisticaDAL<T> :  booksBase<T> where T : class
    {
        #region Metodos da interface
        public void inserir(T obj)
        {
            throw new NotImplementedException();
        }

        public void atualizar(T obj)
        {
            throw new NotImplementedException();
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
