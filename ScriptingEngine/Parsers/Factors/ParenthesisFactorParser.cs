using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class ParenthesisFactorParser : FactorParser
    {

        public override RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (parser.PeekNextToken().MatchedText == "(")
            {
                parser.GetNextToken();
                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                SyntaxParser.ParseKeyword(parser, ")");
                return new RunTime.Parenthesis(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), expression);
            }
            else
            {
                return null;
            }
        }
    }
}