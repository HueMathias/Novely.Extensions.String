using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Vérifie si la chaîne est une adresse e-mail valide.
    /// </summary>
    /// <param name="input">Chaîne à vérifier.</param>
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
