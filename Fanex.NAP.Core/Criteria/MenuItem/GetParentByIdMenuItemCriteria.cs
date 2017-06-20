namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get parent menu item by ID criteria.
    /// </summary>
    public class GetParentByIdMenuItemCriteria : CriteriaBase
    {
        public int MenuItemId { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_MenuItem_GetParentById";
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