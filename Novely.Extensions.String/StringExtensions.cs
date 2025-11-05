using System;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
	/// Met la première lettre en majuscule.
	/// </summary>
	/// <param name="input">Chaîne de caractères</param>
	/// <returns>La même chaîne de caractères avec la première lettre en majuscule.</returns>
	public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => string.Empty,
            "" => string.Empty,
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}
