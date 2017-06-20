namespace Fanex.NAP.Core.Criteria.Trace
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get log by ID criteria.
    /// </summary>
    public class GetByIdLogCriteria : CriteriaBase
    {
        public int LogId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_LogExecSp_GetById";
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