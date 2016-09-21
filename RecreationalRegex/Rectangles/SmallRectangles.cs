using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Rectangles
{
    public static class SmallRectangles
    {
        public static readonly string RectanglesPattern = @"
\A
(?=(?<NextPos>[^~]*))       # \k<NextPos> always matches the position *before* the next free tilde.
(?:
    (?:
        (?<IndexLength>.)+              # Match n characters. We will use rectangle number n in position <Index>.
        (?<=\A(?=(?<Index>(?<-IndexLength>.)+)).*)    # Capture into <Index> the first n characters.
        # Ensure <Index> is unique.
        #(?<Rotate>.?)       # Optionally rotate rectangle number <Index>.<Length>.
    )
){3} # +
";

        public static readonly Regex RectanglesRegex = new Regex(RectanglesPattern, RegexOptions.Compiled |
            RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
    }
}
