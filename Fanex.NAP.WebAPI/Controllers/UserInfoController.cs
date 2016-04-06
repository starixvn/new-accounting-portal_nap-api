namespace Fanex.NAP.WebAPI.Controllers
{
    using Core.Command;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using System.Web.Http;

    public class UserInfoController : ApiController
    {
        private IUserService _userService;

        public UserInfoController()
            : this(null)
        {
        }

        public UserInfoController(IUserService userService)
        {
            _userService = userService ?? new UserService();
        }

        [HttpPost]
        public bool UpdatePassword([FromBody]UpdatePasswordCustCriteria criteria)
        {
            ICommandResult result = _userService.ChangePassword(criteria);
            return result.IsSuccessful;
        }

    }
}
