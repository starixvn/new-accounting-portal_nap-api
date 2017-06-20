namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Web;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Get menu item by site criteria.
    /// </summary>
    public class GetBySiteMenuItemCriteria : CriteriaBase
    {
        [Required]
        [Display(Name = "Site", ResourceType = typeof(ViewResources))]
        public int SiteId { get; set; }

        [Display(Name = "Environment", ResourceType = typeof(ViewResources))]
        public string Environment { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_MenuItem_GetBySite";
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