namespace Fanex.NAP.Core.Command
{
    /// <summary>
    /// Command result base.
    /// </summary>
    public class CommandResultBase : ICommandResult
    {
        private dynamic _code;
        private dynamic _message;

        public CommandResultBase()
            : this(string.Empty, string.Empty)
        {
        }

        public CommandResultBase(dynamic code, dynamic message)
        {
            this._code = code;
            this._message = message;
        }

        public dynamic Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public dynamic Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public virtual bool IsSuccessful
        {
            get { return true; }
        }
    }
}