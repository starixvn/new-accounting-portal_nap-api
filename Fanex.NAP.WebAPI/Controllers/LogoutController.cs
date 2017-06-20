namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;

    public class LogoutController : ApiController
    {
        private readonly IUserService _userService;

        public LogoutController()
            : this(null)
        {
        }

        public LogoutController(IUserService userService)
        {
            _userService = userService ?? new UserService();
        }

        [HttpPost]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        public void Logout([FromBody]int onUserId)
        {
            _userService.UserLogOut(new LogOutUserCriteria
            {
                OnUserId = onUserId
            });
        }
    }
}