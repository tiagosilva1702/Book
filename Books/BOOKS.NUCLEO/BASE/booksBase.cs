using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKS.NUCLEO.BASE
{
    public interface booksBase<T>
    {
        /// <summary>
        /// Método responsável por inserir um objeto de uma classe generica
        /// </summary>
        /// <param name="obj">obj da classe generica</param>
        void inserir(T obj);
        //void atualizar(List<T> obj);
        void atualizar(T obj);
        void deletar(T obj);
        T detalhar(int id);
        IList<T> obterTodos();
    }
}
