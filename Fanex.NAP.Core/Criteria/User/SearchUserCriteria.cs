namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Search user criteria.
    /// </summary>
    public class SearchUserCriteria : CriteriaBase
    {
        public string Username { get; set; }

        public int GroupId { get; set; }

        public int SiteId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public int Status { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_Search";
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