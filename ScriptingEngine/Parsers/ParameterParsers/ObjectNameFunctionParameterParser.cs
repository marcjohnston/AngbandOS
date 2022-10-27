using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class ObjectNameFunctionParameterParser : FunctionParameterParser
    {

        public override RunTime.ParameterSymbol TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            string objectName = parser.GetNextToken().MatchedText;
            if (!workEnvironment.ObjectExists(objectName))
            {
                throw new SyntaxErrorScriptException("Object not defined.", parser.CurrentToken());
            }
            return new RunTime.ObjectNameParameterSymbol(new DebugSymbol(parser.CurrentToken().StartCharacterIndex, parser.CurrentToken().MatchedText), objectName);
        }
        public ObjectNameFunctionParameterParser(bool isOptional = false) : base(isOptional)
        {
        }
    }
}