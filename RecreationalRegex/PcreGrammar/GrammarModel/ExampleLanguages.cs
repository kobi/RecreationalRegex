using System.Collections.Generic;

namespace Kobi.RecreationalRegex.PcreGrammar.GrammarModel
{
    public class ExampleLanguages
    {
        public static void AnBmCnm()
        {
            State c = new State("C", new RegexLiteral("c"));
            
            var bAlternation=new Alternation();
            State b = new State("B", bAlternation);

            bAlternation.Alternations.Add(new Concat(new PushState(c), new RegexLiteral("b"), new PushState(b)));
            bAlternation.Alternations.Add(new RegexLiteral(""));

            var aAlternation=new Alternation();
            State a = new State("A", aAlternation);
        }

        public static IEnumerable<State> AnBn()
        {
            State b = new State("B", new RegexLiteral("b"));

            var aAlternation = new Alternation();
            State a = new State("A", aAlternation);

            aAlternation.Alternations.Add(new Concat(new PushState(b), new RegexLiteral("a"), new PushState(a)));
            aAlternation.Alternations.Add(new RegexLiteral(""));

            return new[] { a, b };
        }

        public static IEnumerable<State> AStar()
        {
            var aAlternation = new Alternation();
            State a = new State("A", aAlternation);

            aAlternation.Alternations.Add(new Concat(new PushState(a), new RegexLiteral("a")));
            aAlternation.Alternations.Add(new RegexLiteral(""));

            return new[] { a };
        }
    }
}
