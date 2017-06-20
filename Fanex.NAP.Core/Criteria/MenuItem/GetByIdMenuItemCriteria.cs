namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get menu item by ID criteria.
    /// </summary>
    public class GetByIdMenuItemCriteria : CriteriaBase
    {
        public int MenuItemId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "NAP_MenuItem_GetById";
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