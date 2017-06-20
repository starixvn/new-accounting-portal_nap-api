namespace Fanex.NAP.Core.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Search group exclude function criteria.
    /// </summary>
    public class SearchGroupExcludeFunctionCriteria : CriteriaBase
    {
        public string GroupName { get; set; }

        public int SiteId { get; set; }

        public int FunctionId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Group_SearchExcludeFunction";
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