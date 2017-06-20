namespace Fanex.NAP.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Command;
    using Fanex.NAP.Core.Criteria.Function;
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Collections.Generic;

    public interface IFunctionRepository : IReadonlyRepository<IFunction>
    {
        IEnumerable<FunctionPolicy> FetchFunctionPolicy(ICriteria criteria);

        IEnumerable<FunctionPolicy> FetchFullFunctionPolicy(ICriteria criteria);

        ICommandResult Duplicate(DuplicateFunctionCriteria criteria, ICriteria logCriteria);

        ICommandResult Insert(InsertFunctionCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);
    }
}