using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DbContext;
using Newtonsoft.Json;

namespace SocialNetworkApi
{
    public class WebApiApplication : HttpApplication
    {
        protected async void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperWebConfiguration.Configure();

            await DbInitializer.Init();
        }
    }
}
