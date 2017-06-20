namespace Fanex.NAP.Core.Command
{
    public interface ICommandResult
    {
        dynamic Code { get; }

        dynamic Message { get; }

        bool IsSuccessful { get; }
    }
}