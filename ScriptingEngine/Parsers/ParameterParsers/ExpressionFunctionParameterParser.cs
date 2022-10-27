using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class ExpressionFunctionParameterParser : FunctionParameterParser
    {

        public override RunTime.ParameterSymbol TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
            var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
            return new RunTime.ExpressionParameterSymbol(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), expression);
        }
        public ExpressionFunctionParameterParser(bool isOptional = false) : base(isOptional)
        {
        }
    }
}