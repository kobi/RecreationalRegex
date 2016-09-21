using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        /*
        public static void Print(this MatchCollection matchCollection)
        {
            Console.ResetColor();
            Console.WriteLine("Found {0} matches.", matchCollection.Count);
            foreach (Match match in matchCollection)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(match.Value);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Captured Groups:");
                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("Length:{0}\tText:{1}\tCaptures:{2}", group.Length, group, group.Captures.Count);
                }

                Console.WriteLine();
            }
        }
        */

        public static void PrintMatchesValues(this MatchCollection matchCollection)
        {
            if (matchCollection.Count == 0)
            {
                Console.WriteLine("No matches.");
                return;
            }

            foreach (Match match in matchCollection)
            {
                Console.WriteLine(match.Value);
            }
        }

        public static List<Capture> GetCaptures(this Group group) => group.Captures.Cast<Capture>().ToList();
    }
}
