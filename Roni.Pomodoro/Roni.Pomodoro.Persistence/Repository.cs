using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Roni.Pomodoro.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private readonly PomodoroContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(PomodoroContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(string query, params object[] parameters)
        {
            return _entities.FromSqlRaw(query, parameters);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _entities;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }


        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            _context.SaveChanges();
        }
    }
}
