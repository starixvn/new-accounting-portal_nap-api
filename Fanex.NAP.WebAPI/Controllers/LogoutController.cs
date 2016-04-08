namespace Fanex.NAP.WebAPI.Controllers
{
    using Fanex.NAP.Core.Criteria.User;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;

    public class LogoutController : ApiController
    {
        private IUserService _userService;

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