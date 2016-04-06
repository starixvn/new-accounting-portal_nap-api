namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Model;
    using Fanex.NAP.Core.Model.ValueObject;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using Fanex.NAP.WebAPI.Filters;

    [NAPAuthorizationFilter]
    public class UserController : ApiController
    {
        private IUserService _userService;
        private ISiteService _siteService;
        private IMenuItemService _menuItemService;
        private IFunctionService _functionService;

        public UserController()
            : this(null, null, null, null)
        {
        }

        public UserController(IUserService userService, ISiteService siteService, IMenuItemService menuItemService, IFunctionService functionService)
        {
            _userService = userService ?? new UserService();
            _siteService = siteService ?? new SiteService();
            _menuItemService = menuItemService ?? new MenuItemService();
            _functionService = functionService ?? new FunctionService();
        }

        [HttpGet]
        public IUser Get(int id)
        {
            return _userService.GetById(id);
        }

        [HttpGet]
        public User Get(string username)
        {
            return (User)_userService.GetByUsername(username);
        }

        [HttpGet]
        public IEnumerable<IUser> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        public int LevelOnSite(int userId, int id)
        {
            return _userService.GetUserSiteLevel(userId, id);
        }

        [HttpGet]
        public int SitePolicy(int userId, int siteId, string functionKey)
        {
            return _userService.GetUserSiteFunctionKeyPolicy(userId, siteId, functionKey);
        }

        [HttpGet]
        public IEnumerable<SiteLevel> SiteLevel(int userId, string environment)
        {
            return _siteService.GetSiteLevelByUser(userId, environment);
        }

        [HttpGet]
        public IEnumerable<IMenuItem> MenuItem(int userId, int siteId, string environment, bool? isActive = true)
        {
            return _menuItemService.GetByUserAndSiteIncludeGroup(userId, siteId, environment, isActive);
        }

        [HttpGet]
        public bool FunctionPolicy(int userId, int siteId, string environment)
        {
            var functionPolicy = _functionService.GetByUserAndSiteIncludeGroup(userId, siteId, environment);

            return functionPolicy.Any();
        }

  
    }
}