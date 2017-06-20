namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get user function policy criteria.
    /// </summary>
    public class GetUserFunctionPolicyUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int FunctionId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_GetUserFunctionPolicy";
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