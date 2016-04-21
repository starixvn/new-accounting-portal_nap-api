namespace Fanex.NAP.WebAPI.Controllers
{
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Service.Impl;
    using Fanex.NAP.Core.Service.Interface;
    using Fanex.NAP.WebAPI.Filters;
    using System.Web.Http;

    [NAPAuthorizationFilter]
    public class GroupController : ApiController
    {
        private IGroupService _groupService;

        public GroupController()
            : this(null)
        {
        }

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService ?? new GroupService();
        }

        public IGroup Get(int id)
        {
            return _groupService.GetById(id);
        }
    }
}