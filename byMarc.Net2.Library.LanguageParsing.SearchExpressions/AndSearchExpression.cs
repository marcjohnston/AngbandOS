
namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class AndSearchExpression : BinarySearchExpression
    {

        public override string ToString()
        {
            return Term1.ToString() + " AND " + Term2.ToString();
        }
        public AndSearchExpression(SearchExpression term1, SearchExpression term2) : base(term1, term2)
        {
        }
    }
}