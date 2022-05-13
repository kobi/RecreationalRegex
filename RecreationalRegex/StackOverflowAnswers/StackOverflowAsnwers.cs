using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.StackOverflowAnswers
{
    public static class StackOverflowAsnwers
    {
        public static readonly string SO3594325 = @"
[^\s{]\S*\s*
|
{
(?:
    [^\s{]\S*
    |
    \s+
    |
    (?<Curly>{)
    |
    (?<-Curly>})
)+?
}
(?(Curly)(?!))
";

        /// <summary>
        /// SO 5073826
        /// http://stackoverflow.com/questions/5073826
        /// </summary>
        public static readonly string FindRegexComments = @"
\A
(?>
    \\.         # Capture an escaped character
    |           # OR
    \[\^?       # a character class
        (?:\\.|[^\]])*    # which may also contain escaped characters
    \]
    |           # OR
    \(\?(?# inline comment!)\#      
        (?<Comment>[^)]*)
    \)
    |           # OR
    \#(?<Comment>.*$)   # a common comment!
    |           # OR
    [^\[\\#]    # capture any regular character - not # or [
)*
\z";

    public static readonly Regex FindRegexCommentsRegex = new Regex(FindRegexComments, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);

        /// <summary>
        /// http://stackoverflow.com/questions/5153980
        /// </summary>
        public static readonly string FindAsterisksNotInBracketsPattern = @"
\\. # Skip an escaped character.
|
\[                  # Skip a character class
    (?:\\.|[^\]])*  # which may also contain escaped characters
\]
|
(?<Asterisk>\*)
";

        public static readonly Regex FindAsterisksNotInBracketsRegex = new Regex(FindAsterisksNotInBracketsPattern, RegexOptions.IgnorePatternWhitespace);

        /// <summary>
        /// http://stackoverflow.com/questions/5153980
        /// </summary>
        public static readonly string FindAsterisksNotInBracketsNoEscape = @"
\[          # Skip a character class
    [^\]]*  # until the first ']'
\]
|
(?<Asterisk>\*)
";

        /// <summary>
        /// http://stackoverflow.com/questions/5341369/regex-for-at-least-two-unique-charactors
        /// </summary>
        /// <remarks>Actually, the OP had a more elegant solution: http://stackoverflow.com/a/5355752/7586 </remarks>
        public static readonly string AtLeastTwoSingleAppearanceCharaters = @"
^
(?>                 # Possesive group - do not backtrack!
    (.)             # Match a duplicated character
       (?:
         (?=.*\1)       # It can have a duplicate after it
         |
         (?<=\1.+)      # Or it already had one
       )
    |               # Or, it isn't a duplicated at all
    (?<Unique>.)    # Capture it as a unique character.
)+
$
(?<-Unique>){2}     # After we're done, check there were at least two unique characters
";

        /// <summary>
        /// Find constructs like "Tel-Aviv (TA)"
        /// http://stackoverflow.com/questions/4593376/regular-expression-for-acronyms
        /// </summary>
        public static readonly string FindAcronymsPattern = @"
\b((?<Acronym>\w)\w*\W+)+
(?<=(?<-Acronym>.(?=.*?(?<Reverse>\k<Acronym>)))+)(?(Acronym)(?!))
\((?<-Reverse>\k<Reverse>)+\)
(?(Reverse)(?!))";

        public static readonly Regex FindAcronymsRegex = new Regex(FindAcronymsPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        public static readonly string FindAcronymsWrongPattern = @"
\b((?<Acronym>\w)\w*\W+)+
\((?<-Acronym>\k<Acronym>)+\)
(?(Acronym)(?!))";
    }

}
