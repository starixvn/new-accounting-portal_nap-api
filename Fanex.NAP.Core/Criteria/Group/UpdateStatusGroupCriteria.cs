// --------------------------------------------------------------------------
// <copyright file="UpdateStatusGroupCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2012.8.20">Created</change>
// </history>

namespace Fanex.NAP.Core.Criteria.Group
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// Update group status criteria.
    /// </summary>
    public class UpdateStatusGroupCriteria : CriteriaBase
    {
        public int GroupId { get; set; }

        public bool IsActive { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Group_UpdateStatus";
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