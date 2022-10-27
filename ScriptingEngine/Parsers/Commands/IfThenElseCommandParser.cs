using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class IfThenElseCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("IF");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
            SyntaxParser.ParseKeyword(parser, "THEN");
            var ifTrueCommands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
            RunTime.Command[] ifFalseCommands = null;
            if (parser.TryParseKeyword("ELSE"))
            {
                ifFalseCommands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
            }
            SyntaxParser.ParseKeyword(parser, "END");
            SyntaxParser.ParseKeyword(parser, "IF");
            if (ifFalseCommands == null)
            {
                return new RunTime.Command[] { new RunTime.IfThenElse(DebugSymbol(parser), expression, ifTrueCommands) };
            }
            else
            {
                return new RunTime.Command[] { new RunTime.IfThenElse(DebugSymbol(parser), expression, ifTrueCommands, ifFalseCommands) };
            }
        }
    }
}