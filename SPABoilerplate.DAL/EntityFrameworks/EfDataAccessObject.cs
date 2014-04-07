using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPABoilerplate.DAL.Common;
using SPABoilerplate.DAL.Contracts;
using SPABoilerplate.DAL.EF;

namespace SPABoilerplate.DAL.EntityFrameworks
{
    public class EfDataAccessObject<TEntity> : IDataAccessObject<TEntity> where TEntity : class
    {
        private readonly IEfContext _context;
        private readonly DbSet<TEntity> _table;

        public EfDataAccessObject(IEfContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        #region Data Retrieval

        public IEnumerable<TEntity> GetAll()
        {
            return _table.AsEnumerable();
        }

        public TEntity Find(int id)
        {
            return _table.Find(id);
        }
        
        #endregion


        #region Data Modifications

        public void Put(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DataAccessException(DataAccessError.NOT_FOUND);
            }
        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _table.Remove(entity);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DataAccessException(DataAccessError.NOT_FOUND);
            }
        }

        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
