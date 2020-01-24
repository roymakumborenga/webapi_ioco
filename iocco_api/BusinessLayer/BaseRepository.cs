using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using iocco_api.Models;
namespace iocco_api.BusinessLayer
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal IDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Insert(List<TEntity> entityList)
        {
            entityList.ForEach(s => {
                _dbSet.Add(s);
            });
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            this.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                this.Attach(entity);

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(List<TEntity> entityList)
        {
            entityList.ForEach(s => {
                if (_context.Entry(s).State == EntityState.Detached)
                    this.Attach(s);

                _dbSet.Remove(s);
                _context.SaveChanges();
            });

        }
        public void Delete(object id)
        {
            TEntity entity = _dbSet.Find(id);
            this.Delete(entity);
            _context.SaveChanges();
        }
        private void Attach(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
        }
    }
}