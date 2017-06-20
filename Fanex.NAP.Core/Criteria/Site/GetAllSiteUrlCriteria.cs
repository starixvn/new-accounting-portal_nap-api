namespace Fanex.NAP.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get all site URL criteria.
    /// </summary>
    public class GetAllSiteUrlCriteria : CriteriaBase
    {
        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Site_GetAllSiteUrl";
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