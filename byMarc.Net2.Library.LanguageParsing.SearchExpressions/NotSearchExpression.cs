
namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class NotSearchExpression : UnarySearchExpression
    {

        public override string ToString()
        {
            return "NOT " + Term.ToString();
        }
        public override string[] ToKeywords(bool preserveCase = false)
        {
            return null;
        }
        public NotSearchExpression(SearchExpression term) : base(term)
        {
        }
    }
}