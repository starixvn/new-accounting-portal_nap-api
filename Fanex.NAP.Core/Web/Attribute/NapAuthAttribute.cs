namespace Fanex.NAP.Core.Web.Attribute
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Auth;
    using Business;
    using Configuration;
    using Service.Impl;
    using Service.Interface;

    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class NapAuthAttribute : AuthorizeAttribute
    {
        #region Member

        private static readonly int _SiteId = NapSettings.Settings.SiteId;

        private static readonly IUserService UserService = new UserService();

        #endregion Member

        #region Properties

        private string _functionKey;

        private Constant.Policy _policy;

        public string FunctionKey
        {
            get
            {
                return _functionKey ?? string.Empty;
            }

            set
            {
                _functionKey = value;
            }
        }

        public Constant.Policy Policy
        {
            get
            {
                return _policy == Constant.Policy.None ? Constant.Policy.Read : _policy;
            }

            set
            {
                _policy = value;
            }
        }

        #endregion Properties

        /// <summary>
        /// Authorize action handler.
        /// </summary>
        /// <param name="filterContext">Filter context.</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext == null)
            {
                CloseConnection(filterContext);
                return;
            }

            // why it is null?
            var principal = filterContext.HttpContext.User as NapPrincipal;

            if (principal == null)
            {
                principal = new NapPrincipal(filterContext.HttpContext);
            }

            if (ReferenceEquals(principal, null) || ReferenceEquals(principal.AuthInfo, null))
            {
                CloseConnection(filterContext);
                return;
            }

            if (CheckFunctionAuthorization(principal.AuthInfo.UserId))
            {
                // allow access
                // log access function here
                // write log function here (pending due to performance)
            }
            else
            {
                CloseConnection(filterContext);
            }
        }

        /// <summary>
        /// Check function authorization.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>True : has permission, false : not.</returns>
        public bool CheckFunctionAuthorization(int userId)
        {
            if (userId <= 0)
            {
                return false;
            }

            int policy = UserService.GetUserSiteFunctionKeyPolicy(userId, _SiteId, FunctionKey);

            return policy >= (int)Policy;
        }

        /// <summary>
        /// Close connection.
        /// </summary>
        /// <param name="filterContext">Filter context.</param>
        private static void CloseConnection(AuthorizationContext filterContext)
        {
            if (filterContext == null
                || filterContext.HttpContext == null
                || filterContext.HttpContext.Request == null)
            {
                SignOut();
                return;
            }

            HttpResponseBase response = filterContext.HttpContext.Response;

            if (response == null)
            {
                SignOut();
                return;
            }

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new HttpStatusCodeResult(403, "<center><b>" + ViewResources.UnauthorizeMsg + "</b></center>");

                response.Buffer = true;
                response.StatusCode = 403; // Unauthorized status code
                response.Write("<center><b>" + ViewResources.UnauthorizeMsg + "</b></center>");
                response.Flush();
                response.Close();
                response.End();
            }
            else if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                SignOut();
            }
            else
            {
                string settingUrl = NapSettings.Settings.UnauthorizeUrl;
                filterContext.Result = new RedirectResult(string.IsNullOrWhiteSpace(settingUrl) ? "~/Admin/Common/Unauthorize" : settingUrl);
            }
        }

        private static void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}