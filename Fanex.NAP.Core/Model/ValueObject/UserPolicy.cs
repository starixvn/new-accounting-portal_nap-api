namespace Fanex.NAP.Core.Model.ValueObject
{
    using System;

    /// <summary>
    /// User policy model.
    /// </summary>
    public class UserPolicy
    {
        public int Policy { get; set; }

        public User User { get; set; }

        public User Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public User Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}