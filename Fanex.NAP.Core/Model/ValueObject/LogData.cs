namespace Fanex.NAP.Core.Model.ValueObject
{
    /// <summary>
    /// Log data model.
    /// </summary>
    public class LogData
    {
        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }
    }
}