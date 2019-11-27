using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel.Tests
{
    [TestFixture]
    public class ModelTests
    {
        [Test]
        public void AnBnToString()
        {
            var states = ExampleLanguages.AnBn();
            Print(states);
        }
        
        [Test]
        public void AStarToString()
        {
            var states = ExampleLanguages.AStar();
            Print(states);
        }

        [Test]
        public void PcreGrammarToString()
        {
            var states = PcreGrammar.NumberedStatesPcreGrammarStates();
            Print(states);
        }

        [Test]
        public void PcreGrammarWithCapturesToString()
        {
            var states = PcreGrammar.NumberedStatesPcreGrammarWithCapturesStates();
            Print(states);
        }

        private void Print(IEnumerable<State> states) => 
            TestContext.Progress.WriteLine(String.Join("\n", states));
    }

    [TestFixture]
    public class PatternBuilderTests
    {
        [Test]
        public void AnBnPattern()
        {
            var anbn = ExampleLanguages.AnBn().ToRegex();
            TestContext.Progress.WriteLine("Pattern = \n{0}", anbn);
        }

        [Test]
        public void AStarPattern()
        {
            var anbn = ExampleLanguages.AStar().ToRegex();
            TestContext.Progress.WriteLine("Pattern = \n{0}", anbn);
        }

        [Test]
        public void PcreGrammarPattern()
        {
            var p = PcreGrammar.NumberedStatesPcreGrammarRegex();
            TestContext.Progress.WriteLine("Pattern = \n{0}", p);
        }

        [Test]
        public void PcreGrammarWithCapturesPattern()
        {
            var p = PcreGrammar.NumberedStatesPcreGrammarWithCapturesRegex();
            TestContext.Progress.WriteLine("Pattern = \n{0}", p);
        }
    }

    public class SimpleGrammarsTests
    {
        /// <summary>
        /// A stupid way to chack for <c>s == "a"</c>.
        /// </summary>
        [TestCase("a", true)]
        [TestCase("aa", false)]
        [TestCase("", false)]
        public void A(string word, bool expectedMatch)
        {
            var states = new[] { new State("A", new RegexLiteral("a")) };
            Regex a = states.ToRegex();
            Assert.AreEqual(expectedMatch, a.IsMatch(word));
        }

        /// <summary>
        /// A stupid way to chack for <c>s == "ab"</c>.
        /// </summary>
        [TestCase("a", false)]
        [TestCase("ab", true)]
        [TestCase("abb", false)]
        [TestCase("", false)]
        public void AB(string word, bool expectedMatch)
        {
            var b = new State("B", new RegexLiteral("b"));
            var a = new State("A", new Concat(new RegexLiteral("a"), new PushState(b)));
            var states = new[] { a, b };
            Regex ab = states.ToRegex();
            Assert.AreEqual(expectedMatch, ab.IsMatch(word));
        }


        /// <summary>
        /// A stupid way to chack for <c>s == "a" || s == "ab"</c>.
        /// </summary>
        [TestCase("a", true)]
        [TestCase("ab", true)]
        [TestCase("abb", false)]
        [TestCase("", false)]
        public void AOrABAlternationOnB(string word, bool expectedMatch)
        {
            var b = new State("B", new Alternation(new RegexLiteral("b"), new RegexLiteral("")));
            var a = new State("A", new Concat(new RegexLiteral("a"), new PushState(b)));
            var states = new[] { a, b };
            Regex ab = states.ToRegex();
            Assert.AreEqual(expectedMatch, ab.IsMatch(word));
        }


        /// <summary>
        /// Another stupid way to chack for <c>s == "a" || s == "ab"</c>.
        /// </summary>
        [TestCase("a", true)]
        [TestCase("ab", true)]
        [TestCase("abb", false)]
        [TestCase("", false)]
        public void AOrABAlternationOnAPush(string word, bool expectedMatch)
        {
            var b = new State("B", new RegexLiteral("b"));
            var a = new State("A", new Concat(new RegexLiteral("a"), new Alternation(new PushState(b), new RegexLiteral(""))));
            var states = new[] { a, b };
            Regex ab = states.ToRegex();
            Assert.AreEqual(expectedMatch, ab.IsMatch(word));
        }


        /// <summary>
        /// Yet another dumb way to chack for <c>s == "a" || s == "ab"</c>.
        /// </summary>
        [TestCase("a", true)]
        [TestCase("ab", true)]
        [TestCase("abb", false)]
        [TestCase("", false)]
        public void AOrABAlternationOnA(string word, bool expectedMatch)
        {
            var b = new State("B", new RegexLiteral("b"));
            var a = new State("A", new Alternation(new RegexLiteral("a"), new Concat(new RegexLiteral("a"), new PushState(b))));
            var states = new[] { a, b };
            Regex ab = states.ToRegex();
            Assert.AreEqual(expectedMatch, ab.IsMatch(word));
        }
    }
}