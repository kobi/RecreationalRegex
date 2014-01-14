using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Numeric
{
    [TestFixture]
    public class DecimalNumbersAndUnaryTests
    {
        [TestCaseSource(typeof(ExampleDecimalNumbersAndUnary), "Valid")]
        public void Matches(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndUnaryPatternRegex;
            var match = regex.Match(word);
            Assert.IsTrue(match.Success);
        }

        [TestCaseSource(typeof(ExampleDecimalNumbersAndUnary), "Invalid")]
        public void DoesNotMatch(string word)
        {
            var regex = ParseNumbers.DecimalNumberAndUnaryPatternRegex;
            var match = regex.Match(word);
            Assert.IsFalse(match.Success);
        }
    }
}
