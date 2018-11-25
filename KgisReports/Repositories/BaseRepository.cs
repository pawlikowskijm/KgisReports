using KgisReports.BO;
using KgisReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KgisReports.Repositories
{
    public class BaseRepository<T, TType> where T : BaseBO<TType>
    {
        protected AppDbContext _appDbContext { get; set; }

        public BaseRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public T Get(T entity)
        {
            return _appDbContext.Set<T>().Find(entity);
        }

        public T Get(TType id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            var returnEntity = _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();
            return returnEntity;
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<T> Where(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _appDbContext.Set<T>().Where(predicate);
            }
            return _appDbContext.Set<T>().AsEnumerable();
        }
    }
}