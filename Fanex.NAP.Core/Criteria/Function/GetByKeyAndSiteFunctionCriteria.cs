namespace Fanex.NAP.Core.Criteria.Function
{
    using Data.Repository;

    /// <summary>
    /// Get function by function key and site criteria.
    /// </summary>
    public class GetByKeyAndSiteFunctionCriteria : CriteriaBase
    {
        public string FunctionKey { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetByKeyAndSite";
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