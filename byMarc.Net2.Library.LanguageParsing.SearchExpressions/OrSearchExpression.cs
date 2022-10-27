
namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class OrSearchExpression : BinarySearchExpression
    {

        public override string ToString()
        {
            return Term1.ToString() + " OR " + Term2.ToString();
        }
        public OrSearchExpression(SearchExpression term1, SearchExpression term2) : base(term1, term2)
        {
        }
    }
}