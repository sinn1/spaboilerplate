using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPABoilerplate.DAL.Contracts
{
    public interface IDataAccessObject<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        void Put(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Dispose();
    }
}
