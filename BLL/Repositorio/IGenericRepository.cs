using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace BLL.Repositorio
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> ListarTodo();
        IQueryable<T> ListarTodoConFiltro(Expression<Func<T, bool>> filtro);

        void Agregar(T entity);
        void Actualizar(T entity);
    }
}
