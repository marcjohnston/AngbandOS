using byMarc.Net2.Library.LanguageParsing;
using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{

    public class NotFactorParser : FactorParser
    {

        public override RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (Strings.UCase(parser.PeekNextToken().MatchedText) == "NOT")
            {
                // Toss the matched keyword.
                parser.GetNextToken();
                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                var expression = SyntaxParser.ParseFactor(parser, scriptEngine, workEnvironment);
                return new RunTime.NotExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), expression);
            }
            else
            {
                return null;
            }
        }
    }
}