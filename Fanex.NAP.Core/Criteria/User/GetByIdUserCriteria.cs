namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get user by ID criteria.
    /// </summary>
    public class GetByIdUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_GetById";
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