using System;

namespace Kobi.RecreationalRegex.Mazes
{
    public static partial class Mazes
    {
        [Obsolete]
        public static readonly string MazeSolverWithoutRollbackTrick = @"
(?=(?<Pos>.*?(?<Step>S)))
\A
(?:
    # Find next position
    (?:
        (?<End>)
        (?<=               # Stop when Pos reached E.
            \A(?=\k<Pos>(?<=E))    
        .*)
        |
        (?<Right>)
        (?<=                
            \A              # Go back to start.
            (?=\k<Pos>      # Go to the current position.
                (?<Step>[ E])
                (?<=(?<Pos>\A.*))   # Set new Position.
            )    
        .*)
        |
        (?<Left>)
        (?<=
            \A(?=\k<Pos>(?<=
                (?<Step>[ E])
                (?<=(?<Pos>\A.*))   # Set new Position
                .                   # One step before the current POS
            ))    
        .*)
        |
        (?<Down>)
        (?<=
            \A(?=\k<Pos>
                (?>
                (?-s:                   # Dot should not match new lines
                    (?<=^(?<X>.)*.)       # Count characters to the left. -1 caracter for current position.
                    .*\n                  # Go to end of this line
                    (?<-X>.)*(?(X)(?!))   # Find same position as above character
                )
                )
                (?<Step>[ E])
                (?<=(?<Pos>\A.*))   # Set new Position
            )    
        .*)
        |
        (?<Up>)
        (?<=
            \A(?=\k<Pos>
                (?<=        # Lookbehind - read pattern from bottom to top: http://stackoverflow.com/q/13389560/7586
                    (?-s:                   # Dot does not match new lines
                        (?=
                            (?>(?<-X>.)*(?(X)(?!)))  # Find same position as lower character
                            (?<Step>[ E])
                            (?s:(?<=(?<Pos>\A.*)))   # Set new Position
                        )
                        (?>
                        ^.*\n              # Go to start of the previous line
                        ^(?<X>.)*.         # Count characters to the left. -1 caracter for current position.
                        )
                    )
                )           # End of Lookbehind
            )    
        .*)
    )

. # progress the match.

    # Check the new position is unique - it wasn't matched before.
    (?<=\A
        (?=
            (?<Temp>(?<NewPos>\k<Pos>)) # Set NewPos and Temp to Pos
            (?<-Pos>)                   # Pop Pos.
        )
    .*)

    # None of the other positions are equal to the new postion.
    (?<=\A
        (?:
            (?<=\A
                (?=
                    (?<Temp>\k<Pos>)    # Push Pos to Temp and move to Pos
                    (?<!\k<NewPos>)     # Check the Pas is different from NewPos
                    (?<-Pos>)           # Pop Pos.
                )
            .*)
        .)*
        . # one extra for the new postion
    )
    # Push everything from Temp back to Pos
    (?<=\A  # We know it will reach the begining: Temp should have exactly the same number
            # of positions as the number of characters we've matched
        (?:
            (?<=\A
                (?=\k<Temp>(?<=(?<Pos>\A.*))(?<-Temp>))
            .*)
        .)*
    )

)+?
(?(End)|(?!))
";
    }
}
