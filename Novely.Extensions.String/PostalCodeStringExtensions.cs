using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Dictionnaire interne contenant les expressions régulières par culture.
    /// </summary>
    private static readonly Dictionary<string, string> postalCodePatterns = new()
    {
        ["fr-fr"] = @"^[0-9]{1}[0-9A-Za-z]{1}[0-9]{3}$", // France
        ["en-ca"] = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", // Canada : A1A 1A1 ou A1A-1A1
        ["en-us"] = @"^\d{5}(-\d{4})?$", // États-Unis : 5 chiffres + optionnel -4
        ["en-gb"] = @"^(GIR ?0AA|[A-Z]{1,2}\d[A-Z\d]? ?\d[ABD-HJLNP-UW-Z]{2})$", // Royaume-Uni : formats variés (simplifié)
        ["de-de"] = @"^\d{5}$", // Allemagne : 5 chiffres
        ["es-es"] = @"^\d{5}$", // Espagne : 5 chiffres
        ["it-it"] = @"^\d{5}$", // Italie : 5 chiffres
        ["nl-be"] = @"^\d{4}$" // Belgique : 4 chiffres
    };

    /// <summary>
    /// Vérifie si une chaîne correspond au format du code postal attendu pour une culture donnée.
    /// </summary>
    /// <param name="input">Code postal à vérifier.</param>
    /// <param name="culture">Culture à utiliser pour déterminer le format (ex: fr-FR, en-US).</param>
    /// <returns><see langword="true"/> si le code postal est valide pour la culture donnée, sinon <see langword="false"/>.</returns>
    public static bool IsPostalCode(this string input, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        // Normalisation du code culture (minuscule, ex: "fr-fr")
        string cultureCode = culture?.Name?.ToLowerInvariant() ?? "fr-fr";

        // Recherche du pattern correspondant
        if (!postalCodePatterns.TryGetValue(cultureCode, out var pattern))
        {
            pattern = postalCodePatterns["fr-fr"];
        }

        return Regex.IsMatch(input.Trim(), pattern);
    }

    /// <summary>
    /// Vérifie si une chaîne correspond au format du code postal attendu selon la culture actuelle du thread.
    /// </summary>
    /// <param name="input">Code postal à vérifier.</param>
    /// <returns><see langword="true"/> si le code postal est valide, sinon <see langword="false"/>.</returns>
    public static bool IsPostalCode(this string input) => input.IsPostalCode(CultureInfo.CurrentCulture);

    /// <summary>
    /// Enregistre ou remplace un modèle d’expression régulière pour une culture spécifique.
    /// </summary>
    /// <param name="cultureCode">Code de culture (ex: "fr-FR").</param>
    /// <param name="pattern">Expression régulière correspondant au format du code postal.</param>
    /// <exception cref="ArgumentException">Si les paramètres sont invalides.</exception>
    public static void RegisterPostalCodePattern(string cultureCode, string pattern)
    {
        if (string.IsNullOrEmpty(cultureCode))
            throw new ArgumentException("Le code culture ne peut pas être vide.", nameof(cultureCode));

        if (string.IsNullOrEmpty(pattern))
            throw new ArgumentException("Le modèle regex ne peut pas être vide.", nameof(pattern));

        postalCodePatterns[cultureCode.ToLowerInvariant()] = pattern;
    }
}