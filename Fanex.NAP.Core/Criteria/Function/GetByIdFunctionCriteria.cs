namespace Fanex.NAP.Core.Criteria.Function
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get function by ID criteria.
    /// </summary>
    public class GetByIdFunctionCriteria : CriteriaBase
    {
        public int FunctionId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetById";
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