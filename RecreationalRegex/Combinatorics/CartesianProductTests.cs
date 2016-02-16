using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Combinatorics
{
    [TestFixture]
    public class CartesianProductTests
    {
        [TestCase("12345","abc")]
        [TestCase("12", "abcde")]
        [TestCase("1", "a")]
        [TestCase("1", "abcde")]
        public void TwoSets(string set1, string set2)
        {
            var expected = from c1 in set1
                           from c2 in set2
                           select Tuple.Create(c1.ToString(), c2.ToString());
            var stringInput = set1 + " " + set2;
            var match = CartesianProduct.TwoSetsCartesianRegex.Match(stringInput);
            var firstCapturedSet = match.Groups["FirstElement"].Captures.Cast<Capture>().ToList();
            var secondCapturedSet = match.Groups["SecondElement"].Captures.Cast<Capture>().ToList();
            Assert.AreEqual(firstCapturedSet.Count(), secondCapturedSet.Count());
            var actual = firstCapturedSet.Zip(secondCapturedSet, (c1, c2) => Tuple.Create(c1.Value, c2.Value));
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}