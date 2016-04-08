namespace Fanex.NAP.WebAPI.Controllers
{
    using Fanex.NAP.Core.Criteria.User;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using System.Web.Http;

    public class LoginController : ApiController
    {
        private IUserService _userService;

        public LoginController()
            : this(null)
        {
        }

        public LoginController(IUserService userService)
        {
            _userService = userService ?? new UserService();
        }

        [HttpPost]
        public int Login([FromBody]UserCheckInUserCriteria criteria)
        {
            _userService.UserCheckIn(criteria);

            return criteria.OnUserId;
        }
    }
}