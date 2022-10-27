
namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class UnarySearchExpression : SearchExpression
    {

        public readonly SearchExpression Term;
        public override string[] ToKeywords(bool preserveCase = false)
        {
            return Term.ToKeywords(preserveCase);
        }
        public UnarySearchExpression(SearchExpression term)
        {
            Term = term;
        }
    }
}