using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.WordLengths
{
    /// <summary>
    /// Capture words with Len(Word(i-2)) + Len(Word(i-1)) = Len(Word(i))
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Capture three words - A, B, and C - with Len(A) &lte; Len(B) &lt; Len(C).
        /// </summary>
        public static readonly string CaptureThreeWordsEnforceLengthPattern = @"
\b
(?<A>\w)+
\s+
(?<B-A>(?<B>)\w)+  # Consume all A's, push an extra B
(?(A)(?!))   # Make sure A is finished
(?<B>\w)*    # Add more B's
\s+
(?<-B>\w)+
(?(B)(?!))
\b
";
        public static readonly Regex CaptureThreeWordsEnforceLengthRegex = new Regex(CaptureThreeWordsEnforceLengthPattern, RegexOptions.IgnorePatternWhitespace);

        public static readonly string CaptureThreeWordsPattern = @"
\b
(?<A>\w)+\s+
(?<A>\w)+\s+
(?<-A>\w)+
(?(A)(?!))
\b
";
        public static readonly Regex CaptureThreeWordsRegex = new Regex(CaptureThreeWordsPattern, RegexOptions.IgnorePatternWhitespace);


        public static readonly string CaptureSeries3GroupsPattern = @"
\b
(?:
    (?<A>\w)+   # First word
    \W+
    (?=
        (?<B>\w)+
        \W+
        (?<-A>\w)+
        (?(A)(?!))
        (?<-B>\w)+
        (?(B)(?!))
        \b
    )    #Look Ahead
)+
\w+\W+\w+\b #Capture 2 last words (already looked at them)
";

        public static readonly string CaptureSeriesPattern = @"
\b
(?:
    (?<A>\w)+   # First word
    \W+
    (?=
        (?<A>\w)+
        \W+
        (?<-A>\w)+
        (?(A)(?!))
        \b
    )    #Look Ahead
)+
\w+\W+\w+\b #Capture 2 last words (already looked at them)
";

        public static readonly string CaptureSeriesAllLookaheadPattern = @"
\b
(?:
    (?=
        (?:(?<A>\w)+\s+){2}
        (?<-A>\w)+
        (?(A)(?!))
        \b
    )    #Look Ahead
    \w+
    \s+
)+
\w+\s+\w+\b #Capture 2 last words (already looked at them)
";
        public static readonly Regex CaptureSeriesAllLookaheadRegex = new Regex(CaptureSeriesAllLookaheadPattern, RegexOptions.IgnorePatternWhitespace);

    }
}
