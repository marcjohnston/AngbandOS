
namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class ParenthesisSearchExpression : UnarySearchExpression
    {

        public override string ToString()
        {
            return "(" + Term.ToString() + ")";
        }
        public ParenthesisSearchExpression(SearchExpression term) : base(term)
        {
        }
    }
}