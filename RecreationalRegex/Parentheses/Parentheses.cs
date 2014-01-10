using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Parentheses
{
    public static class Parentheses
    {
        /// <summary>
        /// Not sure what that one is...
        /// </summary>
        public static readonly string Basic = @"^(?<B>)abc(?<A-B>a)\k<A>?";

        /// <summary>
        /// Match mixed balanced parentheses - http://kobikobi.wordpress.com/2010/12/14/net-regex-matching-mixed-balanced-parentheses/
        /// </summary>
        public static readonly string BalancedParenthesesPattern = @"
(
    [^(){}\[\]]+
    | \( (?=[^)]* (?'Memory' \) ) )
    | \[ (?=[^\]]* (?<Memory> \] ) )
    | \{ (?=[^}]* (?<Memory> \} ) )
    | \k<Memory> (?'-Memory')
)+?
(?(Memory) (?!))
";

        public static readonly Regex BalancedParenthesesRegex = new Regex(BalancedParenthesesPattern, RegexOptions.IgnorePatternWhitespace);

        /// <summary>
        /// From http://retkomma.wordpress.com/2009/09/26/regex-balancing-group-in-depth/
        /// </summary>
        public static readonly string BalancedParenthesesFromLinguisticForms = @"
(?>
\( (?<LEVEL>)(?<CURRENT>)
|
(?=\))
(?<LAST-CURRENT>)
(?(?<=\(\k<LAST>)
(?<-LEVEL> \))
)
|
    { (?<LEVEL>)(?<CURRENT>)
|
    (?=})
    (?<LAST-CURRENT>)
    (?(?<={\k<LAST>)
        
        (?<-LEVEL> })
    )
|
\[ (?<LEVEL>)(?<CURRENT>)
|
(?=\])
(?<LAST-CURRENT>)
(?(?<=\[\k<LAST>)
(?<-LEVEL> \] )
)
|
[^()\[\]{}]*
)+?
(?(LEVEL)(?!))
";
    }
}
