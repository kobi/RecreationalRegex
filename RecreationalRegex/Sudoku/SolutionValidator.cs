using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Sudoku
{
    public class SolutionValidator
    {
        //public static readonly string RowsTooLong = @"^(?=((?<A>.){9})+)"; //just matched everything :P next line is better
        //public static readonly string Rows = @"^(?=(?<A>.)+)";
        //public static readonly string Columns = @"^(?=((?=((?<A>.).{1,8})+$).){9})";
        //public static readonly string Groups = @"^(?=((?=((?<A>.){3}.{0,6})+)...){3})";

        public static readonly string SudokuValidatorPattern = @"
^(?=(?<A>.)+)                           # Rows
(?=((?=((?<A>.).{1,8})+$).){9})         # Columns
(?=((?=((?<A>.){3}.{0,6})+)...){3})     # Squares
.*$
(?<=
    ((?=
        (?<=(?<-A>)(?<S>\k<A>).*)
    ).){9}
){27}
";

        public static readonly Regex SudokuValidator = new Regex(SudokuValidatorPattern,
            RegexOptions.IgnorePatternWhitespace);
    }
}
