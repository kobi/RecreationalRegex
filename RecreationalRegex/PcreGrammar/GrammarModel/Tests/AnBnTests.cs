using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel.Tests
{
    [TestFixture]
    public class AnBnTests
    {
        private readonly Regex _anbn;

        public AnBnTests()
        {
            _anbn = ExampleLanguages.AnBn().ToRegex();
        }

        [TestCase("ab")]
        [TestCase("aabb")]
        [TestCase("aaabbb")]
        [TestCase("aaaaaaaaaabbbbbbbbbb")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ShouldMatch(string word)
        {
            Assert.That(_anbn.IsMatch(word));
        }

        [TestCase("aabbx")]
        [TestCase("aaaaa")]
        [TestCase("abbbb")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ShouldNotMatch(string word)
        {
            Assert.That(_anbn.IsMatch(word), Is.False);
        }
    }
}
