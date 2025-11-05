namespace Novely.Extensions.String.Tests;

public class EmailStringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("test@example.com", true)]
    [TestCase("invalid@", false)]
    [TestCase("another.test@domain.co", true)]
    [TestCase("   ", false)]
    public void IsEmail_ShouldReturnExpectedResult(string input, bool expected)
    {
        Assert.That(input.IsEmail(), Is.EqualTo(expected));
    }
}