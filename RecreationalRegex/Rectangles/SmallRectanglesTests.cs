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
            var match = SmallRectangles.RectanglesRegex.Match(input);
            Assert.IsTrue(match.Success);
            
            AssertDistinctCapturesLengths(match, "Index");
            AssertDistinctCapturesLengths(match, "NextPos");

            match.PrintAllCapturesToConsole(SmallRectangles.RectanglesRegex);
        }

        [TestCaseSource(typeof(Examples), nameof(Examples.ShouldNotMatch))]
        public void ShouldNotMatch(string input)
        {
            var match = SmallRectangles.RectanglesRegex.Match(input);
            Assert.IsFalse(match.Success);
        }


        private void AssertDistinctCapturesLengths(Match match, string group) =>
            CollectionAssert.AllItemsAreUnique(match.Groups[group].GetCaptures().Select(c => c.Value.Length),
                $"group <{group}> lengths are not distinct");
    }
}
