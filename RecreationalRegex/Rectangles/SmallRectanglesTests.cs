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
            var wholeString = BuildInput(line1, line2, canvas);
            ShouldMatch(wholeString);
        }

        private static string BuildInput(string rectangle1, string rectangle2, string canvas)
        {
            return $"{rectangle1}\n\n{rectangle2}\n\n{canvas}\n\n";
        }

        [TestCaseSource(typeof(Examples), nameof(Examples.ShouldNotMatch))]
        public void ShouldNotMatch(string input)
        {
            Console.WriteLine(input);
            var match = SmallRectangles.RectanglesRegex.Match(input);
            Assert.IsFalse(match.Success);
        }

        public static readonly string[] EvenLengthsRectangles = {"11", "1111", "11\n11", "1\n1", "111\n111"};

        /// <summary>
        /// This is just a quick way to generate non-matching input. Even length rectangles and odd length canvas.
        /// </summary>
        [Test, Pairwise]
        public void SimpleNoMatches(
            [ValueSource(nameof(EvenLengthsRectangles))]string rectangle1,
            [ValueSource(nameof(EvenLengthsRectangles))]string rectangle2, 
            [Values("~","~~~", "~~~~~\n~~~~~\n~~~~~", "~~~\n~~~\n~~~")]string canvas)
        {
            var wholeString = BuildInput(rectangle1, rectangle2, canvas);
            ShouldNotMatch(wholeString);
        }

        private void AssertDistinctCapturesLengths(Match match, string group) =>
            CollectionAssert.AllItemsAreUnique(match.Groups[group].GetCaptures().Select(c => c.Value.Length),
                $"group <{group}> lengths are not distinct");
    }
}
