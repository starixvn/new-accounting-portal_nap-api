namespace Fanex.NAP.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Command;
    using Fanex.NAP.Core.Criteria.User;
    using Fanex.NAP.Core.Domain;
    using Fanex.NAP.Core.Model.ValueObject;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public interface IUserRepository : IReadonlyRepository<IUser>
    {
        IQueryable<IUser> SearchByUsername(SearchByUsernameUserCriteria criteria);

        IEnumerable<UserLevel> Search(ICriteria criteria);

        IQueryable<UserLevel> Search(SearchUserCriteria criteria);

        IQueryable<UserLevel> GetAllByUsernameGroupSite(GetAllByUsernameGroupSiteUserCriteria criteria);

        IQueryable<UserLevel> SearchUserExcludeFunction(SearchUserExcludeFunctionCriteria criteria);

        IEnumerable<UserPolicy> GetUserPolicy(ICriteria criteria);

        ICommandResult Insert(InsertCustCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        void UserCheckIn(UserCheckInUserCriteria criteria);

        void UserSSOCheckIn(UserSSOCheckInUserCriteria criteria);

        void UserReCheckIn(UserReCheckInUserCriteria criteria);

        void UserLogOut(LogOutUserCriteria criteria);

        Hashtable GetUserListSiteFunctionKeyPolicy(ICriteria criteria);

        string UserSSOGetTime(ICriteria criteria);
    }
}