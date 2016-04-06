namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Fanex.NAP.Core.Model.ValueObject;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using Fanex.NAP.WebAPI.Filters;
    using Core.Domain;
    [NAPAuthorizationFilter]
    public class SiteController : ApiController
    {
        private ISiteService _siteService;
        private IMenuItemService _menuItemService;

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
        public IEnumerable<IMenuItem> MenuItem(int siteId, string enviroment, bool? isActive = null)
        {
            return _menuItemService.GetBySite(siteId, enviroment, isActive);
        }
    }
}