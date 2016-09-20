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
            var captures = match.Groups["A"].Captures.Count;
            Assert.IsTrue(match.Success);
            //Assert.AreEqual(81*3, captures);
            Assert.AreEqual(0, captures);
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
    }
}
