using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    /// <summary>
/// 
/// </summary>
/// <remarks>
/// Syntax:
/// FOR counter = start TO end STEP step
///   [statements]
/// NEXT
/// FOR EACH element IN enumerable
///   [statements]
/// NEXT
/// </remarks>
    public class ForCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("FOR");
        }
        // FOR EACH objectname IN expression commands NEXT
        // FOR objectname = expression TO expression [STEP expression] commands NEXT
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (parser.TryParseKeyword("EACH"))
            {
                string objectName = SyntaxParser.ParseObjectName(parser, scriptEngine, workEnvironment, false);
                SyntaxParser.ParseKeyword(parser, "IN");
                var expression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);

                // Add the object to the user data.
                workEnvironment.PushScope();
                var symbol = new RunTime.ObjectSymbol(objectName);
                workEnvironment.AddSymbol(objectName, symbol);

                var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
                SyntaxParser.ParseKeyword(parser, "NEXT");
                parser.TryParseKeyword(objectName);

                // Now remove the object from the user data.
                workEnvironment.PopScope();

                return new RunTime.Command[] { new RunTime.ForEach(DebugSymbol(parser), objectName, expression, commands) };
            }
            else
            {
                string objectName = SyntaxParser.ParseObjectName(parser, scriptEngine, workEnvironment, false);
                SyntaxParser.ParseKeyword(parser, "=");
                var startExpression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                SyntaxParser.ParseKeyword(parser, "TO");
                var endExpression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                RunTime.Expression stepExpression;
                if (parser.TryParseKeyword("STEP"))
                {
                    stepExpression = SyntaxParser.ParseExpression(parser, scriptEngine, workEnvironment);
                }
                else
                {
                    stepExpression = new RunTime.IntegerExpression(1);
                }
                workEnvironment.PushScope();
                var symbol = new RunTime.ObjectSymbol(objectName);
                workEnvironment.AddSymbol(objectName, symbol);
                var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
                SyntaxParser.ParseKeyword(parser, "NEXT");
                parser.TryParseKeyword(objectName);
                workEnvironment.PopScope();
                return new RunTime.Command[] { new RunTime.For(DebugSymbol(parser), objectName, startExpression, endExpression, stepExpression, commands) };
            }
        }
    }
}