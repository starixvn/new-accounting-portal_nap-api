namespace Fanex.NAP.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Command;
    using Fanex.NAP.Core.Criteria.Group;
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Collections.Generic;

    public interface IGroupRepository : IReadonlyRepository<IGroup>
    {
        ICommandResult Insert(InsertGroupCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);

        IEnumerable<GroupPolicy> GetGroupPolicy(ICriteria criteria);
    }
}