namespace Fanex.NAP.WebAPI.Controllers
{
    using System.Web.Http;
    using Core.Domain;
    using Core.Service.Impl;
    using Core.Service.Interface;
    using Filters;

    [NAPAuthorizationFilter]
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

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