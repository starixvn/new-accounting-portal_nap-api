namespace Fanex.NAP.Core.Criteria.Trace
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Web;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Get all log criteria.
    /// </summary>
    public class GetAllLogCriteria : CriteriaBase
    {
        [Display(Name = "Modified By")]
        public string Username { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd,yyyy}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd,yyyy}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        [Display(Name = "Filter", ResourceType = typeof(ViewResources))]
        public int FilterType { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_LogExecSp_Search";
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