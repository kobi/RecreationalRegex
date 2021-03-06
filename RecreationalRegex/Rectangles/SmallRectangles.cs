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
            (?<!(?=\A\k<Index>(?<=\A\k<CurrentIndex>))\A.*(?<-Index>.)+) 
        )
        (?(IndexLength)(?!)|)   # Not needed, just an assert.
        
        #Copy the shape of rectangle <Index> to the target area.
        #Find rectangle number <Index>
        (?<=(?=.(?<IndexLength>.)*?(?<=\A\k<Index>))\A.*)    # Populate <IndexLength> again.
             # ^-- we are skipping over one character. We want to reach rectangle number <IndexLength>,
             #     so we're skiping over <IndexLength>-1 rectangles
        (?<=(?=\s*(?<-IndexLength>(?:\w+\r?\n)+\r?\n)*(?<=(?<RectangleStart>.*))\w)\A.*) # Capture starting position of this rectangle.
        (?(IndexLength)(?!))
        (?:
            (?<Rotate>)     # Capture 0 characters into <Rotate>. Indicates that we are not rotating this rectangle.
            |
            (?<Rotate>.)    # Capture 1 character into <Rotate>. Indicates that we are rotating this rectangle.
            (?<TempRotate>) # Also mark <TempRotate>. This is a flag that is cleared for each rectangle. Allows conditional matching.
        )

        (?<=(?=\k<NextPos>(?<=(?<X>~*)))\A.*)   # Init <X> with the number of tildes to the left of the starting position.

        # Basically `(?:\w+\n)+\n` to match the whole rectangle.
        (?<=(?=\k<RectangleStart>   # Go to the position before the first character in the current rectangle.
            (?<Rectangle>           # Capture this rectangle, just so we have it while printing the solution.
                (?=(?(TempRotate)(?<TempHeight>\w)|(?<TempWidth>\w))+\r?\n) 
                (?:  
                    (?<SolutionChar>\w)+
                    (?(TempRotate)(?<TempWidth>\r?\n)|(?<TempHeight>\r?\n))
                )+
            )
            \r?\n        # Match until we reach the end of this rectangle.
        )\A.*)

        (?<=(?=[^~]+(?<Width>(?<-TempWidth>~)+))\A.*)(?(TempWidth)(?!)) # Capture as many tildes as the current width.
        (?=(?<-TempHeight>\S*(?<Height>\r?\n))+)(?(TempHeight)(?!))     # Capture newlines into stack <Height>.
        (?(TempRotate)(?<-TempRotate>))                                 # Clear <TempRotate>.

        # Try to fit the rectangle into empty positions in the target rectangle.
        (?<=(?=\k<NextPos>
            (?:
                (?:                         # Match tildes
                    ~
                    (?<=(?<Filled>\A.*))               # Push the current position to <Filled>
                    (?<=(?<TempCurrentFilled>\A.*))    # Also push the current position to <TempCurrentFilled>
                    (?=.*\Z                            # Ensure <Filled> is unique. No overlap between rectangles.
                        (?<!(?=\A\k<Filled>(?<=\A\k<TempCurrentFilled>))\A.*(?<-Filled>.)+) 
                    )
                )+?
                (?<=^\k<X>\k<Width>)        # Match exactly <Width> tildes.
                ~*(?<-Height>\k<Height>\k<X>|\r?\n)     # Match until the same position on the net line (or just the last line).
            )+
            (?(Height)(?!))
        )\A.*)

        # Find the next free position - <NextPos>.
        (?<=(?=.*?                      
            (?<=(?<NextPos>\A.*))       # <NextPos> is the position before the next free tilde.
            ~
            (?<=(?<TempNextPos>\A.*))   # We compare it to <Filled>, which is the position including the tilde.
            (?=.*\Z
                (?<!(?=\A\k<Filled>(?<=\A\k<TempNextPos>))\A.*(?<-Filled>.)*) 
            )
            |
            .*\r?\n\Z (?<Done>)         # If we cannot find more an empty position it means we are done. Set the <Done> flag.
        )\A.*)
        
    )
)+
(?(Done)|(?!))
";

        public static readonly Regex RectanglesRegex = new Regex(RectanglesPattern, RegexOptions.Compiled |
            RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
    }
}
