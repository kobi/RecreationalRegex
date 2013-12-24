using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    /// <summary>
    /// Represent a collection of states, and assign a zero-based index to each state.
    /// </summary>
    public class StateCollection : IEnumerable<State>
    {
        private readonly IReadOnlyDictionary<State, int> _stateIndices;
        private readonly State _initialState;

        public StateCollection(IEnumerable<State> states)
        {
            int i = 0;
            var indices = new Dictionary<State, int>();
            foreach (var state in states)
            {
                if (i == 0) _initialState = state;
                indices[state] = i;
                i++;
            }
            _stateIndices = indices;
        }

        public int this[State state]
        {
            get
            {
                return _stateIndices[state];
            }
        }

        public State InitialState
        {
            get
            {
                return _initialState;
            }
        }

        public IEnumerator<State> GetEnumerator()
        {
            return _stateIndices.Keys.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _stateIndices.Keys.GetEnumerator();
        }

        public int Count
        {
            get { return _stateIndices.Count; }
        }
    }
}
