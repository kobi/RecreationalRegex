using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobi.RecreationalRegex;
using System.Text.RegularExpressions;
using Kobi.RecreationalRegex.RegexUtilities;

namespace Kobi.RecreationalRegex
{
    public abstract class Tests
    {
        [TestCaseSource(typeof(Kobi.RecreationalRegex.PcreGrammar.Examples), "Valid")]
        public virtual void ShouldMatch(string word)
        {
            Assert.IsTrue(GrammarRegex.IsMatch(word));
        }

        [TestCaseSource(typeof(Kobi.RecreationalRegex.PcreGrammar.Examples), "Invalid")]
        public virtual void ShouldNotMatch(string word)
        {
            Assert.IsFalse(GrammarRegex.IsMatch(word));
        }

        public abstract Regex GrammarRegex
        {
            get;
        }
    }

    [TestFixture]
    public class WrongRegexTests : Tests
    {
        public override Regex GrammarRegex
        {
            get
            {
                return Kobi.RecreationalRegex.PcreGrammar.PcreGrammar.LatestAttempt; 
            }
        }
    } 
    
    [TestFixture]
    public class WrongRegexFirstAttemptTests : Tests
    {
        public override Regex GrammarRegex
        {
            get
            {
                return Kobi.RecreationalRegex.PcreGrammar.PcreGrammar.FirstAttempt; 
            }
        }
    }

    public class NumberedStatesTests : Tests
    {
        private Regex _regex = PcreGrammar.PcreGrammar.NumberedStatesPcreGrammarRegex();

        public override Regex GrammarRegex
        {
            get
            {
                return _regex;
            }
        }
    }
    
    public class NumberedStatesAndCapturesTests : Tests
    {
        private Regex _regex = PcreGrammar.PcreGrammar.NumberedStatesPcreGrammarWithCapturesRegex();

        public override Regex GrammarRegex
        {
            get
            {
                return _regex;
            }
        }

        [TestCaseSource(typeof(Kobi.RecreationalRegex.PcreGrammar.Examples), "Valid")]
        public override void ShouldMatch(string word)
        {
            var match = GrammarRegex.Match(word);
            Assert.IsTrue(match.Success);
            match.PrintAllCapturesToConsole(GrammarRegex);
        }
    }
}
