using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class CommentCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("'");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            // Skip all tokens until we get to a line feed.
            ParsedToken currentToken;
            string comment = null;
            while (!parser.PeekNextToken().EndOfText && !parser.PeekNextToken().IsOnNewLine)
            {
                currentToken = parser.GetNextToken();
                comment += currentToken.LeadingWhiteSpace + currentToken.MatchedText;
            }
            return new RunTime.Command[] { new RunTime.Comment(DebugSymbol(parser), comment) };
        }
    }
}