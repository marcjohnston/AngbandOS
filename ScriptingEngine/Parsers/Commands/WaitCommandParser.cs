using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class WaitCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("WAIT");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var milliseconds = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
            return new RunTime.Command[] { new RunTime.Wait(DebugSymbol(parser), milliseconds) };
        }
    }
}