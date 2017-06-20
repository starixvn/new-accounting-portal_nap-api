namespace Fanex.NAP.Core.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get group by function and site criteria.
    /// </summary>
    public class GetByFunctionAndSiteGroupCriteria : CriteriaBase
    {
        public int FunctionId { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Group_GetGroupByFunctionAndSite";
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