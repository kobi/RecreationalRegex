using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobi.RecreationalRegex.RegexUtilities;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.WordLengths
{
    public abstract class LengthsTestBase
    {
        [TestCase(Examples.ShortText, TestName = "ShortText")]
        [TestCase(Examples.LongText, TestName = "LongText")]
        public void Matches(string text)
        {
            Console.WriteLine("Input is:");
            Console.WriteLine(text);
            Console.WriteLine();

            var r = Regex;
            var matches = r.Matches(text);
            Assert.IsNotEmpty(matches);
            matches.PrintMatchesValues();
        }

        public abstract Regex Regex { get; }
    }

    public class ShortWordLongWord : LengthsTestBase
    {
        public override Regex Regex
        {
            get { return Simple.ShortWordLongWordRegex; }
        }
    }

    public class LongerWordLengthsRegex : LengthsTestBase
    {
        public override Regex Regex
        {
            get { return Simple.LongerWordLengthsRegex; }
        }
    }

    public class FibonacciCaptureThreeWordsEnforceLengthRegex : LengthsTestBase
    {
        public override Regex Regex
        {
            get { return Fibonacci.CaptureThreeWordsEnforceLengthRegex; }
        }
    }

    public class FibonacciCaptureSeriesAllLookaheadRegex : LengthsTestBase
    {
        public override Regex Regex
        {
            get { return Fibonacci.CaptureSeriesAllLookaheadRegex; }
        }
    }
}
