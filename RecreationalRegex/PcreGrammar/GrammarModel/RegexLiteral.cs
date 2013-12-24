using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class RegexLiteral : IPattern
    {
        private readonly string _content;

        public RegexLiteral(string content)
        {
            _content = content;
        }

        public string Content { get { return _content; } }

        public override string ToString()
        {
            return String.Format("@\"{0}\"", Content);
        }
    }
}
