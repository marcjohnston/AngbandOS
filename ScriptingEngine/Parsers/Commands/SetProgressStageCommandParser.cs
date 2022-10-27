using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{
    /// <summary>
/// Implements a parser for the SetProgress command.
/// </summary>
/// <remarks></remarks>
    public class SetProgressStageCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("SETPROGRESSSTAGE");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
            return new RunTime.Command[] { new RunTime.SetProgressStage(DebugSymbol(parser), value) };
        }
    }
}