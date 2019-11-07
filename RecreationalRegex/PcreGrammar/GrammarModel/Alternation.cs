using System;
using System.Collections.Generic;
using System.Linq;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class Alternation : IPattern
    {
        private readonly IList<IPattern> _alternations;

        public Alternation()
        {
            _alternations = new List<IPattern>();
        }

        public Alternation(params IPattern[] patterns)
        {
            _alternations = patterns.ToList();
        }

        public IList<IPattern> Alternations { get { return _alternations; } }

        public override string ToString()
        {
            return String.Format("( {0} )", String.Join(" | ", Alternations));
        }
    }
}
