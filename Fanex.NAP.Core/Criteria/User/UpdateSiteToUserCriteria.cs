// -----------------------------------------------------------------------
// <copyright file="UpdateSiteToUserCriteria.cs" company="Nexcel Solutions Viet Nam">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// Update site to user criteria.
    /// </summary>
    public class UpdateSiteToUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public int Level { get; set; }

        public bool IsActive { get; set; }

        public DateTime ExpiredDate { get; set; }

        public bool IsNeverExpired { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override string GetSettingKey()
        {
            return "NAP_User_UpdateSite";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}