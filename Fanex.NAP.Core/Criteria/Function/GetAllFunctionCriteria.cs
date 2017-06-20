namespace Fanex.NAP.Core.Criteria.Function
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get all function criteria.
    /// </summary>
    public class GetAllFunctionCriteria : CriteriaBase
    {
        public string Environment { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_GetAll";
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