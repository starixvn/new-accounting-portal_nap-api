namespace Fanex.NAP.WebAPI.Filters
{
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Fanex.NAP.WebAPI.Extensions;
    using log4net;

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
    }
}