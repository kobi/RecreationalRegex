using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobi.RecreationalRegex.RegexUtilities;

namespace Kobi.RecreationalRegex.StackOverflowAnswers
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Acronyms()
        {
            var acronyms = StackOverflowAsnwers.FindAcronymsRegex;
            var text = Examples.Acronyms;
            Console.WriteLine("Input text:");
            Console.WriteLine(text);
            Console.WriteLine();

            var matches = acronyms.Matches(text);
            CollectionAssert.IsNotEmpty(matches);
            matches.PrintMatchesValues();
        }

        [TestCase("Hel[*o], w*rld!", "Hel[*o], w%rld!")]
        [TestCase(@"h*H\[el[*o], w*rl\]d! H*]e*l[*o], w*rl[*d*o] [o*] [o*o].", @"h%H\[el[*o], w%rl\]d! H%]e%l[*o], w%rl[*d*o] [o*] [o*o].")]
        [TestCase("H*]e*l[*o], w*rl[*d*o] [o*] [o*o].", "H%]e%l[*o], w%rl[*d*o] [o*] [o*o].")]
        public void ReplaceAsterisksNotInBrackets(string input, string expected)
        {
            var regex = StackOverflowAsnwers.FindAsterisksNotInBracketsRegex;
            string actual = regex.Replace(input, match => match.Groups["Asterisk"].Success ? "%" : match.Value);
            Assert.AreEqual(expected, actual);
        }
    }
}
