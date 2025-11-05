using System.Globalization;
using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Vérifie si la chaîne correspond à un numéro de téléphone valide pour une culture donnée.
    /// </summary>
    /// <param name="input">Numéro à vérifier.</param>
    /// <param name="culture">Culture à utiliser (ex: fr-FR, en-US). Si null, la culture actuelle est utilisée.</param>
    /// <returns><see langword="true"/> si le numéro est valide pour la culture donnée, sinon <see langword="false"/>.</returns>
    public static bool IsPhoneNumber(this string input, CultureInfo? culture = null)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        culture ??= CultureInfo.CurrentCulture;
        string code = culture.Name.ToLowerInvariant();

        string pattern = code switch
        {
            "fr-fr" => @"^(0|\+33)[1-9](\d{2}){4}$",           // France
            "en-us" => @"^\+?1?\d{10}$",                       // USA
            "en-gb" => @"^(\+44|0)7\d{9}$",                    // UK
            "en-ca" => @"^\+?1?\s?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", // Canada
            _ => @"^\+?[0-9\s\-()]{6,}$"                       // Par défaut : tolérant
        };

        return Regex.IsMatch(input.Trim(), pattern);
    }
}
