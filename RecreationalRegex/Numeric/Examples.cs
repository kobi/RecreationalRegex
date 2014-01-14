using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Numeric
{
    public static class ExampleDecimalNumbersAndUnary
    {
        public static readonly IEnumerable<string> Valid = new[] { "1:1", "2:11", "5:12345", "10:1111111111", "11:00000000001", "14:11111111111234", "22:1111111111222222222212",
            "234:" + new String('1', 234),"112:" + new String('1', 112),"9125:" + new String('1', 9125), };
        public static readonly IEnumerable<string> Invalid = new[] { "2:1", "2:123", "14:12345", "16:11111111111234", "23:1111111111222222222212", "234:" + new String('0', 236)
        ,"234:" + new String('0', 233),"112:" + new String('0', 111),"9125:" + new String('0', 9124),};
    }
}
