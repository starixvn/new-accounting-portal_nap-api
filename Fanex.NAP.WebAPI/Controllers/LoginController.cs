namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;

    public class LoginController : ApiController
    {
        private readonly IUserService _userService;

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