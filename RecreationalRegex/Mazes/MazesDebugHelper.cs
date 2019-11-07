using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.Mazes
{
    public static class MazesDebugHelper
    {
        private static Dictionary<string, string> Directions =
            new Dictionary<string, string> { { "Left", "<" }, { "Right", ">" },
                                    { "Up", "↑" }, { "Down", "↓" }, { "End", "E" } };

        public static string ShowDirections(this Match mazeMatch)
        {
            if (!mazeMatch.Success) return "No solution.";

            var chars = from groupName in Directions.Keys
                        let letter = Directions[groupName]
                        let regexGroup = mazeMatch.Groups[groupName]
                        from capture in regexGroup.Captures.Cast<Capture>()
                        orderby capture.Index
                        select letter;
            return String.Concat(chars);
        }

        public static string ShowPath(this Match mazeMatch)
        {
            if (!mazeMatch.Success) return "No solution.";
            // get the input string from the Match: https://goo.gl/T5e8B
            StringBuilder maze = new StringBuilder(mazeMatch.Result("$_"));
            var stepDirections = new Queue<char>(mazeMatch.ShowDirections());
            foreach (Capture step in mazeMatch.Groups["Step"].Captures)
            {
                maze[step.Index] = stepDirections.Dequeue();
            }
            return maze.ToString();
        }
    }
}
