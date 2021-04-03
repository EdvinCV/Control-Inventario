using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL.Repositorio
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext BD_Colores;

        public GenericRepository(DbContext context)
        {
            BD_Colores = context;
        }


        public virtual IQueryable<T> ListarTodo()
        {
            IQueryable<T> consulta = BD_Colores.Set<T>();
            return consulta.ToList().AsQueryable();
        }

        public IQueryable<T> ListarTodoConFiltro(Expression<Func<T, bool>> filtro)
        {
            IQueryable<T> consulta = BD_Colores.Set<T>().Where(filtro);
            return consulta.ToList().AsQueryable();
        }

        public void Agregar(T entity)
        {
            BD_Colores.Set<T>().Add(entity);
            BD_Colores.SaveChanges();
        }

        public void Actualizar(T entity)
        {
            BD_Colores.Entry(entity).State = EntityState.Modified;
            BD_Colores.SaveChanges();
        }
    }
}
