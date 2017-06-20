namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// SSO check in user criteria.
    /// </summary>
    public class UserSSOCheckInUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public string NetSessionId { get; set; }

        public int CheckOnUserId { get; set; }

        public int OnUserId { get; set; }

        public string IP { get; set; }

        public DateTime LoginDate { get; set; }

        [SpParam(Ignored = true)]
        public string Doing { get; set; }

        [SpParam(Ignored = true)]
        public string Domain { get; set; }

        [SpParam(Ignored = true)]
        public string BrowserName { get; set; }

        [SpParam(Ignored = true)]
        public string Platform { get; set; }

        [SpParam(Ignored = true)]
        public string CountryCode { get; set; }

        [SpParam(Ignored = true)]
        public int Duration { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_SSOCheckIn";
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