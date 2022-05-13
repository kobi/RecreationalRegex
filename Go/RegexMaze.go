package main

import (
	"fmt"

	"github.com/dlclark/regexp2"
)

/*
This Go program is using the library Regex2 by Doug Clark ( https://github.com/dlclark ),
which is a port of the .Net regex engine to Go.

Install using:
go get github.com/dlclark/regexp2/...
*/

func solveMaze(maze string) {
	pattern := `
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
                (?<=(?<NewPos>\A.*))   # Set new Position.
            )    
        .*)
        |
        (?<Left>)
        (?<=
            \A(?=\k<Pos>(?<=
                (?<Step>[ E])
                (?<=(?<NewPos>\A.*))   # Set new Position
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
                (?<=(?<NewPos>\A.*))   # Set new Position
            )    
        .*)
        |
        (?<Up>)
        (?<=
            \A(?=\k<Pos>
                (?<=        # Lookbehind - read pattern from bottom to top: https://stackoverflow.com/q/13389560/7586
                    (?-s:                   # Dot does not match new lines
                        (?=
                            (?>(?<-X>.)*(?(X)(?!)))  # Find same position as lower character
                            (?<Step>[ E])
                            (?s:(?<=(?<NewPos>\A.*)))   # Set new Position
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
    # None of the other positions are equal to the new postion.
    (?(End)|
        (?!(?!      # Rollback all changes after matching (Reset Pos)
            (?<=\A
                (?:
                    (?<=\A
                        (?=
                            \k<Pos>             # Move to Pos
                            (?<!\k<NewPos>)     # Check the Pos is different from NewPos
                            (?<-Pos>)           # Pop Pos.
                        )
                    .*)
                .)*
                . # one extra for the new postion
            )
        ))
        # Push NewPos to Pos
        (?<=\A
            (?=
                (?<Pos>\k<NewPos>) # Set NewPos and Temp to Pos
                (?<-NewPos>)       # Pop NewPos. No real reason.
            )
        .*)
    )
)+?
(?(End)|(?!))
`

	//re := regexp2.MustCompile(`(?<A>..)(?<-A>..)(?<-A>.)`, 0)
	re := regexp2.MustCompile(pattern, regexp2.IgnorePatternWhitespace|regexp2.Multiline|regexp2.Singleline)
	if isMatch, _ := re.MatchString(maze); isMatch {
		//do something
		fmt.Println("Solvable!")
	} else {
		fmt.Println("Nope.")
	}
}

func testMazes() {
	goodMazes := []string{
		`
██████████
█S█      █
█ █ █ █ ██
█   █ █ E█
██████████`,
		//Source: https://rosettacode.org/wiki/Maze_generation#F.23
		`
+-+-+-+-+-+-+-+-+-+-+
S         |     |   |
+ +-+-+-+-+ +-+ + + +
|       |   |   | | |
+ +-+-+ + +-+-+ +-+ +
|     | |     |     |
+-+ +-+ +-+-+ +-+-+ +
|   |   |     |     |
+ +-+ +-+ +-+-+-+ +-+
| | |   |       |   |
+ + +-+ +-+ +-+ +-+ +
| |   | | |   |   | |
+ + +-+ + +-+-+-+ + +
|   |   |         | |
+-+ + +-+-+-+-+-+-+ +
|   |     |       | |
+ +-+-+ +-+ +-+-+ + +
| |   |   |     |   |
+ +-+ +-+ +-+-+ +-+-+
|       |           E
+-+-+-+-+-+-+-+-+-+-+`,
		//Source: https://rosettacode.org/wiki/Maze_generation#Ruby
		`
+-+-+-+-+-+-+-+-+-+-+-+-+-+S+-+-+-+-+-+-+
|         | |           | |   |     |   |
+ +-+ +-+ + + +-+-+-+ + + +-+ + +-+ +-+ +
| | | |     | |   |   | |   |   | | |   |
+ + + +-+-+ + + +-+ +-+ +-+ +-+-+ + + +-+
| | |     | |   |   |   |     | |   |   |
+ + +-+-+ +-+-+ + +-+-+ + +-+ + + +-+-+ +
| |     |     | |     |   |   | |       |
+ +-+-+ +-+-+ + +-+-+ +-+-+ +-+ +-+-+-+ +
|       |   | |   | | |           |   | |
+-+-+ +-+ + + +-+ + + +-+-+-+-+ +-+ + + +
| |   |   |     |   |     |     |   |   |
+ + +-+ +-+-+-+-+-+ +-+-+ + +-+-+ +-+-+-+
| |   |           | |   | |   | | |     |
+ +-+ +-+-+-+-+-+ + +-+ + +-+ + + +-+-+ +
|   |     | |     |     |   |   | |     |
+ + +-+-+ + + +-+-+-+-+ +-+ +-+-+ + +-+-+
| |   |   | |   |       |   |     |     |
+ + +-+ +-+ +-+ + +-+-+-+ +-+ +-+-+-+-+ +
| |           |         |               |
+-+-+-+-+-+-+-+-+-+-+E+-+-+-+-+-+-+-+-+-+`}

	badMazes := []string{
		`
██████████
█S█      █
█ ███ █ ██
█   █ █ E█
██████████`, `
+-+-+-+-+-+-+-+-+-+-+
S         |     |   |
+ +-+-+-+-+ +-+ + + +
|       |   |   | | |
+ +-+-+ + +-+-+ +-+ +
|     | |     |     |
+-+ +-+ +-+-+ +-+-+ +
|   |   |     |     |
+ +-+ +-+ +-+-+-+ +-+
| | |   |       |   |
+ + +-+ +-+ +-+ +-+ +
| |   | | |   |   | |
!!!!!!!!!!!!!!!!!!!!!
+ + +-+ + +-+-+-+ + +
|   |   |         | |
+-+ + +-+-+-+-+-+-+ +
|   |     |       | |
+ +-+-+ +-+ +-+-+ + +
| |   |   |     |   |
+ +-+ +-+ +-+-+ +-+-+
|       |           E
+-+-+-+-+-+-+-+-+-+-`, `
+-+-+-+-+-+-+-+-+-+-+-+-+-+S+-+-+-+-+-+-+
|         | |           | |   |     |   |
+ +-+ +-+ + + +-+-+-+ + + +-+ + +-+ +-+ +
| | | |     | |   |   | |   |   | | |   |
+ + + +-+-+ + + +-+ +-+ +-+ +-+-+ + + +-+
| | |     | |   |   |   |     | |   |   |
+ + +-+-+ +-+-+ + +-+-+ + +-+ + + +-+-+ +
| |     |     | |     |   |   | |       |
+ +-+-+ +-+-+ + +-+-+ +-+-+ +-+ +-+-+-+ +
|       |   | |   | | |           |   | |
+-+-+ +-+ + + +-+ + + +-+-+-+-+ +-+ + + +
| |   |   |     |   |     |     |   |   |
+ + +-+ +-+-+-+-+-+ +-+-+ + +-+-+ +-+-+-+
| |   |           | |   | |   | | |     |
+ +-+ +-+-+-+-+-+ + +-+ + +-+ + + +-+-+ +
|   |     | |     |     |   |   | |     |
+ + +-+-+ + + +-+-+-+-+ +-+ +-+-+ + +-+-+
| |   |   | |   |       |   |     |     |
+ + +-+ +-+ +-+ + +-+-+-+ +-+ +-+-+-+-+ +
| |           |   !!!!!!|               |
+-+-+-+-+-+-+-+-+-+-+E+-+-+-+-+-+-+-+-+-+`}

	fmt.Println("These mazes are good:")
	for _, maze := range goodMazes {
		solveMaze(maze)
	}
	fmt.Println("Bad Mazes:")
	for _, maze := range badMazes {
		solveMaze(maze)
	}
}

func main() {
	testMazes()
}
