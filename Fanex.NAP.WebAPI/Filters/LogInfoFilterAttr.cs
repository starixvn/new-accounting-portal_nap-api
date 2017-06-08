namespace Fanex.NAP.WebAPI.Filters
{
    using System.Reflection;
    using System.Text;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Extensions;
    using log4net;
    using Newtonsoft.Json;

    public class LogInfoFilterAttr : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var message = string.Join(
                "\r\n",
                string.Format("Controller: {0}, Action: {1} is executing.", actionContext.ActionDescriptor.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName),
                "Client IP: " + actionContext.Request.GetClientIpAddress(),
                "Url: " + actionContext.Request.RequestUri.OriginalString,
                "Body: " + actionContext.Request.GetBodyForm(),
                string.Empty);

            Logger.Info(message);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var messageBuilder = new StringBuilder();
            var exception = actionExecutedContext.Exception;

            if (exception != null)
            {
                messageBuilder.AppendFormat("ExceptionMessage: {0}", exception.Message).AppendLine();
                messageBuilder.AppendFormat("Type: {0}", exception.GetType()).AppendLine();
                messageBuilder.AppendFormat("Source: {0}", exception.Source).AppendLine();
                messageBuilder.AppendFormat("StackTrace: {0}", exception.StackTrace).AppendLine();
            }
            else
            {
                var responseObj = JsonConvert.DeserializeObject(actionExecutedContext.Response.Content.ReadAsStringAsync().Result);
                messageBuilder.AppendFormat("ResponseData: {0}", responseObj?.ToString()).AppendLine();
            }

            Logger.Info(messageBuilder.ToString());
        }
    }
}