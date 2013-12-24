using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class PushState : IPattern
    {
        private readonly State _nextState;

        public PushState(State nextState)
        {
            _nextState = nextState;
        }

        public State NextState { get { return _nextState; } }

        public override string ToString()
        {
            return String.Format("<push {0}>", NextState.Name);
        }
    }
}