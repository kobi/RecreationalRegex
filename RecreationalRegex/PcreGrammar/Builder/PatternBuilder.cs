using Kobi.RecreationalRegex.PcreGrammar.GrammarModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kobi.RecreationalRegex.PcreGrammar.Builder
{
    public class PatternBuilder
    {
        private readonly StateCollection _stateCollection;
        private readonly StringBuilder _stringBuilder;
        private readonly TextWriter _textWriter;
        private readonly IndentedTextWriter _indentedTextWriter;
        private readonly IStackStateWriter _stackStateWriter;

        public PatternBuilder(IEnumerable<State> states, IStackStateWriter stackStateWriter)
        {
            _stateCollection = new StateCollection(states);
            _stringBuilder = new StringBuilder();
            _textWriter = new StringWriter(_stringBuilder);
            _indentedTextWriter = new IndentedTextWriter(_textWriter);
            _stackStateWriter = stackStateWriter;
        }

        public string Build()
        {
            _indentedTextWriter.Indent = 0;
            _stringBuilder.Clear();

            _indentedTextWriter.WriteLine(@"\A");


            WritePushState(_stateCollection.InitialState);

            using (NonCapturingGroup("+"))
            using (NonCapturingGroup(String.Format("{{{0}}}", _stateCollection.Count)))
            {
                WriteWithSeparator("|", _stateCollection);
                _indentedTextWriter.WriteLine(@"|\Z");
            }

            //_indentedTextWriter.WriteLine("{100}?");
            _indentedTextWriter.WriteLine(@"\Z");

            _indentedTextWriter.WriteLine("# Assert state stack is empty");
            _stackStateWriter.WriteAssertStateStackIsEmpty(_indentedTextWriter, _stateCollection);

            return _stringBuilder.ToString();
        }

        protected void WriteWithSeparator(string separator, IEnumerable<dynamic> patterns)
        {
            var items = patterns.ToList();
            for (int i = 0; i < items.Count; i++)
            {
                if (i != 0)
                    _indentedTextWriter.WriteLine(separator);
                Write(items[i]);
            }
        }

        public static string Build(IEnumerable<State> states, IStackStateWriter stackStateWriter)
        {
            var builder = new PatternBuilder(states, stackStateWriter);
            return builder.Build();
        }

        private void Write(State state)
        {
            using (NonCapturingGroup())
            {
                _indentedTextWriter.WriteLine("# When In State {1}, Index = {0}", _stateCollection[state], state.Name);
                _stackStateWriter.WriteWhenInState(_indentedTextWriter, _stateCollection, state);
                Write(state.StateBody);
            }
        }

        private void Write(IPattern pattern)
        {
            dynamic d = pattern;
            Write(d);
        }

        private void Write(RegexLiteral literal)
        {
            _indentedTextWriter.WriteLine(literal.Content);
        }

        private void Write(PushState pushState)
        {
            WritePushState(pushState.NextState);
        }

        private void WritePushState(State state)
        {
            _indentedTextWriter.WriteLine(@"# Push State {1}, Index = {0}", _stateCollection[state], state.Name);
            _stackStateWriter.WritePushState(_indentedTextWriter, _stateCollection, state);
        }

        private void Write(Alternation alternation)
        {
            if (alternation.Alternations.Count == 1)
            {
                Write(alternation.Alternations.Single());
                return;
            }
            using (NonCapturingGroup())
            {
                WriteWithSeparator("|", alternation.Alternations);
            }
        }

        private void Write(Concat concat)
        {
            foreach (var token in concat.Patterns)
            {
                Write(token);
            }
        }

        protected IDisposable NonCapturingGroup(string quantifier = null)
        {
            return new NonCapturingGroupWriter(_indentedTextWriter, quantifier);
        }
    }
}