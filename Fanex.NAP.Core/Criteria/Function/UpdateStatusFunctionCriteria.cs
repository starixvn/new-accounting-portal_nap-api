namespace Fanex.NAP.Core.Criteria.Function
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// Update function status criteria.
    /// </summary>
    public class UpdateStatusFunctionCriteria : CriteriaBase
    {
        public int FunctionId { get; set; }

        public bool IsActive { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_UpdateStatus";
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