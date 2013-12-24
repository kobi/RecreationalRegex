using Kobi.RecreationalRegex.PcreGrammar.GrammarModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.Builder
{
    /// <summary>
    /// Read the current state from the stack, and push states.
    /// </summary>
    public interface IStackStateWriter
    {
        /// <summary>
        /// Check that the state stack is empty, usually at the end of the match.
        /// </summary>
        void WriteAssertStateStackIsEmpty(IndentedTextWriter indentedTextWriter, StateCollection stateCollection);
        /// <summary>
        /// Push a state to the stack.
        /// </summary>
        void WritePushState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state);
        /// <summary>
        /// Check that we are currently at a certain state, and pop it from the stack.
        /// </summary>
        void WriteWhenInState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state);

    }
}
