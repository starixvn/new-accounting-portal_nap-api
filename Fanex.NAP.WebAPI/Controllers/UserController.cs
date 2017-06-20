namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Core.Domain;
    using Core.Model.ValueObject;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Filters;

    [NAPAuthorizationFilter]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ISiteService _siteService;
        private readonly IMenuItemService _menuItemService;
        private readonly IFunctionService _functionService;

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
        public IUser Get(string username)
        {
            return _userService.GetByUsername(username);
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

        [HttpGet]
        public IEnumerable<FunctionPolicy> FunctionPolicies(int userId, int siteId, int parentFunctionId, string environment)
        {
            var functionPolicy = _functionService.GetByUserAndSiteIncludeGroup(userId, siteId, environment);

            if (parentFunctionId == 0)
            {
                return functionPolicy;
            }

            return functionPolicy.Where(f => f.Function.Parent?.Id == parentFunctionId);
        }
    }
}