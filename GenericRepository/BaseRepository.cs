using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal NorthwindEntities context;
        internal DbSet<TEntity> dbset;
        public BaseRepository()
        {
            this.context = new NorthwindEntities();
            this.dbset = context.Set<TEntity>();
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if(context.Entry(entityToDelete).State==EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }
        public virtual void Delete(object id)
        {
            TEntity entity = dbset.Find(id);
            Delete(entity);
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            if(filter !=null)
            {
                query = query.Where(filter);
            }
            if(includeProperties!=null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if(orderBy !=null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public TEntity GetById(object id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbset.SqlQuery(query, parameters).ToList();
        }
        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}