namespace Fanex.NAP.Core.Service.Interface
{
    public interface IServiceContext
    {
        int UserId { get; set; }

        int SiteId { get; set; }

        string Ip { get; set; }
    }
}