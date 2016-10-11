using System;
using NUnit.Framework;
using Kobi.RecreationalRegex.RegexUtilities;
using System.Linq;
using System.Text;
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

            PrintCanvas(match);
            PrintSolution(match);
            match.PrintAllCapturesToConsole(SmallRectangles.RectanglesRegex);
        }

        [Test]
        [Combinatorial]
        public void SimpleLineRotate(
            [Values("1111", "1\n1\n1\n1")]string line1,
            [Values("2222", "2\n2\n2\n2")]string line2,
            [Values("~~~~\n~~~~", "~~\n~~\n~~\n~~", "~~~~~~~~", "~\n~\n~\n~\n~\n~\n~\n~")]string canvas
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

        private void PrintSolution(Match match)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Found a solution!");
            var usedRectanglesCount = match.Groups["Rectangle"].Captures.Count;
            for (int i = 0; i < usedRectanglesCount; i++)
            {
                sb.Append(i + 1);
                sb.AppendFormat(". Rectangle number {0}", match.Groups["Index"].Captures[i].Length);
                if (match.Groups["Rotate"].Captures[i].Length == 1)
                {
                    sb.Append(", rotated");
                }
                sb.AppendLine(":");
                sb.AppendLine(match.Groups["Rectangle"].Captures[i].Value).AppendLine();
            }
            Console.WriteLine(sb);
        }

        private void PrintCanvas(Match match)
        {
            //this ugliness is just to visualize the solution.
            Console.WriteLine("Visualized:");
            Console.WriteLine();
            var solutionChars = match.Groups["SolutionChar"].GetCaptures();
            var canvas = Regex.Match(match.Result("$_"), @"~[~\s]+\Z").Value;
            var ordered = match.Groups["Filled"].GetCaptures()
                .Zip(solutionChars, (filled, c) => new {Char = c.Value, Order = filled.Length})
                .OrderBy(c => c.Order).Select(c => c.Char).ToArray();
            int index = 0;
            var solution = Regex.Replace(canvas, @"~", m => ordered[index++]);
            Console.WriteLine(solution);
        }
    }
}
