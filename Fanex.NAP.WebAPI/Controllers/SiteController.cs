namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Core.Domain;
    using Core.Model.ValueObject;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Filters;

    [NAPAuthorizationFilter]
    public class SiteController : ApiController
    {
        private readonly ISiteService _siteService;
        private readonly IMenuItemService _menuItemService;

        public SiteController()
            : this(null, null)
        {
        }

        public SiteController(ISiteService siteService, IMenuItemService menuItemService)
        {
            _siteService = siteService ?? new SiteService();
            _menuItemService = menuItemService ?? new MenuItemService();
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

        [HttpGet]
        public IEnumerable<IMenuItem> MenuItem(int siteId, string environment, bool? isActive = null)
        {
            return _menuItemService.GetBySite(siteId, environment, isActive);
        }
    }
}