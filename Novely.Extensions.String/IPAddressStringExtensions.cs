using System.Text.RegularExpressions;

namespace Novely.Extensions.String;

public static partial class StringExtensions
{
    /// <summary>
    /// Check if the string is a valid IPv4 address.
    /// </summary>
    public static bool IsIPv4(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        const string pattern = @"^((25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)(\.|$)){4}$";
        return Regex.IsMatch(input.Trim(), pattern);
    }

    /// <summary>
    /// Check if the string is a valid IPv6 address.
    /// </summary>
    public static bool IsIPv6(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return IPAddress.TryParse(input.Trim(), out var address) && address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
    }

    /// <summary>
    /// Check if the string is a valid IP address (IPv4 or IPv6).
    /// </summary>
    public static bool IsIpAddress(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return input.IsIPv4() || input.IsIPv6();
    }
}
