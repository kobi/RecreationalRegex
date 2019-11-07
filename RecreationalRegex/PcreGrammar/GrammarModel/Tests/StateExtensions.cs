using Kobi.RecreationalRegex.PcreGrammar.Builder;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel.Tests
{
    public static class StateExtensions
    {
        public static Regex ToRegex(this IEnumerable<State> states)
        {
            /*
            IStackStateWriter stateWriter = new SingleStackStateWriter();
            /*/ 
            IStackStateWriter stateWriter = new BinaryStacksStateWriter();
            //*/
            string pattern = PatternBuilder.Build(states, stateWriter);
            return new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
        }
    }
}
