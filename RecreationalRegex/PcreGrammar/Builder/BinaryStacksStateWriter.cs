using Kobi.RecreationalRegex.PcreGrammar.GrammarModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace Kobi.RecreationalRegex.PcreGrammar.Builder
{
    public class BinaryStacksStateWriter : IStackStateWriter
    {
        private const string BaseStateStackName = "StateIdBit";

        private string GetStackName(int bit)
        {
            return BaseStateStackName + bit;
        }

        public void WriteAssertStateStackIsEmpty(IndentedTextWriter indentedTextWriter, StateCollection stateCollection)
        {
            indentedTextWriter.WriteLine(@"# When the first stack is empty, all stacks should be empty.");
            indentedTextWriter.WriteLine(@"(?({0})(?!))", GetStackName(0));
        }

        public void WritePushState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state)
        {
            var stateId = stateCollection[state];
            foreach (var bit in EnumerateBits(stateCollection.Count, stateId))
            {
                string stackName = GetStackName(bit.Position);
                indentedTextWriter.WriteLine(SingleStackStateWriter.PushCharactersToStack(stackName, bit.Value));
            }
        }

        public void WriteWhenInState(IndentedTextWriter indentedTextWriter, StateCollection stateCollection, State state)
        {
            var stateId = stateCollection[state];

            var bits = EnumerateBits(stateCollection.Count, stateId)
                .Select(b => new { Bit = b, StackName = GetStackName(b.Position) })
                .ToList();

            foreach (var bit in bits)
            {
                indentedTextWriter.WriteLine(SingleStackStateWriter.AssertCharactersInStack(bit.StackName, bit.Bit.Value));
            }
            foreach (var bit in bits)
            {
                indentedTextWriter.WriteLine("(?<-{0}>)", bit.StackName);
            }
        }

        private struct Bit
        {
            private readonly int _position;
            private readonly bool _value;

            public Bit(int position, bool value)
            {
                _position = position;
                _value = value;
            }

            public int Position { get { return _position; } }
            public int Value { get { return Convert.ToInt32(_value); } }
        }

        private IEnumerable<Bit> EnumerateBits(int stateCount, int stateId)
        {
            
            if (stateCount < 0) throw new ArgumentOutOfRangeException("stateCount");
            stateCount--;
            int position = -1;
            do
            {
                bool bit = Convert.ToBoolean(stateId & 1);
                position++;
                yield return new Bit(position, bit);
                stateCount = stateCount / 2;
                stateId = stateId / 2;
            } while (stateCount > 0);
        }
    }
}