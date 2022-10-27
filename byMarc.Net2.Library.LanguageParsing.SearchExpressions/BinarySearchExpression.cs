using System.Collections.Generic;

namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{
    public class BinarySearchExpression : SearchExpression
    {

        public readonly SearchExpression Term1;
        public readonly SearchExpression Term2;
        public override string[] ToKeywords(bool preserveCase = false)
        {
            var keywords = new List<string>();
            foreach (string keyword in Term1.ToKeywords(preserveCase))
            {
                if (!keywords.Contains(keyword))
                {
                    keywords.Add(keyword);
                }
            }
            foreach (string keyword in Term2.ToKeywords(preserveCase))
            {
                if (!keywords.Contains(keyword))
                {
                    keywords.Add(keyword);
                }
            }
            return keywords.ToArray();
        }
        public BinarySearchExpression(SearchExpression term1, SearchExpression term2)
        {
            Term1 = term1;
            Term2 = term2;
        }
    }
}