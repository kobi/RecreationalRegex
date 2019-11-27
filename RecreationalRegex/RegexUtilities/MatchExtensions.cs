using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Kobi.RecreationalRegex.RegexUtilities
{
    public static class MatchExtensions
    {
        public static void PrintAllCapturesToConsole(this Match match, Regex regex)
        {
            if (!match.Success)
            {
                TestContext.WriteLine("\t\tNo Match.");
                return;
            }
            var groupNames = regex.GetGroupNames();
            foreach (var groupName in groupNames)
            {
                var g = match.Groups[groupName];
                TestContext.WriteLine("\tGroup {0}",groupName);
                g.PrintCaptures();
            }
        }

        public static void PrintCaptures(this Group group)
        {
            if (!group.Success)
            {
                TestContext.WriteLine("\t\tNo Captures.");
                return;
            }
            foreach (var capture in group.Captures.Cast<Capture>().OrderBy(c => c.Index))
            {
                TestContext.WriteLine("\t\t({1}-{2}) {0}", capture.Value, capture.Index, capture.Index + capture.Length - 1);
            }
        }
        /*
        public static void Print(this MatchCollection matchCollection)
        {
            TestContext.Progress.ResetColor();
            TestContext.Progress.WriteLine("Found {0} matches.", matchCollection.Count);
            foreach (Match match in matchCollection)
            {
                TestContext.Progress.ForegroundColor = ConsoleColor.Yellow;
                TestContext.Progress.WriteLine(match.Value);
                TestContext.Progress.ForegroundColor = ConsoleColor.Gray;
                TestContext.Progress.WriteLine("Captured Groups:");
                foreach (Group group in match.Groups)
                {
                    TestContext.Progress.WriteLine("Length:{0}\tText:{1}\tCaptures:{2}", group.Length, group, group.Captures.Count);
                }

                TestContext.Progress.WriteLine();
            }
        }
        */

        public static void PrintMatchesValues(this MatchCollection matchCollection)
        {
            if (matchCollection.Count == 0)
            {
                TestContext.Progress.WriteLine("No matches.");
                return;
            }

            foreach (Match match in matchCollection)
            {
                TestContext.Progress.WriteLine(match.Value);
            }
        }

        public static List<Capture> GetCaptures(this Group group) => group.Captures.Cast<Capture>().ToList();
    }
}
