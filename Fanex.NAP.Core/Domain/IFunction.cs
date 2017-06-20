namespace Fanex.NAP.Core.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public interface IFunction : IEntity<short, string>
    {
        string Key { get; set; }

        string Description { get; set; }

        IFunction Parent { get; set; }

        short DisplayOrder { get; set; }

        bool IsActive { get; set; }

        byte Crud { get; set; }

        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Reviewed")]
        bool Readonly { get; }

        string Environment { get; set; }

        ISite Site { get; set; }

        IUser Creator { get; set; }

        DateTime CreatedDate { get; set; }

        IUser Modifier { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}