using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebStoreMODEL.AccesoDeDatos.Data.Repository.IRepository;

namespace WebStoreMODEL.AccesoDeDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
        private readonly DbContext _Context;
        internal DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            _Context = context;
            this.DbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(int id)
        {
           return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = null;

            if (filter != null)
            query = query.Where(filter);

            if (includeProperties != null)
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }

            if(orderBy != null)
            {
                //se ejecuta la funcion de ordenamiento y se convierte la consulta en una lista
                return orderBy(query).ToList();
            }
            // Si no se proporciona ordenamiento se convierte la consulta en una lista
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
             
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
       
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T find = DbSet.Find(id);
        }

        public void Remove(T entity)
        {
           DbSet.Remove(entity);
        }

        IEnumerable<T> IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>>? filter, string? includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
