namespace Fanex.NAP.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Update site status criteria.
    /// </summary>
    public class UpdateStatusSiteCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Site_UpdateStatus";
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