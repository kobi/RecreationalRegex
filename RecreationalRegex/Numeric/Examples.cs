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

    public static class ExampleIrreducibleFractions
    {
        public static readonly IEnumerable<string> Reducible = new[] { "3/3", "6/3", "24/100", "100/25", "102/99" };
        public static readonly IEnumerable<string> Irreducible = new[] { "1/2", "2/1", "3/4", "200/201", "23/25", "5/2", "100/101" };
    }

    public static class ExampleDecimalAndBinary
    {
        public static readonly IEnumerable<string> Valid = new[] { "10:1010", "3:11", "4:100", "1:1", "1342:10100111110", "0:0", "5:101" };
        public static readonly IEnumerable<string> Invalid = new[] { "4:101", "1342:10100111111", "1342:10100111101" };
    }

    public static class ExampleDivisibleByThree
    {
        public static readonly IEnumerable<string> Valid = "0 3 6 9 12 15 18 21 24 75 75642 111222 212121".Split();
        public static readonly IEnumerable<string> Invalid = "1 2 4 5 7 8 10 11 13 14 16 17 19 20 22 23 25 74 76 75641 75640".Split();
    }
}
