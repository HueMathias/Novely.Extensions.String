namespace Novely.Extensions.String.Tests;

public class UrlStringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("https://google.com", true)]
    [TestCase("http://google.com", true)]
    [TestCase("ftp://server.com", true)]
    [TestCase("invalid-url", false)]
    [TestCase("", false)]
    public void IsUrl_ShouldReturnExpectedResult(string input, bool expected)
    {
        Assert.That(input.IsUrl(), Is.EqualTo(expected));
    }
}
