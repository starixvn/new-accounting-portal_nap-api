namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Fanex.NAP.Core.Criteria.User;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;

    public class SSOLoginController : ApiController
    {
        private IUserService _userService;

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
        public int Login([FromBody]UserSSOCheckInUserCriteria criteria)
        {
            _userService.UserSSOCheckIn(criteria);

            return criteria.OnUserId;
        }
    }
}
