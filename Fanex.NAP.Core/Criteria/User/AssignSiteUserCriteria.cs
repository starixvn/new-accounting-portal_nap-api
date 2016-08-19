// --------------------------------------------------------------------------
// <copyright file="AssignSiteUserCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2012.8.21">Created</change>
// </history>

namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// Assign site to user criteria.
    /// </summary>
    public class AssignSiteUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public int Level { get; set; }

        public bool IsActive { get; set; }

        public bool IsNeverExpired { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string GetSettingKey()
        {
            return "NAP_User_AssignNewSite";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}