using System;
using System.Configuration;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using SPABoilerplate.Config;
using SPABoilerplate.Controllers;
using SPABoilerplate.DAL.Contracts;
using SPABoilerplate.DAL.EF;
using SPABoilerplate.Database.EntityFrameworks;

namespace SPABoilerplate.Config
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IEfContext>().To<EfContext>();
            Bind<IDataStore>().To<EfDataStore>();
        }
    }
}
