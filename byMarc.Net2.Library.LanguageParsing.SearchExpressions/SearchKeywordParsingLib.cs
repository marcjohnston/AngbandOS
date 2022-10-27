using Microsoft.VisualBasic;

namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{

    public static class SearchKeywordParsingLib
    {

        #region Private, Protected & Friends
        private static SearchExpression ParseTerm(Parser parser)
        {
            var term = ParseProduct(parser);
            while (Strings.UCase(parser.PeekNextToken().MatchedText) == "OR")
            {
                parser.GetNextToken();
                var term2 = ParseProduct(parser);
                term = new OrSearchExpression(term, term2);
            }
            return term;
        }
        private static SearchExpression ParseProduct(Parser parser)
        {
            var term = ParseFactor(parser);
            while (Strings.UCase(parser.PeekNextToken().MatchedText) == "AND")
            {
                parser.GetNextToken();
                var term2 = ParseFactor(parser);
                term = new AndSearchExpression(term, term2);
            }
            return term;
        }
        private static SearchExpression ParseFactor(Parser parser)
        {
            var token = parser.GetNextToken();
            if (token.EndOfText)
            {
                return null;
            }
            else if (Strings.UCase(token.MatchedText) == "NOT")
            {
                return new NotSearchExpression(ParseFactor(parser));
            }
            else if (token.MatchedText == "(")
            {
                var term = ParseKeywords(parser);
                if (parser.PeekNextToken().MatchedText == ")")
                {
                    parser.GetNextToken();
                }
                return new ParenthesisSearchExpression(term);
            }
            else
            {
                return new KeywordSearchExpression(token.MatchedText);
            }
        }
        #endregion

        #region Public Methods
        public static SearchExpression ParseKeywords(Parser parser)
        {
            var term = ParseTerm(parser);
            while (!parser.PeekNextToken().EndOfText && parser.PeekNextToken().MatchedText != ")")
            {
                var term2 = ParseTerm(parser);
                term = new AndSearchExpression(term, term2);
            }
            return term;
        }
        #endregion

    }
}