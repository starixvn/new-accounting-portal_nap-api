namespace Fanex.NAP.Core.Web
{
    using System;

    /// <summary>
    /// Contains date extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        public const string ShortDateFormat = "MM/dd/yyyy";
        public const string ShortMonthFormatedDate = "dd MMM yyyy";

        /// <summary>
        /// Format a DateTime value to short date format, separated by '-'.
        /// </summary>
        /// <param name="date">DateTime type that the method needs to be attached to.</param>
        /// <returns>Formatted date such as 2013-10-10.</returns>
        public static string ToShortFormatedDate(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToShortFormatedDate();
            }

            return string.Empty;
        }

        /// <summary>
        /// Format a DateTime value to short date format, separated by '-'.
        /// </summary>
        /// <param name="date">DateTime type that the method needs to be attached to.</param>
        /// <returns>Formatted date such as 2013-10-10.</returns>
        public static string ToShortFormatedDate(this DateTime date)
        {
            return date.ToString(ShortDateFormat);
        }

        public static string ToShortMonthFormatedDate(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToShortFormatedDate();
            }

            return string.Empty;
        }

        public static string ToShortMonthFormatedDate(this DateTime date)
        {
            return date.ToString(ShortMonthFormatedDate);
        }
    }
}