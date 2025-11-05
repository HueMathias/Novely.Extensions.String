using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Vérifie si la chaîne est une URL valide (http, https ou ftp).
    /// </summary>
    /// <param name="input">Chaîne à vérifier.</param>
    /// <returns><see langword="true"/> si la chaîne est une URL valide, sinon <see langword="false"/>.</returns>
    public static bool IsUrl(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        const string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
        return Regex.IsMatch(input.Trim(), pattern, RegexOptions.IgnoreCase);
    }
}
