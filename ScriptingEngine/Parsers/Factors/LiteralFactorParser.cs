using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class LiteralFactorParser : FactorParser
    {

        public override RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (parser.PeekNextToken().IsLiteral)
            {
                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                string literal = ((LiteralToken)parser.GetNextToken()).Literal;
                return new RunTime.LiteralExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), literal);
            }
            else
            {
                return null;
            }
        }
    }
}