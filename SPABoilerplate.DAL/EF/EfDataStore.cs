using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPABoilerplate.DAL.Common;
using SPABoilerplate.DAL.Contracts;

namespace SPABoilerplate.DAL.EF
{
    public class EfDataStore : IDataStore
    {
        private readonly IEfContext _dbContext;

        public EfDataStore(IEfContext context)
        {
            _dbContext = context;
        }

        public IDataAccessObject<TEntity> GetDataAccessObject<TEntity>() where TEntity : class
        {
            return new EfDataAccessObject<TEntity>(_dbContext);
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DataAccessException(DataAccessError.NOT_FOUND);
            }
            catch (OptimisticConcurrencyException)
            {
                throw new DataAccessException(DataAccessError.OUT_OF_SYNC);
            }
        }
    }
}
