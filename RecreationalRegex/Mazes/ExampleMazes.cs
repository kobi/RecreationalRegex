using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.Mazes
{
    public static class ExampleMazes
    {

        public static readonly string SimpleRight = @"  S    E ";
        public static readonly string SimpleLeft = @"  E    S ";
        public static readonly string SimpleRightFull = @"S     E";
        public static readonly string SimpleDown = @"
█ █
█S█
█ █
█ █
█E█
█ █";
        public static readonly string SimpleUp = @"
█ █
█E█
█ █
█ █
█S█
█ █
";
        public static readonly string MedDownRight = @"
█ █
█S███████
█       █
███████ █
      █E█
      █ █";

        public static readonly string Small = @"
██████████
█S█      █
█ █ █ █ ██
█   █ █ E█
██████████
";
        public static readonly string SmallNoSolution = @"
██████████
█S█      █
█ ███ █ ██
█   █ █ E█
██████████
";

        /// <summary>
        /// Source: http://rosettacode.org/wiki/Maze_generation#F.23
        /// </summary>
        public static readonly string BigGood = @"
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
+-+-+-+-+-+-+-+-+-+-+";


        public static readonly string BigBad = @"
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
+-+-+-+-+-+-+-+-+-+-+";

        /// <summary>
        /// Source: http://rosettacode.org/wiki/Maze_generation#Ruby
        /// </summary>
        public static readonly string BigGood2 = @"
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
+-+-+-+-+-+-+-+-+-+-+E+-+-+-+-+-+-+-+-+-+";

        /// <summary>
        /// Source: http://rosettacode.org/wiki/Maze_generation#Ruby
        /// </summary>
        public static readonly string BigBad2 = @"
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
+-+-+-+-+-+-+-+-+-+-+E+-+-+-+-+-+-+-+-+-+";

    }
}
