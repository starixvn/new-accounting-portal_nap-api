namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get menu item by name and site criteria.
    /// </summary>
    public class GetByNameAndSiteMenuItemCriteria : CriteriaBase
    {
        public string MenuItemName { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_MenuItem_GetByNameAndSite";
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