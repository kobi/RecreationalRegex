using System.Text.RegularExpressions;

namespace Kobi.RecreationalRegex.PcreGrammar
{
    // these are wrong
    public class PcreGrammarWrongAttempts
    {
        public static readonly string FirstAttemptPattern = @"
# regex for http://stackoverflow.com/questions/3349999/net-regex-recursive-patterns
 
^(?:
    (\w(?<Q>)) # Q1
    |
    (<(?<Angler>)) #Q2 - start <
    |
    (\>(?<-Angler>)(?<-A>)?(?<Q>)) #Q2 - end >, match Q
    |
    (\[(?<Block>)) # Q3 start - [
    |
    (;(?<Semi-Block>)(?<-A>)?) #Q3 - ; after [
    |
    (,(?<Comma-Semi>)(?<-Q>)*) #Q3 - , after ;
    |
    (\]((?<-Semi>)|(?<-Comma>))(?<-Q>)*(?<Q>)) #Q3 ] after ;, match Q
    |
    ( ((,|(?<-Q>))*(?<A>)) ) #Match an A group
)*$
# Post Conditions
(?(Angler)(?!))
(?(Block)(?!))
(?(Semi)(?!))
(?(Comma)(?!))
";
        public static readonly Regex FirstAttempt = new Regex(FirstAttemptPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);


        public static readonly string MonthsLater = @"
^(
    \w # Q1
    |
    <                         # match '<' 
      (?=([^,]*(?<Stack>,)?)*$) # push all ',' (allow commas before >)
      (?=[^>]* (?<Stack> > ))  # and push '>'
    |
    \[                         # match '[' 
      (?=([^,]*(?<Stack>,)?)*$) # push all ',' (allow commas before ;)
      (?=[^;]* (?<Stack> ; ))  # and push ';'
    |
    (?<=^((?=\k<Stack>),(?<-Stack>)|.)*)        # pop all remaining ',' before ';'
    (?=\k<Stack>);(?<-Stack>)       # match ';'
        (                           # and
        (?=[^\]]* (?<Stack> \] ))   # push ']'
        |                           # OR
        (?=[^,]* (?<Stack> , ))     # push ','
        )
#    |
#    (?=\k<Stack>),(?<-Stack>) (?=[^\]]* (?<Stack> \] )) # match ',' and push ']'
    |
    (?=[\>\],])\k<Stack> (?<-Stack>)   # match '>', ']' or ',' from the stack and pop it
)*$
# Post Conditions
(?(Stack)(?!))
";

        public static readonly Regex LatestAttempt = new Regex(MonthsLater, RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);
    }
}