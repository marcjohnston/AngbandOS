using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class SetCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("SET");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var dataValueSymbol = SyntaxParser.ParseObjectValue(parser, scriptEngine, workEnvironment);
            SyntaxParser.ParseKeyword(parser, "=");
            var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);

            return new RunTime.Command[] { new RunTime.Set(DebugSymbol(parser), dataValueSymbol, expression) };
        }
    }
}