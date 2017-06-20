namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using Core.Business;
    using Core.Criteria.User;
    using Core.Service.Impl;
    using Core.Service.Interface;

    public class ReCheckInController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ISiteService _siteService;

        public ReCheckInController()
            : this(null, null)
        {
        }

        public ReCheckInController(
            IUserService userService,
            ISiteService siteService)
        {
            _userService = userService ?? new UserService();
            _siteService = siteService ?? new SiteService();
        }

        [HttpGet]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        public int Get(int onUserId, int siteId)
        {
            //// Site Status Checking
            var siteStatus = _siteService.GetStatusById(siteId);

            if (!siteStatus)
            {
                return (int)Constant.ReCheckInResult.KickedOut;
            }

            //// Online user checking
            var criteria = new UserReCheckInUserCriteria
            {
                OnUserId = onUserId
            };

            _userService.ReUserCheckIn(criteria);

            if (criteria.IsKickedOut)
            {
                return (int)Constant.ReCheckInResult.KickedOut;
            }

            return (int)Constant.ReCheckInResult.Ok;
        }
    }
}