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
        (?<IndexLength>.)+?             # Match n characters. We will use rectangle number n in position <Index>.
                                        # 0 is not an option - we need some shape to be first, second, third, etc.
        (?<=\A(?=(?<Index>(?<-IndexLength>.)+)).*)    # Capture into <Index> the first n characters.
        (?<=\A(?<CurrentIndex>\k<Index>).*)           # Copy Index into CurrentIndex
        (?=.*\Z                                       # Ensure <Index> is unique. We cannot use the same rectangle twice
            (?<!(?<=\A\k<Index>)(?<=\A\k<CurrentIndex>).*(?<-Index>.)+) 
        )
        (?(IndexLength)(?!)|)   # Not needed, just an assert.
        
        #Copy the shape of rectangle <Index> to the target area.
        #Find rectangle number <Index>
        (?<=(?=.(?<IndexLength>.)*?(?<=\A\k<Index>))\A.*)    # Populate <IndexLength> again.
             # ^-- we are skipping over one character. We want to reach rectangle number <IndexLength>,
             #     so we're skiping over <IndexLength>-1 rectangles
        (?<=(?=\s*(?<-IndexLength>(?:\w+\r?\n)+\r?\n)*(?<=(?<RectangleStart>.*))\w)\A.*) # Capture starting position of this rectangle.
        (?(IndexLength)(?!)|)

        (?<=(?=\k<RectangleStart>   # Go to the position before the first character in the next rectangle.
            (?=(?<Rectangle>\w))    # Capture the first character, just so we have it while printing the solution.
            (?<=(?=(?<Needle>\k<NextPos>(?<=(?<X>~*))))\A.*)     # Init <Needle> to point to the position of this rectangle in the target rectangle.
                                                                 # Init <X> with the number of tildes to the left of the starting position.
            (?:                     # Basically `(?:\w+\n)+\n` to match the whole rectangle.
                (?:
                    \w                                  # Match a character from the current rectangle.
                    (?<=(?=(?<Needle>\k<Needle>~))\A.*) # Move needle to the right.
                    # Add to the filled stack (which is similar to needle but not really.
                )+
                \r?\n
                (?<=(?=(?<Needle>\k<Needle>~*\r\n(?:\Z|\k<X>)))\A.*) # Move needle to the next line.
            )+
            \r?\n        # Match until we reach the end of this rectangle.
        )\A.*)

        # Ensure no duplicates in solution - no two rectangles can overlap.
        # Find the next <NextPost> - first next free postion.
        # (?<Rotate>.?)       # Optionally rotate rectangle number <Index>.<Length>. (this will be a simple alternation?)
    )
)+
# continue until the full target area is covered. This is as simple as counting the characters and matches of the solution or not matching more tildes.
";

        public static readonly Regex RectanglesRegex = new Regex(RectanglesPattern, RegexOptions.Compiled |
            RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
    }
}
