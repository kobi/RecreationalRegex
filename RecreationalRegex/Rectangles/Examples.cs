namespace Kobi.RecreationalRegex.Rectangles
{
    public static class Examples
    {
        public static readonly string Simple1 = @"
111

~~~
";
        public static readonly string Simple2 = @"
111
111

~~~
~~~
";

        public static readonly string SimpleRotate1 = @"
11
11
11

~~~
~~~
";

        public static readonly string SimplePair1 = @"
11
11

2
2

~~~
~~~
";


        public static readonly string SimplePairRotate1 = @"
11
11

22

~~~
~~~
";

        public static readonly string Medium1 = @"
11
11

2222

33

4

5

~~~~
~~~~
~~~~
";

        public static readonly string[] ShouldMatch = { Simple1, Simple2, SimplePair1, SimplePairRotate1, SimpleRotate1, Medium1, };


        public static readonly string[] ShouldNotMatch = {
@"
111

~~
",
@"
1

~~
",
@"
111

~~~
~~~
",
        };
    }
}
