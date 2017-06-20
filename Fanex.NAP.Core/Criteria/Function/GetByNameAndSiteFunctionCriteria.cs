namespace Fanex.NAP.Core.Criteria.Function
{
    using Data.Repository;

    /// <summary>
    /// Get function by function name and site criteria.
    /// </summary>
    public class GetByNameAndSiteFunctionCriteria : CriteriaBase
    {
        public string FunctionName { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetByNameAndSite";
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