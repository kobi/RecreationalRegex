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

        public static readonly string SimpleRotate2 = @"
1
1
1

~~~
";

        public static readonly string SimpleRotate3 = @"
111

~
~
~
";

        public static readonly string SimplePair1 = @"
11
11

2
2

~~~
~~~
";

        public static readonly string SimpleSkip1 = @"
2
2

11
11

~~
~~
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
        public static readonly string Big1 = @"
1111

222
222

333333

444
444

5555

666666

7777
7777
7777

6

9

88
88

aaaa
aaaa

~~~~~~~~~~
~~~~~~~~~~
~~~~~~~~~~
~~~~~~~~~~
~~~~~~~~~~
";

        public static readonly string Medium2 = @"
1111

2222

3333

4444

xxx
xxx
xxx

~~~~~
~~~~~
~~~~~
~~~~~
~~~~~
";

        public static readonly string Medium3 = @"
1111

2222

3
3
3
3

4
4
4
4

xxx
xxx
xxx

~~~~~
~~~~~
~~~~~
~~~~~
~~~~~
";

        public static readonly string[] ShouldMatch =
        {
            Simple1, Simple2, SimplePair1,
            SimplePairRotate1, SimpleRotate1, SimpleRotate2, SimpleRotate3, SimpleSkip1,
            Medium1, Medium2, Medium3,
            Big1,
        };


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
//canvas is too big
@"
11
11

2222

33

4

5

~~~~
~~~~
~~~~
~~~~
",

@"
111

222

33

~~~~
"

    };
    }
}
