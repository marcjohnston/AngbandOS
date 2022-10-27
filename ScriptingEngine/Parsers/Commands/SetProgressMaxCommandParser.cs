using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{
    /// <summary>
/// Implements a parser for the SetProgress command.
/// </summary>
/// <remarks></remarks>
    public class SetProgressMaxCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("SETPROGRESSMAX");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
            return new RunTime.Command[] { new RunTime.SetProgressMax(DebugSymbol(parser), expression) };
        }
    }
}