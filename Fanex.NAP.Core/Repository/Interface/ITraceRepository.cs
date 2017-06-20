namespace Fanex.NAP.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Command;
    using Fanex.NAP.Core.Criteria.Trace;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Linq;

    public interface ITraceRepository : IDynamicRepository
    {
        IQueryable<LogExecSp> SearchLogExecSp(GetAllLogCriteria criteria);

        IQueryable<LogUserLogin> SearchLogUserLogin(GetAllLogUserLoginCriteria criteria);

        IQueryable<LogFunction> SearchLogFunction(GetAllLogFunctionCriteria criteria);

        LogExecSp GetById(ICriteria criteria);

        ICommandResult InsertLog(ICriteria criteria);
    }
}