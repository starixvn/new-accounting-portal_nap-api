namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get menu item by user and site include group criteria.
    /// </summary>
    public class GetByUserAndSiteIncludeGroupMenuItemCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_MenuItem_GetByUserAndSiteIncludeGroup";
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