﻿using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Rectangles
{
    public static class SmallRectangles
    {
        public static readonly string RectanglesPattern = @"
\A
(?=(?<NextPos>[^~]*))       # \k<NextPos> always matches the position *before* the next free tilde.
(?:
    (?:
        (?<IndexLength>.)+?             # Match n characters. We will use rectangle number n in position <Index>.
                                        # 0 is not an option - we need some shape to be first, second, third, etc.
        (?<=\A(?=(?<Index>(?<-IndexLength>.)+)).*)    # Capture into <Index> the first n characters.
        (?<=\A(?<CurrentIndex>\k<Index>).*)           # Copy Index into CurrentIndex
        (?=.*\Z                                       # Ensure <Index> is unique. We cannot use the same rectangle twice
            (?<!(?<=\A\k<Index>)(?<=\A\k<CurrentIndex>).*(?<-Index>.)+) 
        )
        #Copy the shape of rectangle <Index> to the target area.
        #Ensure no duplicates in solution - no two rectagles can overlap.
        #(?<Rotate>.?)       # Optionally rotate rectangle number <Index>.<Length>. (this will be a simple alternation?)
    )
){4} # +
# continue until the full target area is covered. This is as simple as counting the characters and matches of the solution.
";

        public static readonly Regex RectanglesRegex = new Regex(RectanglesPattern, RegexOptions.Compiled |
            RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
    }
}
