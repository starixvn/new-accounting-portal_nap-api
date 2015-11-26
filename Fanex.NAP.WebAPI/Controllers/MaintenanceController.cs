namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Fanex.NAP.Core.Model.ValueObject;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using Fanex.NAP.WebAPI.Filters;

    [NAPAuthorizationFilter]
    public class MaintenanceController : ApiController
    {
        private IMaintenanceService _maintenanceService;

        public MaintenanceController()
            : this(null)
        {
        }

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService ?? new MaintenanceService();
        }

        [HttpGet]
        public Downtime Get()
        {
            return _maintenanceService.GetDowntimeInfo();
        }
    }
}