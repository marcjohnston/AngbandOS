using byMarc.Net2.Library.LanguageParsing;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{

    public class IntegerFactorParser : FactorParser
    {

        public override RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (parser.PeekNextToken().IsWholeNumber)
            {
                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                string value = parser.GetNextToken().MatchedText;
                return new RunTime.IntegerExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), Conversions.ToInteger(value));
            }
            else
            {
                return null;
            }
        }
    }
}