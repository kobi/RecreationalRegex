using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var sb = new StringBuilder();
            foreach (var groupName in groupNames)
            {
                var g = match.Groups[groupName];
                sb.Append("\tGroup ").Append(groupName);
                AppendCaptures(sb, g);
            }
            TestContext.WriteLine(sb);
        }

        private static void AppendCaptures(StringBuilder sb, Group group)
        {
            if (!group.Success)
            {
                sb.AppendLine("\t\tNo Captures.");
                return;
            }
            foreach (var capture in group.Captures.Cast<Capture>().OrderBy(c => c.Index))
            {
                sb.AppendFormat("\t\t({1}-{2}) {0}", capture.Value, capture.Index, capture.Index + capture.Length - 1).AppendLine();
            }
        }

        public static void PrintMatchesValues(this MatchCollection matchCollection)
        {
            if (matchCollection.Count == 0)
            {
                TestContext.Progress.WriteLine("No matches.");
                return;
            }
            TestContext.Progress.WriteLine(String.Join("\n", matchCollection.Select(m => m.Value)));
        }

        public static List<Capture> GetCaptures(this Group group) => group.Captures.Cast<Capture>().ToList();
    }
}
