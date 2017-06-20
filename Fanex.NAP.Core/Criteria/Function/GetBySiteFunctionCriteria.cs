namespace Fanex.NAP.Core.Criteria.Function
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get function by site criteria.
    /// </summary>
    public class GetBySiteFunctionCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        public string Environment { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetBySite";
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