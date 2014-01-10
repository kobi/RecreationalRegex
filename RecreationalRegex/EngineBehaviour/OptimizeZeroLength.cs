using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.EngineBehaviour
{
    /// <summary>
    /// I used these to try to get the engine to empty a stack, for the numeric patterns. Couldn't get it to work. There's a similar problem in the maze solver.
    /// </summary>
    public static class OptimizeZeroLength
    {
        public static readonly string PushAll = @"
\A
(?<Stack>){300}

(?> (?<Other-Stack>) )* #{100,400}
    
#(?(Stack)(?!))
";

        public static readonly string PushAllConditionalSlow = @"
\A
(?<Stack>){300}
(?(Stack)
    (?<-Stack>(?<Other>))
){9000000}
(?(Stack)(?!))
";

        public static readonly string PushAllSlow = @"
\A
(?<Stack>){300}

(?>
    (?:
    (?<-Stack>(?<Other>))
    |
    ){9000000}
)
";
    }
}
