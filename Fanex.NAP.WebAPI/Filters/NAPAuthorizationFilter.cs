namespace Fanex.NAP.WebAPI.Filters
{
    using System;
    using System.Collections.Concurrent;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Caching;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Caching;
    using Core.Service.Impl;
    using Core.Service.Interface;

    public class NAPAuthorizationFilter : AuthorizationFilterAttribute
    {
        private const string CacheKey = "Fanex.NAP.WebAPI.CacheKey";
        private const long RequestMaxAgeInSeconds = 300;
        private const string TokenAuthenticationScheme = "amx";
        private readonly ICache _cache;
        private readonly ISiteService _siteService;

        public NAPAuthorizationFilter()
            : this(null, null)
        {
        }

        public NAPAuthorizationFilter(ICache cache, ISiteService siteService)
        {
            _siteService = siteService ?? new SiteService();
            _cache = cache ?? CacheService.CreateInstance(CacheType.MemoryCache);
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var tempPrincipal = new GenericPrincipal(new GenericIdentity("4"), null);
            Thread.CurrentPrincipal = tempPrincipal;

            return;
        }

        private static void HandleUnauthorizedRequest(HttpActionContext actionContext)
            => actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

        private static string[] GetAutherizationHeaderValues(string rawAuthzHeader)
        {
            var credArray = rawAuthzHeader.Split(':');

            return credArray.Length == 4 ? credArray : null;
        }

        private bool IsValidRequest(HttpRequestMessage req, string siteId, string incomingBase64Signature, string nonce, string requestTimeStamp)
        {
            string requestContentBase64String = string.Empty;
            string requestUri = HttpUtility.UrlEncode(req.RequestUri.AbsoluteUri.ToLowerInvariant());
            string requestHttpMethod = req.Method.Method;

            var allowedApps = _cache.Get<ConcurrentDictionary<string, string>>(CacheKey);
            allowedApps = allowedApps ?? new ConcurrentDictionary<string, string>();

            if (!allowedApps.ContainsKey(siteId))
            {
                var site = _siteService.GetById(Convert.ToInt32(siteId));

                if (site != null)
                {
                    allowedApps.AddOrUpdate(siteId, site.SecretAccessKey, (k, v) => v);
                    _cache.Set(CacheKey, allowedApps);
                }
                else
                {
                    return false;
                }
            }

            var sharedKey = allowedApps[siteId];

            if (IsReplayRequest(nonce, requestTimeStamp))
            {
                return false;
            }

            byte[] hash = ComputeHash(req.Content);

            if (hash != null)
            {
                requestContentBase64String = Convert.ToBase64String(hash);
            }

            string data = string.Format("{0}{1}{2}{3}{4}{5}", siteId, requestHttpMethod, requestUri, requestTimeStamp, nonce, requestContentBase64String);

            var secretKeyBytes = Convert.FromBase64String(sharedKey);

            byte[] signature = Encoding.UTF8.GetBytes(data);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);

                return incomingBase64Signature.Equals(Convert.ToBase64String(signatureBytes), StringComparison.Ordinal);
            }
        }

        private static bool IsReplayRequest(string nonce, string requestTimeStamp)
        {
            if (MemoryCache.Default.Contains(nonce))
            {
                Fanex.Logging.Logger.Log.Info("MemoryCache.Default.Contains(nonce)");
                return true;
            }

            var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            var currentTimeSpan = DateTime.UtcNow - epochStart;

            var serverTotalSeconds = Convert.ToUInt64(currentTimeSpan.TotalSeconds);
            var requestTotalSeconds = Convert.ToUInt64(requestTimeStamp);
            var deltaRequestSeconds = ((long)serverTotalSeconds - (long)requestTotalSeconds);
            if (deltaRequestSeconds > RequestMaxAgeInSeconds)
            {
                Fanex.Logging.Logger.Log.Info($"deltaRequestSeconds:{deltaRequestSeconds}. serverTotalSeconds:{serverTotalSeconds}.requestTotalSeconds:{requestTotalSeconds}.RequestMaxAgeInSeconds:{RequestMaxAgeInSeconds}");
                Fanex.Logging.Logger.Log.Info($"serverTime:{DateTime.UtcNow}. clientTime:{epochStart.AddSeconds(requestTotalSeconds)}");
                return true;
            }

            MemoryCache.Default.Add(nonce, requestTimeStamp, DateTimeOffset.UtcNow.AddSeconds(RequestMaxAgeInSeconds));

            return false;
        }

        private static byte[] ComputeHash(HttpContent httpContent)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = null;
                var content = httpContent.ReadAsByteArrayAsync().Result;

                if (content.Length != 0)
                {
                    hash = md5.ComputeHash(content);
                }

                return hash;
            }
        }
    }
}