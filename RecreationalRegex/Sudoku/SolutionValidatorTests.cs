using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Kobi.RecreationalRegex.Sudoku
{
    [TestFixture]
    class SolutionValidatorTests
    {
        [TestCaseSource(typeof(ExampleSolutions), nameof(ExampleSolutions.Valid))]
        public void CountCaptures(string solution)
        {
            var match = SolutionValidator.SudokuValidator.Match(solution);
            var captures = match.Groups["S"].Captures.Count;
            Assert.IsTrue(match.Success);
            Assert.AreEqual(81*3, captures);
        }

        [TestCaseSource(typeof (ExampleSolutions), nameof(ExampleSolutions.Valid))]
        public void IsValid(string solution)
        {
            var match = SolutionValidator.SudokuValidator.Match(solution);
            Assert.IsTrue(match.Success);
        }

        [TestCaseSource(typeof (ExampleSolutions), nameof(ExampleSolutions.Invalid))]
        public void Invalid(string solution)
        {
            var match = SolutionValidator.SudokuValidator.Match(solution);
            Assert.IsFalse(match.Success);
        }

        [TestCaseSource(typeof (ExampleSolutions), nameof(ExampleSolutions.Invalid))]
        public void PrintCaptures(string solution)
        {
            var match = SolutionValidator.SudokuValidator.Match(solution);
            if (match.Success)
            {
                var groups = match.Groups["S"].Captures.Cast<Capture>()
                    .Select((c, i) => new {Digit = c.Value, i})
                    .GroupBy(g => g.i/9, g => g.Digit, (i, g) => String.Concat(g))
                    .ToList();

                foreach (var group in groups)
                {
                    Console.Write(group);
                    if (group.Distinct().Count() < group.Length)
                    {
                        Console.Write(" !");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Assert.Fail("Should not match this string");
            }
        }
    }
}
