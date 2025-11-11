using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Check if the string is a valid URL (http, https, ftp, ws, or wss).
    /// </summary>
    /// <param name="input">Chain to be checked.</param>
    /// <returns><see langword="true"/>if the string is a valid URL, otherwise<see langword="false"/>.</returns>
    public static bool IsUrl(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        const string pattern = @"^(https?|ftp|wss?)://[^\s/$.?#].[^\s]*$";
        return Regex.IsMatch(input.Trim(), pattern, RegexOptions.IgnoreCase);
    }
}
