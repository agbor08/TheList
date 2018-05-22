using System.Configuration;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Http;

namespace Lista
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);

            if (!System.IO.File.Exists(ConfigurationManager.AppSettings.Get("ServerFilePath")))
            {
                string path = ConfigurationManager.AppSettings.Get("ServerFilePath");
                FileStream file = File.Create(path);
            }
        }
    }
}
