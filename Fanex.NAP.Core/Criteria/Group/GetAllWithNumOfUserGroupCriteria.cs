namespace Fanex.NAP.Core.Criteria.Group
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Web;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Get all group with number of user criteria.
    /// </summary>
    public class GetAllWithNumOfUserGroupCriteria : CriteriaBase
    {
        public bool? IsActive { get; set; }

        [Display(Name = "Group_Name", ResourceType = typeof(ViewResources))]
        [StringLength(50, MinimumLength = 0,
            ErrorMessageResourceName = "InputLengthValidationMsg",
            ErrorMessageResourceType = typeof(ViewResources))]
        public string GroupName { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Group_GetAllWithNumOfUser";
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