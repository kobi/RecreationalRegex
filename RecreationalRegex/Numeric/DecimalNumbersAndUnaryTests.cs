using NUnit.Framework;

namespace Kobi.RecreationalRegex.Numeric
{
    [TestFixture]
    public class DecimalNumbersAndUnaryTests
    {
        [TestCaseSource(typeof(ExampleDecimalNumbersAndUnary), "Valid")]
        public void Matches(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndUnaryRegex;
            var match = regex.Match(word);
            Assert.IsTrue(match.Success);
        }

        [TestCaseSource(typeof(ExampleDecimalNumbersAndUnary), "Invalid")]
        public void DoesNotMatch(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndUnaryRegex;
            var match = regex.Match(word);
            Assert.IsFalse(match.Success);
        }
    }
}
