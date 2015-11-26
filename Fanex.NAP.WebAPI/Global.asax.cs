namespace Fanex.NAP.WebAPI
{
    using System;
    using System.Data.SqlClient;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Fanex.Data.Configuration;
    using Fanex.Logging;
    using Newtonsoft.Json.Serialization;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DbSettingProviderManager.Current.Start();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            ((DefaultContractResolver)GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver).IgnoreSerializableAttribute = true;
        }

        /// <summary>
        /// Application error event handler.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // Logging
            if (Server != null)
            {
                Exception ex = Server.GetLastError().GetBaseException();

                // Get base exception data
                string message = ex.Message +
                    "\r\nType: " + ex.GetType().ToString() +
                    "\r\nSource: " + ex.Source +
                    "\r\nTarget Site: " + ex.TargetSite +
                    "\r\nStack Trace: " + ex.StackTrace;

                // Get additional exception data
                SqlException sqlException = ex as SqlException;

                if (sqlException == null && ex.InnerException != null)
                {
                    sqlException = ex.InnerException as SqlException;
                }

                if (sqlException != null)
                {
                    message += "\r\nProcedure: " + sqlException.Procedure +
                        "\r\nLine Number: " + sqlException.LineNumber +
                        "\r\nServer: " + sqlException.Server;
                }

                LogService.Error(message);
            }
        }
    }
}