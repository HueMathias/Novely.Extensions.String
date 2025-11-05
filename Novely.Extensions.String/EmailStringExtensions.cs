using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Check if the string is a valid email address.
    /// </summary>
    /// <param name="input">Chain to be checked.</param>
    /// <returns><see langword="true"/> si l’adresse e-mail est valide, sinon <see langword="false"/>.</returns>
    public static bool IsEmail(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        // Expression régulière standard RFC 5322 simplifiée
        const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(input.Trim(), pattern, RegexOptions.IgnoreCase);
    }
}
