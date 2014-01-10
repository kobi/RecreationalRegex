using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.WordLengths
{
    public class Simple
    {
        /// <summary>
        /// Regex to capture a word and a longer word.
        /// </summary>
        public static readonly string ShortWordLongWordPattern =
@"
\b
(?<A>\w)+   # First word - push to the A stack for each letter
\s+         # spaces
(?<-A>\w)+  # Second word - pop from stack
\w+         # Match extra characters (at least one)
\b
(?(A)(?!))  # Make sure the A stack is empty
    ";

        public static readonly Regex ShortWordLongWordRegex = new Regex(ShortWordLongWordPattern, RegexOptions.IgnorePatternWhitespace);

        /// <summary>
        /// Regex to capture words at increasing lengths.
        /// </summary>
        public static readonly string LongerWordLengthsPattern = @"
\b
\w+
(?:
(?<=(?<A>\w)+)
\s+
(?<-A>\w)+\w+
(?(A)(?!))
)+
\b
";

        public static readonly Regex LongerWordLengthsRegex = new Regex(LongerWordLengthsPattern, RegexOptions.IgnorePatternWhitespace);

        /// <summary>
        /// Last pattern from http://blog.stevenlevithan.com/archives/balancing-groups
        /// </summary>
        public static readonly string FunWithIncreasingLength = @"
(?:
	(?(A)\s|) # only on the first word - there's no <-A>
	(?<B>)
	(?<C-B>\w)+ (?(B)(?!))
	(?:
		\s
		(?<C>)
		(?<B-C>\w)+ (?(C)(?!))
		(?<A>) # match a space after this (boring)
	)?
)+ \b
";
    }
}
