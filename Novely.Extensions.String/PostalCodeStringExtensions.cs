using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Internal dictionary containing regular expressions by culture.
    /// </summary>
    private static readonly Dictionary<string, string> postalCodePatterns = new()
    {
        ["fr-fr"] = @"[0-9]{1}[0-9A-Za-z]{1}[0-9]{3}", // France
        ["en-ca"] = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", // Canada : A1A 1A1 ou A1A-1A1
        ["en-us"] = @"^\d{5}(-\d{4})?$", // États-Unis : 5 chiffres + optionnel -4
        ["en-gb"] = @"^(GIR ?0AA|[A-Z]{1,2}\d[A-Z\d]? ?\d[ABD-HJLNP-UW-Z]{2})$", // Royaume-Uni : formats variés (simplifié)
        ["de-de"] = @"^\d{5}$", // Allemagne : 5 chiffres
        ["es-es"] = @"^\d{5}$", // Espagne : 5 chiffres
        ["it-it"] = @"^\d{5}$", // Italie : 5 chiffres
        ["nl-be"] = @"^\d{4}$" // Belgique : 4 chiffres
    };

    /// <summary>
    /// Checks whether a string matches the expected postal code format for a given crop.
    /// </summary>
    /// <param name="input">Please verify the postal code.</param>
    /// <param name="culture">Culture to use to determine the format (e.g., fr-FR, en-US).</param>
    /// <returns><see langword="true"/> if the postal code is valid for the given crop, otherwise<see langword="false"/>.</returns>
    public static bool IsPostalCode(this string input, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        string cultureCode = culture?.Name?.ToLowerInvariant() ?? "fr-fr";

        if (!postalCodePatterns.TryGetValue(cultureCode, out var pattern))
        {
            pattern = postalCodePatterns["fr-fr"];
        }

        return Regex.IsMatch(input.Trim(), pattern);
    }

    /// <summary>
    /// Checks whether a string matches the expected postal code format according to the current thread culture.
    /// </summary>
    /// <param name="input">Please verify the postal code.</param>
    /// <returns><see langword="true"/>if the postal code is valid, otherwise <see langword="false"/>.</returns>
    public static bool IsPostalCode(this string input) => input.IsPostalCode(CultureInfo.CurrentCulture);

    /// <summary>
    /// Saves or replaces a regular expression pattern for a specific culture.
    /// </summary>
    /// <param name="cultureCode">Country code (e.g., “US-US”).</param>
    /// <param name="pattern">Regular expression matching the postal code format.</param>
    /// <exception cref="ArgumentException">If the settings are invalid.</exception>
    public static void RegisterPostalCodePattern(string cultureCode, string pattern)
    {
        if (string.IsNullOrEmpty(cultureCode))
            throw new ArgumentException("The culture code cannot be empty.", nameof(cultureCode));

        if (string.IsNullOrEmpty(pattern))
            throw new ArgumentException("The regex pattern cannot be empty.", nameof(pattern));

        postalCodePatterns[cultureCode.ToLowerInvariant()] = pattern;
    }
}