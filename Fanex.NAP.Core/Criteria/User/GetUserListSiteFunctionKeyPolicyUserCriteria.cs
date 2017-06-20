namespace Fanex.NAP.Core.Criteria.User
{
    using Fanex.Data.Repository;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Get user list site function key policy criteria.
    /// </summary>
    public class GetUserListSiteFunctionKeyPolicyUserCriteria : CriteriaBase
    {
        private readonly string _siteTml = "<Site SiteId='{0}'></Site>";

        public int UserId { get; set; }

        /// <summary>
        /// Gets site list string.
        /// </summary>
        /// <value>
        /// <ROOT>
        ///     <Site SiteId="1"></Site>
        ///     <Site SiteId="2"></Site>
        /// </ROOT>.
        /// </value>
        public string Site
        {
            get
            {
                if (this.ListSite != null)
                {
                    var value = new StringBuilder("<ROOT>");

                    foreach (var siteId in this.ListSite)
                    {
                        value.AppendFormat(this._siteTml, siteId.Value); // 1 -> read
                    }

                    return value.Append("</ROOT>").ToString();
                }

                return string.Empty;
            }
        }

        [SpParam(Ignored = true)]
        public List<SelectListItem> ListSite { get; set; }

        public string FunctionKey { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_User_GetUserListSiteFunctionKeyPolicy";
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