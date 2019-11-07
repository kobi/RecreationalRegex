using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Numeric
{
    public static class DivisibleByThree
    {
        public static readonly string DecimalDivisibleByThreePattern = @"
\b
(?>             # No regrets - don't backtrack on if/else decisions.
    [0369]      # = 0 (mod 3)
    |
    [147]       # = 1 (mod 3)
    (?:         # if possible pop 2, else push 1
        (?<-Sum>){2}|(?<Sum>)
    )
    |
    [258]       # = 2 (mod 3)
    (?:         # if possible pop 1, else push 2
        (?<-Sum>)|(?<Sum>){2}
    )
)+
\b
(?(Sum)(?!)) # Assert nothing's left in the stack
";

        public static readonly Regex DecimalDivisibleByThreeRegex = new Regex(DecimalDivisibleByThreePattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    }
}