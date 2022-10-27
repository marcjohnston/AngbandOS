using Microsoft.VisualBasic;

namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{

    public class KeywordSearchExpression : SearchExpression
    {

        public readonly string Term;
        public readonly string Keyword;
        public override string[] ToKeywords(bool preserveCase = false)
        {
            if (preserveCase)
            {
                return new string[] { Keyword };
            }
            else
            {
                return new string[] { Strings.LCase(Keyword) };
            }
        }
        public override string ToString()
        {
            return Term;
        }
        public KeywordSearchExpression(string term)
        {
            Term = term;
            if (Strings.Left(term, 1) == "\"" & Strings.Right(term, 1) == "\"")
            {
                Keyword = Strings.Mid(term, 2, Strings.Len(term) - 2);
            }
            else
            {
                Keyword = term;
            }
        }
    }
}