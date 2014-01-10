using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Parentheses
{
    public static class Parentheses
    {
        /// <summary>
        /// Not sure what that one is...
        /// </summary>
        public static readonly string Basic = @"^(?<B>)abc(?<A-B>a)\k<A>?";


        public static readonly string BalancedParentheses = @"
(
    [^(){}\[\]]+
    | \( (?=[^)]* (?'Memory' \) ) )
    | \[ (?=[^\]]* (?<Memory> \] ) )
    | \{ (?=[^}]* (?<Memory> \} ) )
    | \k<Memory> (?'-Memory')
)+?
(?(Memory) (?!))
";

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
