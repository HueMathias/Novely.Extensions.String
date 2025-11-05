using System.Globalization;

namespace Novely.Extensions.String.Tests;

public class PhoneNumberStringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("+33612345678", "fr-FR", true)]
    [TestCase("0612345678", "fr-FR", true)]
    [TestCase("0778123455", "fr-FR", true)]
    [TestCase("", "fr-FR", false)]
    [TestCase("12345", "fr-FR", false)]
    [TestCase("12345", "fr-FR", false)]
    [TestCase("+14165551234", "en-CA", true)]
    public void IsPhoneNumber_ShouldValidateByCulture(string input, string culture, bool expected)
    {
        var ci = new CultureInfo(culture);
        Assert.That(input.IsPhoneNumber(ci), Is.EqualTo(expected));
    }
}
