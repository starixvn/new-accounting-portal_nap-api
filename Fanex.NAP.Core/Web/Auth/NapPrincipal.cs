namespace Fanex.NAP.Core.Web.Auth
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;

    public class NapPrincipal : IPrincipal
    {
        private readonly IIdentity _identity;
        private readonly AuthInfo _authInfo;

        public NapPrincipal(IIdentity identity, AuthInfo authInfo)
        {
            this._identity = identity;
            this._authInfo = authInfo;
        }

        public NapPrincipal(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (HttpContext.Current.User.Identity is FormsIdentity && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpCookie httpCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (httpCookie == null)
                {
                    return;
                }

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);
                if (ticket == null || ticket.Expired || string.IsNullOrEmpty(ticket.UserData))
                {
                    return;
                }

                this._authInfo = AuthInfo.CreateUserData(ticket.UserData);
                this._identity = new FormsIdentity(ticket);
            }
        }

        public AuthInfo AuthInfo
        {
            get { return this._authInfo; }
        }

        public IIdentity Identity
        {
            get { return this._identity; }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}