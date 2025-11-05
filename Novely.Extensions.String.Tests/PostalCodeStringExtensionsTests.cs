using System.Globalization;

namespace Novely.Extensions.String.Tests;

public class PostalCodeStringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("75001", "fr-FR", true)]    // Format FR
    [TestCase("7500155", "fr-FR", false)]  // Mauvais format FR
    [TestCase("13001", "fr-FR", true)]
    [TestCase("H2X1Y4", "en-CA", true)]   // Format canadien
    [TestCase("H0H0H0", "en-CA", true)]
    [TestCase("12345", "en-US", true)]    // Format américain
    [TestCase("ABCDE", "en-US", false)]   // Mauvais format US
    [TestCase("", "fr-FR", false)]        // Vide
    public void IsPostalCode_WithCulture_ShouldReturnExpectedResult(string input, string cultureCode, bool expected)
    {
        var ci = new CultureInfo(cultureCode);
        var result = input.IsPostalCode(ci);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsPostalCode_WithNullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;
        var ci = new CultureInfo("fr-FR");

        // Act
        var result = input.IsPostalCode(ci);

        // Assert
        Assert.That(result, Is.False);
    }


    [Test]
    public void IsPostalCode_WithoutCulture_ShouldUseCurrentCulture()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
        var result = "75015".IsPostalCode();
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPostalCode_WithoutCulture_ShouldFallbackToFRIfUnknown()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("xx-XX");
        var result = "75015".IsPostalCode();
        Assert.That(result, Is.True);
    }

    [Test]
    public void RegisterPostalCodePattern_ShouldAddOrReplacePattern()
    {
        const string cultureCode = "de-DE";
        const string pattern = @"^\d{5}$"; // Ex : 12345

        StringExtensions.RegisterPostalCodePattern(cultureCode, pattern);

        Assert.Multiple(() =>
        {
            Assert.That("10115".IsPostalCode(new CultureInfo(cultureCode)), Is.True);
            Assert.That("ABCDE".IsPostalCode(new CultureInfo(cultureCode)), Is.False);
        });
    }

    [Test]
    public void RegisterPostalCodePattern_ShouldThrowIfCultureCodeIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => StringExtensions.RegisterPostalCodePattern("", @"^\d{5}$"));
    }

    [Test]
    public void RegisterPostalCodePattern_ShouldThrowIfPatternIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => StringExtensions.RegisterPostalCodePattern("fr-FR", ""));
    }
}
