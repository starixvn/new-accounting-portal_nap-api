namespace Fanex.NAP.Core.Service.Interface
{
    using Fanex.NAP.Core.Criteria.Trace;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Linq;

    public interface ITraceService : IBaseService
    {
        LogExecSp GetById(int logId);

        IQueryable<LogExecSp> SearchExecSp(GetAllLogCriteria criteria);

        IQueryable<LogUserLogin> SearchUserLogin(GetAllLogUserLoginCriteria criteria);
    }
}