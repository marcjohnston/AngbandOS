using System.Collections.Generic;
using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class Sub : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("SUB");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            // Get the name of the subroutine.
            string name = SyntaxParser.ParseIdentifier(parser, scriptEngine, workEnvironment);

            // Create a list for the parameter definitions.
            RunTime.ParameterDefinition[] parameterDefinitions = null;

            // Create the symbol now and add it to the current scope.  Doing this now allows for recursion.
            var subroutineSymbol = new RunTime.SubroutineSymbol(name);
            workEnvironment.AddSymbol(name, subroutineSymbol);

            // Everything inside the subroutine, including the parameter definitions are inside the scope.
            workEnvironment.PushScope();
            if (parser.TryParseKeyword("("))
            {
                var parameterDefinitionList = new List<RunTime.ParameterDefinition>();
                do
                {
                    int startPos = parser.CurrentToken().StartCharacterIndex;
                    string identifier = SyntaxParser.ParseObjectName(parser, scriptEngine, workEnvironment, false);
                    SyntaxParser.ParseKeyword(parser, "AS");
                    var dataType = SyntaxParser.ParseDataType(parser, scriptEngine, workEnvironment);
                    var parameterSymbol = new RunTime.ObjectSymbol(identifier);
                    parameterSymbol.Value = dataType.CreateDataValue();
                    workEnvironment.AddSymbol(identifier, parameterSymbol);
                    parameterDefinitionList.Add(new RunTime.ParameterDefinition(new DebugSymbol(startPos, parser.CurrentToken().EndCharacterIndex), identifier, dataType));
                }
                while (parser.TryParseKeyword(","));
                SyntaxParser.ParseKeyword(parser, ")");
                parameterDefinitions = parameterDefinitionList.ToArray();
            }

            // Parse the commands, using the current scope.
            var commands = SyntaxParser.TryParseCommands(parser, scriptEngine, workEnvironment);
            workEnvironment.PopScope();

            SyntaxParser.ParseKeyword(parser, "END");
            SyntaxParser.ParseKeyword(parser, "SUB");

            // Now update the subroutine symbol with the commands.
            subroutineSymbol.Commands = commands;
            subroutineSymbol.Parameters = parameterDefinitions;

            // Return the subroutine command object.
            return new RunTime.Command[] { new RunTime.Sub(DebugSymbol(parser), name, parameterDefinitions, commands) };
        }
    }
}