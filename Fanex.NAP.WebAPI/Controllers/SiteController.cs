namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Fanex.NAP.Core.Model.ValueObject;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using Fanex.NAP.WebAPI.Filters;

    [NAPAuthorizationFilter]
    public class SiteController : ApiController
    {
        private ISiteService _siteService;

        public SiteController()
            : this(null)
        {
        }

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService ?? new SiteService();
        }

        [HttpGet]
        public bool Status(int siteId)
        {
            return _siteService.GetStatusById(siteId);
        }

        [HttpGet]
        public IEnumerable<SiteUrl> SiteUrl(int siteId, string environment)
        {
            return _siteService.GetSiteUrlBySiteId(siteId, environment);
        }
    }
}