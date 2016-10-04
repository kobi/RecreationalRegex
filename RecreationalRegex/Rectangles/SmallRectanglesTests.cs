using System;
using NUnit.Framework;
using Kobi.RecreationalRegex.RegexUtilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Rectangles
{
    public class SmallRectanglesTests
    {
        [TestCaseSource(typeof(Examples), nameof(Examples.ShouldMatch))]
        public void ShouldMatch(string input)
        {
            Console.WriteLine(input);

            var match = SmallRectangles.RectanglesRegex.Match(input);
            Assert.IsTrue(match.Success);
            
            AssertDistinctCapturesLengths(match, "Index");
            AssertDistinctCapturesLengths(match, "NextPos");

            match.PrintAllCapturesToConsole(SmallRectangles.RectanglesRegex);
        }

        [Test]
        [Combinatorial]
        public void SimpleLineRotate(
            [Values("1111", "1\n1\n1\n1")]string line1,
            [Values("2222", "2\n2\n2\n2")]string line2,
            [Values("~~~~\n~~~~", "~~\n~~\n~~\n~~")]string canvas
            )
        {
            var wholeString = $"{line1}\n\n{line2}\n\n{canvas}\n\n";
            ShouldMatch(wholeString);
        }

        [TestCaseSource(typeof(Examples), nameof(Examples.ShouldNotMatch))]
        public void ShouldNotMatch(string input)
        {
            Console.WriteLine(input);
            var match = SmallRectangles.RectanglesRegex.Match(input);
            Assert.IsFalse(match.Success);
        }

        private void AssertDistinctCapturesLengths(Match match, string group) =>
            CollectionAssert.AllItemsAreUnique(match.Groups[group].GetCaptures().Select(c => c.Value.Length),
                $"group <{group}> lengths are not distinct");
    }
}
