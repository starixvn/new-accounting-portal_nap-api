namespace Fanex.NAP.Core.Criteria.Function
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get function by user criteria.
    /// </summary>
    public class GetByUserFunctionCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetByUser";
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