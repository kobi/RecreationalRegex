﻿using Kobi.RecreationalRegex.PcreGrammar.GrammarModel;
using Kobi.RecreationalRegex.PcreGrammar.GrammarModel.Tests;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.PcreGrammar
{
    /// <summary>
    /// Stack Overflow Question #3349999 - https://stackoverflow.com/q/3349999/7586
    /// Translate PCRE grammar to .Net
    /// <h4>Grammar:</h4>
    /// <code>
    /// Q -> \w | '[' A ';' Q* ','? Q* ']' | '<' A '>'
    /// A -> (Q | ',')*
    /// (match ^A$.)
    /// </code>
    /// </summary>
    /// 
    public class PcreGrammar
    {
        /*
Using stack-based notation for the same grammer, fully explained in an answer:  https://stackoverflow.com/q/3349999/7586

A -> (Q | ',')*
Q -> \w | '[' A ';' Q* ','? Q* ']' | '<' A '>'
          \_______________________/  \______/
                     Q1                 Q2

========================================

pop A -> push A (',' | Q) | ε

pop Q -> \w | push Q1 | push Q2
pop QStar -> push QStar push Q | ε

pop Q2 -> '<' push Q2Close push A
pop Q2Close -> '>'

pop Q1 -> '[' push Q1Close push QStar push Q1OptionalComma push QStar push Q1Semicolon push A
pop Q1Close -> ']'
pop Q2Semicolon -> ';'
pop Q2OptionalComma -> ',' | ε

*/

        /// <summary>
        /// For a State "X", generate a new State classed "XStar" representing "X*".
        /// </summary>
        private static State GetStateStar(State state)
        {
            var starAlternations = new Alternation();
            State stateStar = new State(state.Name + "Star", starAlternations);
            starAlternations.Alternations.Add(new Concat(new PushState(stateStar), new PushState(state)));
            starAlternations.Alternations.Add(new RegexLiteral(""));
            return stateStar;
        }

        public static IEnumerable<State> NumberedStatesPcreGrammarStates()
        {
            var q0Altermations = new Alternation(new RegexLiteral(@"\w"));
            State q = new State("Q", q0Altermations);

            //// A -> A (',' | Q) | ε
            var a0Altermations = new Alternation();
            State a = new State("A", a0Altermations);
            a0Altermations.Alternations.Add(new Concat(new PushState(a), new Alternation(new RegexLiteral(","), new PushState(q))));
            a0Altermations.Alternations.Add(new RegexLiteral(""));

            // pop Q2Close -> '>'
            State q2Close = new State("Q2Close", new RegexLiteral(">"));
            State q2 = new State("Q2", new Concat(new RegexLiteral("<"), 
                new PushState(q2Close),
                new PushState(a)));
            q0Altermations.Alternations.Add(q2.StateBody);

            // pop QStar -> push QStar push Q | ε
            State qStar = GetStateStar(q);

            State q1Close = new State("Q1Close", new RegexLiteral(@"\]"));
            // pop Q2Semicolon -> ';'
            State q1Semicolon = new State("Q1Semicolon", new RegexLiteral(";"));
            //pop Q2OptionalComma -> ',' | ε
            State q1OptionalComma = new State("Q1Comma", new RegexLiteral(",?"));

            //pop Q1 -> '[' push Q1Close push QStar push Q1OptionalComma push QStar push Q1Semicolon push A

            State q1 = new State("Q1", new Concat(
                new RegexLiteral(@"\["),
                new PushState(q1Close),
                new PushState(qStar),
                new PushState(q1OptionalComma),
                new PushState(qStar),
                new PushState(q1Semicolon),
                new PushState(a)
                ));
            q0Altermations.Alternations.Add(q1.StateBody);

            return new[] { a, q, q2Close, qStar, q1OptionalComma, q1Semicolon, q1Close };
        }

        public static Regex NumberedStatesPcreGrammarRegex()
        {
            return NumberedStatesPcreGrammarStates().ToRegex();
        }

        public static IEnumerable<State> NumberedStatesPcreGrammarWithCapturesStates()
        {
            var q0Altermations = new Alternation(new RegexLiteral(@"\w(?<Q-Start>)"));
            State q = new State("Q", new Concat(new RegexLiteral(@"(?<Start>)"), q0Altermations));

            var a0 = new State("A0", new Alternation(new RegexLiteral(","), new PushState(q)));
            var a0Star = GetStateStar(a0);
            var aEnd = new State("AEnd", new RegexLiteral("(?<A-Start>)"));
            var a = new State("A", new Concat(new RegexLiteral(@"(?<Start>)") ,new PushState(aEnd),new PushState(a0Star)));

            // pop Q2Close -> '>'
            State q2Close = new State("Q2Close", new RegexLiteral(">(?<Q-Start>)"));
            State q2 = new State("Q2", new Concat(new RegexLiteral("<"),
                new PushState(q2Close),
                new PushState(a)));
            q0Altermations.Alternations.Add(q2.StateBody);

            // pop QStar -> push QStar push Q | ε
            State qStar = GetStateStar(q);

            State q1Close = new State("Q1Close", new RegexLiteral(@"\](?<Q-Start>)"));
            // pop Q2Semicolon -> ';'
            State q1Semicolon = new State("Q1Semicolon", new RegexLiteral(";"));
            //pop Q2OptionalComma -> ',' | ε
            State q1OptionalComma = new State("Q1Comma", new RegexLiteral(",?"));

            //pop Q1 -> '[' push Q1Close push QStar push Q1OptionalComma push QStar push Q1Semicolon push A

            State q1 = new State("Q1", new Concat(
                new RegexLiteral(@"\["),
                new PushState(q1Close),
                new PushState(qStar),
                new PushState(q1OptionalComma),
                new PushState(qStar),
                new PushState(q1Semicolon),
                new PushState(a)
                ));
            q0Altermations.Alternations.Add(q1.StateBody);

            return new[] { a, a0, a0Star,aEnd, q, q2Close, qStar, q1OptionalComma, q1Semicolon, q1Close };
        }

        public static Regex NumberedStatesPcreGrammarWithCapturesRegex()
        {
            return NumberedStatesPcreGrammarWithCapturesStates().ToRegex();
        }
        
    }
}