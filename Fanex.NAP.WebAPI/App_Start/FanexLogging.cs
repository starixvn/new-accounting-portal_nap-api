using Fanex.Logging;
using Fanex.Logging.Sentry.RavenClient;
using SharpRaven;
using System.Collections.Generic;
using System.Configuration;

namespace Fanex.NAP.WebAPI.App_Start
{
    public static class FanexLogging
    {
        public static void Register()
        {
            LogManager
                .SetDefaultLogCategory(ConfigurationManager.AppSettings["SiteCategory"])
                .Use(new List<ILogEngine>
                {
                    new SentryLogging(new SentryEngineOptions
                    {
                        Dsn = new Dsn(ConfigurationManager.AppSettings["SentryToken"])
                    })
                });
        }
    }
}