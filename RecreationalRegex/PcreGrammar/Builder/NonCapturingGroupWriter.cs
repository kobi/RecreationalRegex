using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.PcreGrammar.Builder
{
    public class NonCapturingGroupWriter : IDisposable
    {
        private readonly IndentedTextWriter _textWriter;
        private readonly string _quantifier;

        public NonCapturingGroupWriter(IndentedTextWriter textWriter, string quantifier)
        {
            _textWriter = textWriter;
            _quantifier = quantifier;

            _textWriter.WriteLine("(?:");
            _textWriter.Indent++;
        }

        public void Dispose()
        {
            _textWriter.Indent--;
            _textWriter.Write(")");
            if (!String.IsNullOrEmpty(_quantifier))
                _textWriter.Write(_quantifier);
            _textWriter.WriteLine();
        }
    }
}
