namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get user by group and site criteria.
    /// </summary>
    public class GetByGroupAndSiteUserCriteria : CriteriaBase
    {
        public int GroupId { get; set; }

        public int SiteId { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_GetByGroupAndSite";
        }

        /// <summary>
        /// Check data constraints.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}