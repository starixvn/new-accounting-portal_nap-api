namespace Fanex.NAP.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get site by ID criteria.
    /// </summary>
    public class GetByIdSiteCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Site_GetById";
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