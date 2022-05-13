# What's this?

Regular expressions that do things!

# How to use?

The easiest option is to run `dotnet test`, this will run all existing tests and write output to console.

# So what's in there?


## Maze-solving regex

Source: [`Mazes.cs`](RecreationalRegex/Mazes/Mazes.cs)  
Blog post: [Solving mazes using regular expressions](https://kobikobi.wordpress.com/2013/07/06/solving-mazes-using-regular-expressions/)  
<img src="./Images/maze.png">

## Rectagle puzzle solver

Source: [`SmallRectangles.cs`](RecreationalRegex/Rectangles/SmallRectangles.cs)
Blog post: [Filling a large rectangle with smaller rectangles using regular expressions](https://kobikobi.wordpress.com/2016/10/11/filling-a-large-rectangle-with-smaller-rectangles-using-regular-expressions/)  
<img src="./Images/regtangles_smaller.png">

## Convert PCRE recursive grammar to .NET regex

Source: [`PcreGrammar.cs`](RecreationalRegex/PcreGrammar/PcreGrammar.cs)  
For a Stack Overflow answer - which took me **3 years** to figure out.  I ended up writing code to generate a regex from an intemidiate stack-based grammar. fun stuff: [Converting PCRE recursive regex pattern to .NET balancing groups definition](https://stackoverflow.com/a/20644634/7586)  
How can we write this grammar using .NET's balancing groups?
```
Q -> \w | '[' A ';' Q* ','? Q* ']' | '<' A '>'
A -> (Q | ',')*
// match A
```

## Find cartesian product between letters of two words
Get two words as input and return all combinations of letters: `123 abcd`: `1a 1b 1c 1d 2a 2b 2c 2d 3a 3b 3c 3d`
Source: [`CartesianProductTests.cs`](RecreationalRegex/Combinatorics/CartesianProductTests.cs)

