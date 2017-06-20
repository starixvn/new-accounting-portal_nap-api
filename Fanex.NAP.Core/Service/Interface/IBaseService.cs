namespace Fanex.NAP.Core.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Criteria.Misc;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public interface IBaseService
    {
        IServiceContext ServiceContext { get; set; }

        IEnumerable<T> GetData<T>(ICriteria criteria);

        T GetItem<T>(ICriteria criteria) where T : new();

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        LogExecSpCriteria GetLogExecSpCriteria();
    }
}