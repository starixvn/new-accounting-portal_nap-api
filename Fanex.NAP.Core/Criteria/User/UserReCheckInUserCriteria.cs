namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Re-check in user criteria.
    /// </summary>
    public class UserReCheckInUserCriteria : CriteriaBase
    {
        public int OnUserId { get; set; }

        public bool IsKickedOut { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_ReCheckIn";
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