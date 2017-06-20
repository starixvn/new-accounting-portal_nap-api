namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// Insert new user criteria.
    /// </summary>
    public class InsertUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int GroupId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_Insert";
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