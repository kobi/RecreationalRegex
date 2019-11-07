using System;
using System.Collections.Generic;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class Concat : IPattern
    {
        private readonly List<IPattern> _patterns;

        public Concat()
        {
            _patterns = new List<IPattern>();
        }

        public Concat(IEnumerable<IPattern> patterns)
            : this()
        {
            _patterns.AddRange(patterns);
        }

        public Concat(params IPattern[] patterns)
            : this()
        {
            _patterns.AddRange(patterns);
        }

        public IList<IPattern> Patterns { get { return _patterns; } }

        public override string ToString()
        {
            return String.Join(" ", Patterns);
        }
    }
}