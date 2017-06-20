namespace Fanex.NAP.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Command;
    using Fanex.NAP.Core.Criteria.Site;
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Collections.Generic;

    public interface ISiteRepository : IReadonlyRepository<ISite>
    {
        SiteUrl GetSiteUrl(ICriteria criteria);

        IEnumerable<SiteLevel> FetchSiteLevel(ICriteria criteria);

        IEnumerable<SiteUrl> FetchSiteUrl(ICriteria criteria);

        ICommandResult Insert(InsertSiteCriteria criteria, ICriteria logCriteria);

        ICommandResult InsertSiteUrl(InsertSiteUrlCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);
    }
}