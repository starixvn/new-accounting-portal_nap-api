namespace Fanex.NAP.WebAPI.Controllers
{
    using Core.Command;
    using Core.Configuration;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Core.Web.Context;
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
                ServiceContext = InitServiceContext()
            };
        }

        [HttpPost]
        public bool UpdatePassword(int onUserId, [FromBody]UpdatePasswordCustCriteria criteria)
        {
            _userService.ServiceContext.UserId = onUserId;

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

        private IServiceContext InitServiceContext()
        {
            IServiceContext serviceContext = new ServiceContext();
            serviceContext.Ip = (new CurrentContext()).IP;
            serviceContext.SiteId = NapSettings.Settings.SiteId;

            return serviceContext;
        }
    }
}