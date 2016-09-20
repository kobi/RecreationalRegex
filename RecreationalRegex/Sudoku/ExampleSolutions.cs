﻿using System.Collections.Generic;

namespace Kobi.RecreationalRegex.Sudoku
{
    public class ExampleSolutions
    {
        public IEnumerable<string> Valid = new[]
        {
            "123456789456789123789123456231564897564897231897231564312645978645978312978312645",
            "725893461841657392396142758473516829168429537952378146234761985687935214519284673",
            "395412678824376591671589243156928437249735186738641925983164752412857369567293814",
            "679543182158926473432817659567381294914265738283479561345792816896154327721638945",
            "867539142324167859159482736275398614936241587481756923592873461743615298618924375",
            "954217683861453729372968145516832497249675318783149256437581962695324871128796534",
            "271459386435168927986273541518734269769821435342596178194387652657942813823615794",
            "237541896186927345495386721743269158569178432812435679378652914924813567651794283",
            "168279435459863271273415986821354769734692518596781342615947823387526194942138657",
            "863459712415273869279168354526387941947615238138942576781596423354821697692734185",
            "768593142423176859951428736184765923572389614639214587816942375295837461347651298",
            "243561789819327456657489132374192865926845317581673294162758943735914628498236571",
            "243156789519847326687392145361475892724918653895263471152684937436729518978531264",
            "498236571735914628162758943581673294926845317374192865657489132819327456243561789",
            "978531264436729518152684937895263471724918653361475892687392145519847326243156789",
            "341572689257698143986413275862341957495726831173985426519234768734869512628157394",
        };

        public IEnumerable<string> Invalid = new[]
        {
            "519284673725893461841657392396142758473516829168429537952378146234761985687935214",
            "839541267182437659367158924715692843624973518573864192298316475941285736456729381",
            "679543182158926473432817659567381294914256738283479561345792816896154327721638945",
            "867539142324167859159482736275398684936241517481756923592873461743615298618924375",
            "754219683861453729372968145516832497249675318983147256437581962695324871128796534",
            "271459386435168927986273541518734269769828435342596178194387652657942813823615794",
            "237541896186927345378652914743269158569178432812435679495386721924813567651794283",
            "168759432459613278273165984821594763734982516596821347615437829387246195942378651",
            "869887283619214453457338664548525781275424668379969727517385163319223917621449519",
            "894158578962859187461322315913849812241742157275462973384219294849882291119423759",
            "123456789456789123564897231231564897789123456897231564312645978645978312978312645",
            "145278369256389147364197258478512693589623471697431582712845936823956714931764825",
            "243561789829317456657489132374192865916845327581673294162758943735924618498236571",
            "243156789529847316687392145361475892714928653895263471152684937436719528978531264",
            "498236571735924618162758943581673294916845327374192865657489132829317456243561789",
            "978531264436719528152684937895263471714928653361475892687392145529847316243156789",
            "342571689257698143986413275861342957495726831173985426519234768734869512628157394",
            "345678192627319458892451673468793521713524986951862347179246835534187269286935714",
            "3415726892576981439864132758623419574957268311739854265192347687348695126285173‌​94",

            "123456789123456789123456789123456789123456789123456789123456789123456789123456789",
            "111111111222222222333333333444444444555555555666666666777777777888888888999999999",
            "111222333111222333111222333444555666444555666444555666777888999777888999777888999",
        };
    }
}