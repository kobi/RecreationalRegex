using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobi.RecreationalRegex.RegexUtilities;

namespace Kobi.RecreationalRegex.Parentheses
{
    [TestFixture]
    public class Tests
    {
        [TestCase(Examples.MixedParethesesSeveralTokens)]
        [TestCase(Examples.MixedParetheses2)]
        public void Matches(string word)
        {
            var matches = Parentheses.BalancedParenthesesRegex.Matches(word);
            CollectionAssert.IsNotEmpty(matches);
            matches.PrintMatchesValues();
        }
    }
}
