using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using SPABoilerplate.Config;
using SPABoilerplate.Config.Ninject;

namespace SPABoilerplate
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Kernel.Instance = new StandardKernel(new Module());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(Kernel.Instance);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public override void Init()
        {
            BeginRequest += OnBeginRequest;
        }

        protected virtual void OnBeginRequest(object sender, EventArgs e)
        {
            var localPath = Request.Url.LocalPath;
            if (localPath == string.Empty
             || localPath == "/"
             || !localPath.StartsWith("/api", true, CultureInfo.InvariantCulture))
            {
                Context.RewritePath(@"~/index.html", true);
            }
        }
    }
}