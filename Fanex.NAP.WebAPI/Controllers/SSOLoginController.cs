namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;

    public class SSOLoginController : ApiController
    {
        private readonly IUserService _userService;

        public SSOLoginController()
            : this(null)
        {
        }

        public SSOLoginController(IUserService userService)
        {
            _userService = userService ?? new UserService();
        }

        [HttpGet]
        public string GetTime()
        {
            return _userService.UserSSOGetTime();
        }

        [HttpPost]
        public int Login([FromBody] UserSSOCheckInUserCriteria criteria)
        {
            _userService.UserSSOCheckIn(criteria);
            SiteLogger.Sites.Add(criteria.SiteId);

            return criteria.OnUserId;
        }
    }
}