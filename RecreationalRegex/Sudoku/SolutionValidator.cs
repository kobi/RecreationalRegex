using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Sudoku
{
    //A giant negative lookahead is a better approach here. 
    //There are better solutions on https://codegolf.stackexchange.com/q/78210/7762

    public class SolutionValidator
    {
        //public static readonly string RowsTooLong = @"^(?=((?<A>.){9})+)"; //just matched everything :P next line is better
        //public static readonly string Rows = @"^(?=(?<A>.)+)";
        //public static readonly string Columns = @"^(?=((?=((?<A>.).{1,8})+$).){9})";
        //public static readonly string Groups = @"^(?=((?=((?<A>.){3}.{0,6})+)...){3})";

        public static readonly string SudokuValidatorPattern = @"
^(?=(?<A>.)+)                           # Rows
(?=((?=((?<A>.).{0,8})+$).){9})         # Columns
(?=((?=((?<A>.){3}.{0,6})+)...){3})     # Squares
# now A has sequential groups of 9 characters.
(           #Check each group of 9 characters.
    (?!
        (
            (
                (?(S)!|(?=.*(?<S>\k<A>))) #(?=.*(?<S>\k<A>)) is enough and shorter, but very slow.
                |
                (?(T)!|(?=.*(?<T>\k<A>)))
            )?
            (?<-A>.)
        ){9}
        (?=.*(?=\k<S>)\k<T>)
    )
    (?<-A>){9}
){27}
";

        public static readonly Regex SudokuValidator = new Regex(SudokuValidatorPattern,
            RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);

        // another idea: Rows/Columns/Squares are the same.
        // groups of:
        // Take 9, skip 0, 9 times
        // Take 1, skip 8, 9 times
        // Take 3, skip 6, 3 times (from 3 locations) (or 9 times, who cares?)
    }
}
