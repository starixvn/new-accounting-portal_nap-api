namespace Fanex.NAP.WebAPI.Controllers
{
    using Core.Command;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Core.Web.Session;
    using System.Web;
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
            _userService = userService ?? new UserService()
            {
                ServiceContext = new ServiceContext()
            };
        }

        [HttpPost]
        public bool UpdatePassword([FromBody]UpdatePasswordCustCriteria criteria)
        {
            ICommandResult result = _userService.ChangePassword(criteria);
            return result.IsSuccessful;
        }

        [HttpPost]
        public bool UpdateProfile(int onUserId, [FromBody]UpdateCustCriteria criteria)
        {
            _userService.ServiceContext.UserId = onUserId;

            var result = _userService.InsertOrUpdate(criteria);
            return result.IsSuccessful;
        }
    }
}