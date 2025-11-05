namespace Novely.Extensions.String.Tests;

public class StringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("", "")]
    [TestCase("test", "Test")]
    [TestCase("Test", "Test")]
    [TestCase("tEST", "TEST")]
    [TestCase("école", "École")]
    [TestCase("1test", "1test")]
    [TestCase(" test", " test")]
    public void FirstCharToUpper_ShouldReturnExpectedResult(string input, string expected)
    {
        var result = input.FirstCharToUpper();
        Assert.That(result, Is.EqualTo(expected));
    }
}
