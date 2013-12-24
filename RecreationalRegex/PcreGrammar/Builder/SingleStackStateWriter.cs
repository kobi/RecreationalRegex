using Kobi.RecreationalRegex.PcreGrammar.GrammarModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.Builder
{
    public class SingleStackStateWriter : IStackStateWriter
    {
        private const string MainStateStackName = "StateId";

        public static string PushCharactersToStack(string stackName, int characterCount)
        {
            if (characterCount == 0)
            {
                return String.Format(@"(?<{0}>)", stackName, characterCount);
            }
            else
            {
                return String.Format(@"(?<=(?=(?<{0}>.{{{1}}}))\A.*)", stackName, characterCount);
            }
        }

        public static string AssertCharactersInStack(string stackName, int characterCount)
        {
            return String.Format(@"(?<=(?=.{{{1}}}(?<=\A\k<{0}>))\A.*)", stackName, characterCount);

        }

        public virtual void WriteAssertStateStackIsEmpty(IndentedTextWriter indentedTextWriter, StateCollection stateCollection)
        {
            indentedTextWriter.WriteLine(@"(?({0})(?!))", MainStateStackName);
        }

        public virtual void WritePushState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state)
        {
            int stateId = stateCollection[state];
            indentedTextWriter.WriteLine(PushCharactersToStack(MainStateStackName, stateId));
        }

        public virtual void WriteWhenInState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state)
        {
            int stateId = stateCollection[state];

            indentedTextWriter.WriteLine(AssertCharactersInStack(MainStateStackName, stateId));
            indentedTextWriter.WriteLine(@"(?<-{0}>)", MainStateStackName);
        }
    }
}
