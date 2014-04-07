using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPABoilerplate.DAL.Contracts;
using SPABoilerplate.Models;

namespace SPABoilerplate.Controllers
{
    public class DataController : BaseController<Data>
    {
        public DataController(IDataStore dataStore) : base(dataStore)
        {
        }

        public override IEnumerable<Data> GetAll()
        {
            return new List<Data>()
            {
                new Data() { Id = 1, Name = "Data1"},
                new Data() { Id = 2, Name = "Data2"},
                new Data() { Id = 3, Name = "Data3"},
                new Data() { Id = 4, Name = "Data4"}
            };
        }
    }
}