namespace Fanex.NAP.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Update default site URL criteria.
    /// </summary>
    public class UpdateDefaultSiteUrlCriteria : CriteriaBase
    {
        public int SiteUrlId { get; set; }

        public int SiteId { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Site_UpdateDefaultSiteURL";
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