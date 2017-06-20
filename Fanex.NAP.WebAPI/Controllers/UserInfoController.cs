namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Core.Command;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Core.Web.Context;
    using Filters;

    [NAPAuthorizationFilter]
    public class UserInfoController : ApiController
    {
        private readonly IUserService _userService;

        public UserInfoController()
            : this(null)
        {
        }

        public UserInfoController(IUserService userService)
        {
            _userService = userService ?? new UserService
            {
                ServiceContext = InitServiceContext()
            };
        }

        [HttpPost]
        public bool UpdatePassword(int siteId, int userId, string password)
        {
            _userService.ServiceContext.UserId = userId;
            _userService.ServiceContext.SiteId = siteId;

            var criteria = new UpdatePasswordCustCriteria
            {
                CustId = userId,
                UserPwd = password
            };

            ICommandResult result = _userService.ChangePassword(criteria);
            return result.IsSuccessful;
        }

        [HttpPost]
        public bool UpdateProfile(int siteId, [FromBody]UpdateCustCriteria criteria)
        {
            _userService.ServiceContext.UserId = criteria.CustId;
            _userService.ServiceContext.SiteId = siteId;

            var result = _userService.InsertOrUpdate(criteria);
            return result.IsSuccessful;
        }

        private static IServiceContext InitServiceContext()
        {
            IServiceContext serviceContext = new ServiceContext();
            serviceContext.Ip = (new CurrentContext()).IP;

            return serviceContext;
        }
    }
}