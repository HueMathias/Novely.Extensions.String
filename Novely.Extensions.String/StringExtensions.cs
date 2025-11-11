using System;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
	///  Capitalizes the first letter.
	/// </summary>
	/// <param name="input">string</param>
	/// <returns>The same string with the first letter capitalized.</returns>
	public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => string.Empty,
            "" => string.Empty,
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}
