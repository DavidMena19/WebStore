using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreMODEL.AccesoDeDatos.Data.Repository.IRepository
{
    //Repositorio Generico
    //T referencia de los modelos cuando se trabaje con un modelo la T se reemplazara por el nombre del modelo
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T,bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = null
            );

        IEnumerable<T> GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );

        //agregar una entidad
        void Add(T entity);
        //eliminar una entidad especifica por su id
        void Remove(int entity);
        //eliminar una entidad del modelo
        void Remove(T entity);
        

    }
}
