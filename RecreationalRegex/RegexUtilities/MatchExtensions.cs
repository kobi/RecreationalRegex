using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kobi.RecreationalRegex.RegexUtilities
{
    public static class MatchExtensions
    {
        public static void PrintAllCapturesToConsole(this Match match, Regex regex)
        {
            if (!match.Success)
            {
                Console.WriteLine("\t\tNo Match.");
                return;
            }
            var groupNames = regex.GetGroupNames();
            foreach (var groupName in groupNames)
            {
                var g = match.Groups[groupName];
                Console.WriteLine("\tGroup {0}",groupName);
                g.PrintCaptures();
            }
        }

        public static void PrintCaptures(this Group group)
        {
            if (!group.Success)
            {
                Console.WriteLine("\t\tNo Captures.");
                return;
            }
            foreach (var capture in group.Captures.Cast<Capture>().OrderBy(c => c.Index))
            {
                Console.WriteLine("\t\t({1}-{2}) {0}", capture.Value, capture.Index, capture.Index + capture.Length - 1);

            }
        }

    }
}
