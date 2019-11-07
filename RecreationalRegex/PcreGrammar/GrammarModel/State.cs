using System;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class State
    {
        private readonly string _name;

        public State(string name, IPattern stateBody)
        {
            _name = name;
            StateBody = stateBody;
        }

        public IPattern StateBody { get; set; }

        public string Name { get { return _name; } }

        public override string ToString()
        {
            return String.Format("<pop {0}> -> {1}", Name, StateBody);
        }
    }
}
