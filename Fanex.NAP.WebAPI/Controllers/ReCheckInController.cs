namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using Fanex.NAP.Core.Business;
    using Fanex.NAP.Core.Criteria.User;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;

    public class ReCheckInController : ApiController
    {
        private IUserService _userService;
        private IMaintenanceService _maintenanceService;
        private ISiteService _siteService;

        public ReCheckInController()
            : this(null, null, null)
        {
        }

        public ReCheckInController(
            IUserService userService,
            IMaintenanceService maintenanceService,
            ISiteService siteService)
        {
            _userService = userService ?? new UserService();
            _maintenanceService = maintenanceService ?? new MaintenanceService();
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