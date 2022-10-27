using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class DoLoopCommandParser : CommandParser
    {


        // DO UNTIL expression commands LOOP
        // DO WHILE expression commands LOOP
        // DO commands LOOP UNTIL expression
        // DO commands LOOP WHILE expression
        // DO commands LOOP
        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("DO");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (parser.TryParseKeyword("UNTIL"))
            {
                var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
                parser.TryParseKeyword("LOOP");
                return new RunTime.Command[] { new RunTime.DoUntilLoop(DebugSymbol(parser), commands, expression) };
            }
            else if (parser.TryParseKeyword("WHILE"))
            {
                var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
                parser.TryParseKeyword("LOOP");
                return new RunTime.Command[] { new RunTime.DoWhileLoop(DebugSymbol(parser), commands, expression) };
            }
            else
            {
                var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
                parser.TryParseKeyword("LOOP");
                if (parser.TryParseKeyword("UNTIL"))
                {
                    var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                    return new RunTime.Command[] { new RunTime.DoLoopUntil(DebugSymbol(parser), commands, expression) };
                }
                else if (parser.TryParseKeyword("WHILE"))
                {
                    var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                    return new RunTime.Command[] { new RunTime.DoLoopWhile(DebugSymbol(parser), commands, expression) };
                }
                else
                {
                    return new RunTime.Command[] { new RunTime.DoLoopUntil(DebugSymbol(parser), commands, new RunTime.FalseExpression(DebugSymbol(parser))) };
                }
            }
        }

    }
}