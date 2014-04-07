using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPABoilerplate.DAL.Contracts
{
    public interface IDataStore
    {
        IDataAccessObject<TEntity> GetDataAccessObject<TEntity>() where TEntity : class;
        void SaveChanges();
    }
}
