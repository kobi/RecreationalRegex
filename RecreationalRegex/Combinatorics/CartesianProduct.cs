﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Combinatorics
{
    public static class CartesianProduct
    {
        public static readonly string TwoSetsCartesian = @"
# get two word like 1234 abcdef, match all combinations
^
(?:
    \w
    (?=\w*\s(?<SecondElement>\w)+)
)+
\s
(?:
    \w
    (?<=(?<FirstElement>\w)+\s\w*)
)+
$";

        public static readonly Regex TwoSetsCartesianRegex = new Regex(TwoSetsCartesian, RegexOptions.IgnorePatternWhitespace);
    }
}
