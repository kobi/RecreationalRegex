using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Numeric
{
    public static class ParseNumbers
    {
        public static readonly string UnderstandDecimalNumbers = @"
^
(?>
    (?=[0-9])   # optimization - don't multiply when we don't have a digit.
    # multiply the content of the stack by 10
    # for each item on Stack, push 10 items to a Temp stack.
    (?(Decimal)
        (?<-Decimal>
            (?<Temp>){10}
        )
    ){100000}
    (?(Decimal)(?!))
    # Push all items from Temp back to Stack
    (?(Temp)
        (?<-Temp>
            (?<Decimal>)
        )
    ){100000}
    (?(Temp)(?!))
    # match a digit, and push its value to the stack
    (?:
        0                 |
        1 (?<Decimal>)    |
        2 (?<Decimal>){2} |
        3 (?<Decimal>){3} |
        4 (?<Decimal>){4} |
        5 (?<Decimal>){5} |
        6 (?<Decimal>){6} |
        7 (?<Decimal>){7} |
        8 (?<Decimal>){8} |
        9 (?<Decimal>){9}
    )
)+
";

        public static readonly string DecimalNumberAndUnaryPattern = @"
^
(?>
    (?=[0-9])   # optimization - don't multiply when we don't have a digit.
    # multiply the content of the stack by 10
    # for each item on Stack, push 10 items to a Temp stack.
    (?(Decimal)
        (?<-Decimal>
            (?<Temp>){10}
        )
    ){100000}
    (?(Decimal)(?!))
    # Push all items from Temp back to Stack
    (?(Temp)
        (?<-Temp>
            (?<Decimal>)
        )
    ){100000}
    (?(Temp)(?!))
    # match a digit, and push its value to the stack
    (?:
        0                 |
        1 (?<Decimal>)    |
        2 (?<Decimal>){2} |
        3 (?<Decimal>){3} |
        4 (?<Decimal>){4} |
        5 (?<Decimal>){5} |
        6 (?<Decimal>){6} |
        7 (?<Decimal>){7} |
        8 (?<Decimal>){8} |
        9 (?<Decimal>){9}
    )
)+
:
(?<-Decimal>\d)+
\s*$
(?(Decimal)(?!))
";
        public static Regex DecimalNumberAndUnaryPatternRegex = new Regex(DecimalNumberAndUnaryPattern,
            RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);


        /*
        public static Regex DecimalNumberAndEqualBinaryNumberRegex = new Regex(DecimalNumberAndEqualBinaryNumber,
            RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
        */
        public static readonly string DecimalNumberAndEqualBinaryNumber = @"
\b
(?>
    (?=[0-9])
    # multiply the content of the stack by 10
    (?(Decimal)
        (?<-Decimal>
            (?<Temp>){10}
        )
    ){100000}
    (?(Decimal)(?!))
    (?(Temp)
        (?<-Temp>
            (?<Decimal>)
        )
    ){100000}
    (?(Temp)(?!))
    # match a digit, and push its value to the stack
    (?:
        0               |
        1 (?<Decimal>)    |
        2 (?<Decimal>){2} |
        3 (?<Decimal>){3} |
        4 (?<Decimal>){4} |
        5 (?<Decimal>){5} |
        6 (?<Decimal>){6} |
        7 (?<Decimal>){7} |
        8 (?<Decimal>){8} |
        9 (?<Decimal>){9}
    )
)+
:
(?>
    (?=[01])
    # multiply the content of the stack by 2
    (?(Binary)
        (?<-Binary>
            (?<Temp>){2}
        )
    ){100000}
    (?(Binary)(?!))
    (?(Temp)
        (?<-Temp>
            (?<Binary>)
        )
    ){100000}
    (?(Temp)(?!))
    # match a digit, and push its value to the stack
    (?:
        0               |
        1 (?<Binary>)
    )
)+
\b
# Check both stacks are the same length
(?(Decimal)
    (?<-Decimal>)
    (?<-Binary>)
){100000}
(?(Decimal)(?!))
(?(Binary)(?!))
";


        public static readonly string IrreducibleFraction = @"

(?>
    (?=[0-9])
    # multiply the content of the stack by 10
    # for each item on Stack, push 10 items to a Temp stack.
    (?>
        (?<-Numerator>
            (?<Temp>){10}
        )
        |
    ){10000}
    (?(Numerator)(?!))
    # Push all items from Temp back to Stack
    (?>
        (?<-Temp>
            (?<Numerator>)
        )
        |
    ){10000}
    (?(Temp)(?!))
    # match a digit, and push its value to the stack
    (?:
        0                   |
        1 (?<Numerator>)    |
        2 (?<Numerator>){2} |
        3 (?<Numerator>){3} |
        4 (?<Numerator>){4} |
        5 (?<Numerator>){5} |
        6 (?<Numerator>){6} |
        7 (?<Numerator>){7} |
        8 (?<Numerator>){8} |
        9 (?<Numerator>){9}
    )
)+
/
(?>
    (?=[0-9])
    (?>
        (?<-Denominator>
            (?<Temp>){10}
        )
        |
    ){10000}
    (?(Denominator)(?!))
    (?>
        (?<-Temp>
            (?<Denominator>)
        )
        |
    ){10000}
    (?(Temp)(?!))
    (?:
        0                     |
        1 (?<Denominator>)    |
        2 (?<Denominator>){2} |
        3 (?<Denominator>){3} |
        4 (?<Denominator>){4} |
        5 (?<Denominator>){5} |
        6 (?<Denominator>){6} |
        7 (?<Denominator>){7} |
        8 (?<Denominator>){8} |
        9 (?<Denominator>){9}
    )
)+
# check reducible - brute force for every I
(?<i>){100} # i = 100;
";

    }
}
