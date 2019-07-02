namespace Fanex.NAP.Core.Criteria.Function
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Business;
    using Fanex.NAP.Core.Web;

    public class CopyPermissionCriteria : CriteriaBase
    {
        public CopyPermissionCriteria()
        {
            this.Environment = Constant.Uat;
        }

        public int FromFunctionId { get; set; }

        public int ToFunctionId { get; set; }

        public int SiteId { get; set; }

        [SpParam(Ignored = true)]
        public string ToFunctionName { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [Display(Name = "Environment", ResourceType = typeof(ViewResources))]
        public string Environment { get; set; }

        [SpParam(Ignored = true)]
        public int ReturnSiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_Function_CopyPermission";
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