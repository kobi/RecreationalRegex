using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Mazes
{
    [TestFixture]
    public class Tests
    {
        public Tests()
        {
            MazeSolver = Mazes.MazeSolverRegex;
        }

        public Regex MazeSolver {get;private set;}

        [TestCase(ExampleMazes.SimpleDown, TestName = "Simple Down")]
        [TestCase(ExampleMazes.SimpleLeft, TestName = "Simple Left")]
        [TestCase(ExampleMazes.SimpleRight, TestName = "Simple Right")]
        [TestCase(ExampleMazes.SimpleUp, TestName = "Simple Up")]
        [TestCase(ExampleMazes.SimpleRightFull, TestName = "Simple Right - Start to End")]
        [TestCase(ExampleMazes.MedDownRight, TestName = "Medium - Down and Right")]
        [TestCase(ExampleMazes.BigGood, TestName = "Big")]
        [TestCase(ExampleMazes.BigGood2, TestName = "Big 2")]
        [TestCase(ExampleMazes.Small, TestName = "Medium")]
        public void ShouldMatch(string maze)
        {
            Console.WriteLine(maze);

            var match = MazeSolver.Match(maze);

            Console.WriteLine("Solution:");
            Console.WriteLine(match.ShowPath());
        }

        [TestCase(ExampleMazes.SmallNoSolution, TestName = "Medium - No Solution")]
        [TestCase(ExampleMazes.BigBad, TestName = "Big - No Solution")]
        [TestCase(ExampleMazes.BigBad2, TestName = "Big2 - No Solution")]
        public void ShouldNotMatch(string maze)
        {
            Console.WriteLine(maze);
            var match = MazeSolver.Match(maze);
            Assert.IsFalse(match.Success);
        }

    }
}
