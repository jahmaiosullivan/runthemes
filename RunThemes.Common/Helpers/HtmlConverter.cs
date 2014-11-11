using System;
using System.Text.RegularExpressions;
using System.Web;

namespace RunThemes.Common.Helpers
{
    /// <summary>
    /// Converts HTML
    /// </summary>
    public static class HtmlConverter
    {
        private static readonly Regex ParagraphMarks = new Regex("(<br/?>)|(</p>)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        private static readonly Regex Tags = new Regex("<[^>]*>", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Multiline);
        
        /// <summary>
        /// Converts HTML to plain text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Plain text as string</returns>
        public static string ConvertToText(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            
            value = ParagraphMarks.Replace(value, Environment.NewLine);
            value = Tags.Replace(value, String.Empty);
                
            return HttpUtility.HtmlDecode(value);
        }
    }
}