using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Numeric
{
    [TestFixture]
    public class DivisibleByThreeTests
    {
        [TestCaseSource(typeof(ExampleDivisibleByThree), "Valid")]
        public void Matches(string word)
        {
            var regex = DivisibleByThree.DecimalDivisibleByThreeRegex;
            var match = regex.Match(word);
            Assert.IsTrue(match.Success);
        }

        [TestCaseSource(typeof(ExampleDivisibleByThree), "Invalid")]
        public void DoesNotMatch(string word)
        {
            var regex = DivisibleByThree.DecimalDivisibleByThreeRegex;
            var match = regex.Match(word);
            Assert.IsFalse(match.Success);
        }
    }
}
