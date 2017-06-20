namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// SSO get time user criteria.
    /// </summary>
    public class UserSSOGetTimeUserCriteria : CriteriaBase
    {
        public DateTime Time { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_SSOGetTime";
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