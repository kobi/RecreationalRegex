using NUnit.Framework;

namespace Kobi.RecreationalRegex.Numeric
{
    [TestFixture]
    public class DecimalAndBinaryTests
    {
        [TestCaseSource(typeof(ExampleDecimalAndBinary), "Valid")]
        public void Matches(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndEqualBinaryNumberRegex;
            var match = regex.Match(word);
            Assert.IsTrue(match.Success);
        }

        [TestCaseSource(typeof(ExampleDecimalAndBinary), "Invalid")]
        public void DoesNotMatch(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndEqualBinaryNumberRegex;
            var match = regex.Match(word);
            Assert.IsFalse(match.Success);
        }
    }
}
