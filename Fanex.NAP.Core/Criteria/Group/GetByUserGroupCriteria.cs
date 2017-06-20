namespace Fanex.NAP.Core.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get group by user criteria.
    /// </summary>
    public class GetByUserGroupCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Group_GetByUser";
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