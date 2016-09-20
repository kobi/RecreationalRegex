using System.Collections.Generic;


namespace Kobi.RecreationalRegex.PcreGrammar
{
    public class Examples
    {
        public static readonly IEnumerable<string> Valid = new[]{
"abcdefg","abc,def,ghi","abc,,,def",",,,,,,","[abc;]","[a,bc;]","sss[abc;d]","as[abc;d,e]","[abc;d,e][fgh;j,k]",
"<abc>","[<a>b;<c,d>,<e,f>]","<a,b,c>","<a,bb,c>","<,,,>","<>","<><>","<>,<>","a<<<<>>><a>>","<<<<<>>>><><<<>>>>",
"<z>[a;b]","<z[a;b]>","[[;];]","[,;,]","[;[;]]","[<[;]>;<[;][;,<[;,]>]>]",
        };

        public static readonly IEnumerable<string> Invalid = new[]{
"<a","bc>","<abc<de>","[a<b;c>;d,e]","[a]","<<<<<>>>><><<<>>>>>","<<<<<>>>><><<<>>>","[abc;def;]","[[;],]","[;,,]","[abc;d,e,f]",
"[<[;]>;<[;][;,<[;,]>]]>","<z[a;b>]",
    };
    }
}
