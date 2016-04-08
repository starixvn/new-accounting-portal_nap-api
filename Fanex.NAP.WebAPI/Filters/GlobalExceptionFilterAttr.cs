namespace Fanex.NAP.WebAPI.Filters
{
    using System;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Web.Http.Filters;
    using Enyim.Caching;
    using Fanex.Data;
    using Fanex.NAP.WebAPI.Extensions;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class GlobalExceptionFilterAttr : ExceptionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext != null)
            {
                var exception = actionExecutedContext.Exception;
                var messageBuilder = new StringBuilder();

                messageBuilder.AppendFormat("Message: {0}", exception.Message).AppendLine();
                messageBuilder.AppendFormat("Type: {0}", exception.GetType().ToString()).AppendLine();
                messageBuilder.AppendFormat("Source: {0}", exception.Source).AppendLine();
                messageBuilder.AppendFormat("Client IP: {0}", actionExecutedContext.Request.GetClientIpAddress()).AppendLine();
                messageBuilder.AppendFormat("Url: {0}", actionExecutedContext.Request.RequestUri.OriginalString).AppendLine();
                messageBuilder.AppendFormat("Body: {0}", actionExecutedContext.Request.GetBodyForm()).AppendLine();

                LogDatabaseException(exception, messageBuilder);

                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messageBuilder.ToString());
            }
        }

        private void LogDatabaseException(Exception exception, StringBuilder messageBuilder)
        {
            var objectDbException = exception as ObjectDbException;

            if (objectDbException != null)
            {
                messageBuilder.AppendFormat("Procedure: {0}", objectDbException.DbSetting.SpName).AppendLine();
                messageBuilder.AppendFormat("DB Name: {0}", objectDbException.DbSetting.DbName).AppendLine();

                if (objectDbException.InnerException is SqlException)
                {
                    var innerSqlException = objectDbException.InnerException as SqlException;
                    messageBuilder.AppendFormat("Server: {0}", innerSqlException.Server).AppendLine();
                    messageBuilder.AppendFormat("Line Number: {0}", innerSqlException.LineNumber).AppendLine();
                }
            }
        }
    }
}