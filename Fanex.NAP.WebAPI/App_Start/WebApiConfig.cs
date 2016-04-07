namespace Fanex.NAP.WebAPI
{
    using System.Web.Http;
    using Fanex.NAP.WebAPI.Configurations;
    using Fanex.NAP.WebAPI.Filters;
    using log4net.Config;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}");

            config.Routes.MapHttpRoute(
              name: "UserOneLevelNested",
              routeTemplate: "api/{controller}/{userId}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional },
              constraints: new { controller = "user" });

            config.Routes.MapHttpRoute(
             name: "SiteOneLevelNested",
             routeTemplate: "api/{controller}/{siteId}/{action}/{id}",
             defaults: new { id = RouteParameter.Optional },
             constraints: new { controller = "site" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Filters.Add(new GlobalExceptionFilterAttr());

            if (NAPAPIConfiguration.Settings.EnableLogging)
            {
                config.Filters.Add(new LogInfoFilterAttr());
                XmlConfigurator.Configure();
            }
        }
    }
}