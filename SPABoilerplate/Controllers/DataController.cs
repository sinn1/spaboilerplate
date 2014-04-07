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
    }
}